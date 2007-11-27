#region License, Terms and Author(s)
//
// Schnell - Wiki widgets
// Copyright (c) 2007 Atif Aziz. All rights reserved.
//
//  Author(s):
//      Atif Aziz, http://www.raboof.com
//
// This library is free software; you can redistribute it and/or modify it 
// under the terms of the GNU Lesser General Public License as published by 
// the Free Software Foundation; either version 2.1 of the License, or (at 
// your option) any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or 
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public 
// License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, 
// Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

namespace Schnell
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using Schnell;

    #endregion

    public sealed class WikiParser
    {
        private static readonly Regex _cellsExpression;
        private static readonly Regex _headerExpression;
        private static readonly Regex _commentExpression;
        private static readonly Regex _headingExpression;
        private static readonly Regex _inlinesExpression;

        private Converter<string, Uri> _wikiWordResolver;
        private static readonly Converter<string, Uri> _nonWikiWordResolver = delegate { return null; };

        static WikiParser()
        {
            _cellsExpression   = Regex(@"\|\|((?<t>.+?)\|\|)+");
            _headerExpression  = Regex(@"^(?<d>\#+)\s*(?<k>\!?[a-z]+)(\s+(?<v>.+))?$");
            _commentExpression = Regex(@"^\#.+$");
            _headingExpression = Regex(@"^(?<h>=+)\s*(?<t>.+?)\s*=+$");

            /*  Consider...
                ^
                (
                (?<table> \|\|((?<cell>.+?)\|\|)+ ) | 
                (?<code> {{{ ) |
                (?<meta> \#\s*(?<k>[a-z]+)(\s+(?<v>.+))? ) |
                (?<heading> (?<lvl>=+)\s+(?<txt>.+?)\s+=+ ) |
                (?<bullet> [\t\x20]+[*#]\s*(?<txt>.+?) ) |
                (?<quote> [\t\x20]+(?<txt>[^\s].+?) )
                )
                $
             */

            Dictionary<string, object> atoms = new Dictionary<string, object>();

            atoms.Add("PUNCT", RegexEscape("\"'}]|:,.)?!"));
            atoms.Add("WIKI_WORD", @"(?-i: [A-Z][a-z]+ ([A-Z][a-z]+)+ )");
            atoms.Add("URL_SCHEMES", @"http|https|ftp"); // TODO: Make configurable
            atoms.Add("URL", FormatKwargs(@"
                (^|(?<!\w))                 # guard
                (__URL_SCHEMES__) \: (
                    [^\s\<__PUNCT__] | ( 
                        [__PUNCT__]
                        [^\s\<__PUNCT__]
                    )
                )+", atoms));

            _inlinesExpression = Regex(FormatKwargs(
                @"(?<tt1> `      (?<inner> .*?)          `        )
                  (?<tt2> \{\{\{ (?<inner> .*?)          \}\}\}   )
                  (?<b>   \*     (?<inner> .*?)          \*       )
                  (?<em>  _      (?<inner> .*?)          _        )
                  (?<del> ~~     (?<inner> .*?)          ~~       )
                  (?<sup> \^     (?<inner> .*?)          \^       )
                  (?<sub> ,,     (?<inner> [^,]{1,40})    ,,      )
                  (?<a>   \[     (?<inner> ((?<aurl>__URL__) | (?<aww>[a-z]+)) (\s+ (?<atxt>[^\]]+))? ) \] )
                  (?<url>        (?<inner> __URL__ )              )
                  (?<xww> !      (?<inner> __WIKI_WORD__ )        )
                  (?<ww>         (?<inner> (?<!\[) __WIKI_WORD__) )"
                .Replace('\n', '|'), atoms));
        }

        public Converter<string, Uri> WikiWordResolver
        {
            get { return _wikiWordResolver ?? _nonWikiWordResolver; }
            set { _wikiWordResolver = value; }
        }

        public IEnumerable<WikiToken> Parse(TextReader reader)
        {
            return Parse(reader, null);
        }

        public IEnumerable<WikiToken> Parse(TextReader reader, NameValueCollection headers)
        {
            if (reader == null) 
                throw new ArgumentNullException("reader");

            return Parse(new Reader<string>(Append(GetLines(reader), string.Empty).GetEnumerator()), headers);
        }

        private IEnumerable<WikiToken> Parse(Reader<string> reader, NameValueCollection headers)
        {
            Debug.Assert(reader != null);

            while (reader.HasMore)
            {
                string line = reader.Read().TrimEnd();

                if (line.Length == 0)
                    continue;

                Match headerMatch = _headerExpression.Match(line);
                if (!headerMatch.Success)
                {
                    reader.Unread(line);
                    break;
                }

                if (headers != null)
                {
                    GroupCollection groups = headerMatch.Groups;
                    if (groups["d"].Length == 1)
                        headers[groups["k"].Value] = groups["v"].Value;
                }
            }

            return ParseBody(reader);
        }

        private IEnumerable<WikiToken> ParseBody(Reader<string> reader)
        {
            Debug.Assert(reader != null);

            StringBuilder pb = new StringBuilder();
            
            while (reader.HasMore)
            {
                string line = reader.Read().TrimEnd();

                if (line.Length == 0)
                {
                    if (pb.Length > 0)
                    {
                        WikiParaToken para = new WikiParaToken();
                        yield return para;
                        foreach (WikiToken token in ParseInlineMarkup(pb.ToString()))
                            yield return token;
                        yield return new WikiEndToken(para);

                        pb.Length = 0;
                    }
                }
                else
                {
                    reader.Unread(line);

                    using (IEnumerator<WikiToken> e = FindBlockParser(reader))
                    {
                        if (e != null)
                        {
                            if (pb.Length > 0)
                            {
                                reader.Unread(string.Empty);
                            }
                            else
                            {
                                while (e.MoveNext())
                                    yield return e.Current;
                            }
                        }
                        else
                        {
                            reader.Read();
                            if (pb.Length > 0)
                                pb.Append(' ');
                            pb.Append(line.TrimStart());
                        }
                    }
                }
            }
        }

        private IEnumerator<WikiToken> FindBlockParser(Reader<string> reader)
        {
            Debug.Assert(reader != null);
            Debug.Assert(reader.HasMore);

            string line = reader.Peek();

            if (line == "{{{")
                return ParseCode(reader);

            if (IsTable(line))
                return ParseTable(reader);

            Match match;

            match = _commentExpression.Match(line);
            if (match.Success)
                return ParseComment(reader);

            match = _headingExpression.Match(line);
            if (match.Success)
                return ParseHeading(reader, match);

            int spaces = CountCharRepeating(' ', line);
            if (spaces > 0)
            {
                char nonSpace = line[spaces];

                if (nonSpace == '*' || nonSpace == '#')
                    return ParseList(reader);
                else
                    return ParseQuote(reader);
            }

            return null;
        }

        private IEnumerator<WikiToken> ParseComment(Reader<string> reader) 
        {
            Debug.Assert(reader != null);
            Debug.Assert(reader.HasMore);

            reader.Read();
            return EmptyArray<WikiToken>.Enumerable.GetEnumerator();
        }

        private IEnumerator<WikiToken> ParseQuote(Reader<string> reader)
        {
            Debug.Assert(reader != null);

            StringBuilder sb = new StringBuilder();

            while (reader.HasMore)
            {
                string line = reader.Read().TrimEnd();

                if (line.Length == 0 || !char.IsWhiteSpace(line, 0))
                {
                    reader.Unread(line);
                    break;
                }

                if (sb.Length > 0)
                    sb.Append(' ');
                        
                sb.Append(line);
            }

            WikiQuoteToken quote = new WikiQuoteToken();
            yield return quote;
            foreach (WikiToken token in ParseInlineMarkup(sb.ToString()))
                yield return token;
            yield return new WikiEndToken(quote);
        }

        private IEnumerator<WikiToken> ParseList(Reader<string> reader)
        {
            Debug.Assert(reader != null);

            Stack<WikiToken> lists = new Stack<WikiToken>();
            Stack<int> indents = new Stack<int>();
            indents.Push(0);

            while (reader.HasMore)
            {
                string line = reader.Read().TrimEnd();

                int indent = CountCharRepeating(' ', line);

                if (indent == 0)
                {
                    reader.Unread(line);
                    break;
                }

                if (indent > indents.Peek())
                {
                    WikiToken listToken = line.TrimStart()[0] == '#' ? (WikiToken) new WikiNumberedListToken() : new WikiBulletedListToken();
                    yield return listToken;
                    lists.Push(listToken);
                    indents.Push(indent);
                    reader.Unread(line);
                    continue;
                }

                if (indent < indents.Peek())
                {
                    while (indents.Peek() > indent)
                    {
                        indents.Pop();
                        yield return new WikiEndToken(lists.Pop());
                    }
                    reader.Unread(line);
                    continue;
                }

                WikiListItemToken listItem = new WikiListItemToken();
                yield return listItem;
                foreach (WikiToken token in ParseInlineMarkup(line.TrimStart().Substring(1).TrimStart()))
                    yield return token;
                yield return new WikiEndToken(listItem);
            }

            while (lists.Count > 0)
                yield return new WikiEndToken(lists.Pop());
        }

        private IEnumerator<WikiToken> ParseHeading(Reader<string> reader, Match match) 
        {
            Debug.Assert(reader != null);
            Debug.Assert(reader.HasMore);

            reader.Read();
            int level = match.Groups["h"].Value.Length;
            WikiToken heading = new WikiHeadingToken(level);
            yield return heading;
            foreach (WikiToken token in ParseInlineMarkup(match.Groups["t"].Value))
                yield return token;
            yield return new WikiEndToken(heading);
        }

        private IEnumerator<WikiToken> ParseTable(Reader<string> reader) 
        {
            Debug.Assert(reader != null);

            WikiTableToken table = new WikiTableToken();
            yield return table;

            while (reader.HasMore)
            {
                string line = reader.Read().TrimEnd();

                if (!IsTable(line))
                {
                    reader.Unread(line);
                    break;
                }

                WikiRowToken row = new WikiRowToken();
                yield return row;

                foreach (Capture capture in _cellsExpression.Match(line).Groups["t"].Captures)
                {
                    WikiCellToken cell = new WikiCellToken();
                    yield return cell;
                    foreach (WikiToken token in ParseInlineMarkup(capture.Value.Trim()))
                        yield return token;
                    yield return new WikiEndToken(cell);
                }

                yield return new WikiEndToken(row);
            }

            yield return new WikiEndToken(table);
        }

        private IEnumerator<WikiToken> ParseCode(Reader<string> reader) 
        {
            Debug.Assert(reader != null);
            Debug.Assert(reader.HasMore);

            int nestings = 1;
            StringBuilder sb = new StringBuilder();
            reader.Read(); // skip {{{

            while (reader.HasMore)
            {
                string line = reader.Read();

                if (line == "{{{")
                    nestings++;
                else if (line == "}}}")
                    nestings--;

                if (nestings == 0)
                    break;
                else
                    sb.AppendLine(line);
            }

            if (sb.Length > 0)
                yield return new WikiCodeToken(sb.ToString());
        }

        private IEnumerable<WikiToken> ParseInlineMarkup(string text)
        {
            Debug.Assert(text != null);

            int index = 0;

            foreach (Match match in _inlinesExpression.Matches(text))
            {
                if (match.Index > index)
                    yield return new WikiTextToken(text.Substring(index, match.Index - index));

                string content = match.Groups["inner"].Value;

                if (match.Groups["xww"].Success)
                {
                    yield return new WikiTextToken(content);
                }
                else if (match.Groups["ww"].Success)
                {
                    yield return new WikiWordToken(content, WikiWordResolver(content));
                }
                else if (match.Groups["url"].Success)
                {
                    if (IsImageExtension(content))
                        yield return new WikiImageToken(content);
                    else
                        yield return new WikiHyperlinkToken(content);
                }
                else if (match.Groups["a"].Success)
                {
                    WikiToken token;
                    Group description = match.Groups["atxt"];
                    if (description.Success)
                        content = description.Value.Trim();

                    Group target = match.Groups["aurl"];
                    if (target.Success)
                    {
                        // TODO: Validate well-formedness of URL
                        
                        if (Uri.IsWellFormedUriString(content, UriKind.Absolute) && IsImageExtension(content))
                            token = new WikiImageToken(content, target.Value);
                        else
                            token = new WikiHyperlinkToken(target.Value, content);
                    }
                    else
                    {
                        target = match.Groups["aww"];
                        Debug.Assert(target.Success);
                        token = new WikiWordToken(target.Value, content, WikiWordResolver(target.Value));
                    }

                    yield return token;
                }
                else
                {
                    WikiToken token = null;

                    if (match.Groups["tt1"].Success || match.Groups["tt2"].Success)
                        token = new WikiMonospaceToken();
                    else if (match.Groups["b"].Success)
                        token = new WikiBoldToken();
                    else if (match.Groups["em"].Success)
                        token = new WikiItalicToken();
                    else if (match.Groups["del"].Success)
                        token = new WikiStrikeToken();
                    else if (match.Groups["sup"].Success)
                        token = new WikiSuperscriptToken();
                    else if (match.Groups["sub"].Success)
                        token = new WikiSubscriptToken();

                    if (token == null)
                        break;

                    if (content.Length > 0)
                    {
                        yield return token;

                        if (token is WikiMonospaceToken || token is WikiHyperlinkToken || token is WikiWordToken)
                        {
                            yield return new WikiTextToken(content);
                        }
                        else
                        {
                            foreach (WikiToken subtoken in ParseInlineMarkup(content))
                                yield return subtoken;
                        }

                        yield return new WikiEndToken(token);
                    }
                }

                index = match.Index + match.Length;
            }

            if (index < text.Length)
                yield return new WikiTextToken(text.Substring(index));
        }
        
        private static bool IsImageExtension(string str) 
        {
            Debug.Assert(str != null);

            // TODO: Make configurable

            return str.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                || str.EndsWith(".gif", StringComparison.OrdinalIgnoreCase)
                || str.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || str.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsTable(string line) 
        {
            Debug.Assert(line != null);

            return line.Length > 4 && 
                   line.StartsWith("||", StringComparison.Ordinal) && 
                   line.EndsWith("||", StringComparison.Ordinal);
        }

        private static int CountCharRepeating(char ch, string str)
        {
            return CountCharRepeating(ch, str, 0);
        }

        private static int CountCharRepeating(char ch, string str, int index)
        {
            Debug.Assert(index >= 0);

            while (index < str.Length && str[index] == ch) index++;
            return index;
        }

        /// <summary>
        /// Formats a string using Python-like kwargs. That is, keys are 
        /// specified as __key__ and replaced with their string replacements.
        /// </summary>
        /// <remarks>
        /// Only strings are supported as values.
        /// </remarks>

        private static string FormatKwargs(string format, IEnumerable<KeyValuePair<string, object>> args)
        {
            if (args == null)
                return format;

            string formatted = format;
            foreach (KeyValuePair<string, object> arg in args)
            {
                string value = (arg.Value ?? string.Empty).ToString();
                formatted = formatted.Replace("__" + arg.Key + "__", value);
            }

            return formatted;
        }

        /// <remarks>
        /// <see cref="System.Text.RegularExpressions.Regex.Escape"/> does
        /// not escape the right square bracket, which this wrapper does.
        /// </remarks>

        private static string RegexEscape(string str)
        {
            return System.Text.RegularExpressions.Regex.Escape(str).Replace("]", @"\]");
        }

        private static IEnumerable<string> GetLines(TextReader reader)
        {
            Debug.Assert(reader != null);

            string line = reader.ReadLine();
            while (line != null)
            {
                yield return line;
                line = reader.ReadLine();
            }
        }

        private static IEnumerable<T> Append<T>(IEnumerable<T> values, T tail)
        {
            Debug.Assert(values != null);

            foreach (T value in values)
                yield return value;
            yield return tail;
        }

        private static Regex Regex(string pattern)
        {
            return new Regex(pattern,
                             RegexOptions.ExplicitCapture |
                             RegexOptions.IgnorePatternWhitespace |
                             RegexOptions.IgnoreCase |
                             RegexOptions.Singleline |
                             RegexOptions.CultureInvariant |
                             RegexOptions.Compiled);
        }
    }
}
