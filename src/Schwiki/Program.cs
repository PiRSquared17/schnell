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

namespace Schwiki
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;
    using Schnell;

    #endregion

    internal static class Program
    {
        static int Main(string[] args)
        {
            try
            {
                Options options = new Options();
                Run(options, ParseOptions(args, options));
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.GetBaseException().Message);
                Trace.WriteLine(e.ToString());
                return -1;
            }
        }

        private static void Run(Options options, IEnumerable<string> args)
        {
            Debug.Assert(options != null);
            Debug.Assert(args != null);

            if (options.TemplatePath.Length == 0)
                throw new ApplicationException("Missing HTML template file path.");

            TextReader reader = null;
            TextWriter writer = null;
            Converter<string, Uri> wikiWordResolver = null;
            IEnumerator<string> arg = args.GetEnumerator();
            
            try
            {
                string wikiPath = null;
                string htmlExtension = null;

                if (arg.MoveNext())
                {
                    string sourcePath = arg.Current;
                    if (sourcePath != "-")
                    {
                        options.Variables["title"] = options.FindVariable("title", Path.GetFileNameWithoutExtension(sourcePath));
                        wikiPath = Path.GetDirectoryName(sourcePath);
                        reader = File.OpenText(sourcePath);
                    }
                }

                if (arg.MoveNext())
                {
                    string targetPath = arg.Current;
                    if (targetPath != "-")
                    {
                        writer = File.CreateText(targetPath);
                        htmlExtension = Path.GetExtension(targetPath);
                    }
                }

                if (!string.IsNullOrEmpty(wikiPath) && !string.IsNullOrEmpty(htmlExtension))
                {
                    wikiWordResolver = delegate(string word)
                    {
                        string filename = word + htmlExtension;
                        return File.Exists(Path.Combine(wikiPath, filename)) ? new Uri(filename, UriKind.Relative) : null;
                    };
                }

                Format(writer ?? Console.Out, File.ReadAllText(options.TemplatePath), 
                       reader ?? Console.In, options, wikiWordResolver);
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (writer != null)
                    writer.Close();
            }
        }

        private static void Format(TextWriter writer, string template, TextReader reader, Options options, Converter<string, Uri> wikiWordResolver)
        {
            Debug.Assert(writer != null);
            Debug.Assert(template != null);
            Debug.Assert(reader != null);
            Debug.Assert(options != null);

            string bodyName = MaskEmpty(options.BodyName, "body");

            char[] buffer = template.ToCharArray();
            int index = 0;

            foreach (Match match in Regex.Matches(template, MaskEmpty(options.NamePattern, "$([A-Za-z_]+)"), RegexOptions.CultureInvariant))
            {
                writer.Write(buffer, index, match.Index - index);

                string key = match.Groups[1].Value;

                if (string.CompareOrdinal(key, bodyName) == 0)
                {
                    HtmlFormatter formatter = new HtmlFormatter();
                    formatter.WikiWordResolver = wikiWordResolver;
                    formatter.Format(WikiParser.Parse(reader), new XhtmlTextWriter(writer, "  "));
                }
                else
                {
                    // TODO: Add URL-encoding support
                    HttpUtility.HtmlEncode(options.FindVariable(key, key + "?"), writer);
                }

                index = match.Index + match.Length;
            }

            writer.Write(buffer, index, buffer.Length - index);
        }

        private static string MaskEmpty(string str, string mask)
        {
            return !string.IsNullOrEmpty(str) ? str : mask;
        }

        // TODO: Consider using optparse (as in Python) for ParseOptions
        // TODO: Add support for response files

        private static IEnumerable<string> ParseOptions(IEnumerable<string> args, Options options)
        {
            Debug.Assert(args != null);
            Debug.Assert(options != null);

            List<string> unnamedList = new List<string>();

            IEnumerator<string> e = args.GetEnumerator();

            while (e.MoveNext())
            {
                string arg = e.Current.Trim();

                if (arg.Length == 0)
                    continue;

                if (arg == "--") // -- on commad line means rest is comment
                    break;

                if (arg.Length > 1 && arg[0] == '-')
                {
                    string name = arg.TrimStart('-');

                    switch (name)
                    {
                        case "define":
                        case "d":
                        {
                            string value = GetOptionValue(e);
                            string[] parts = value.Split(new char[] { '=' }, 2);
                            options.Variables[parts[0]] = parts[1];
                            break;
                        }
                        case "t":
                        case "template":
                        {
                            options.TemplatePath = GetOptionValue(e);
                            break;
                        }
                        case "body-name":
                        {
                            options.BodyName = GetOptionValue(e);
                            break;
                        }
                        case "name-pattern":
                        {
                            options.NamePattern = GetOptionValue(e);
                            break;
                        }
                        case "?":
                        case "h":
                        case "help":
                        {
                            throw new NotImplementedException("Sorry, but help is on its way.");
                        }
                        default:
                            throw new ApplicationException(string.Format("Argument {0} is invalid.", arg));
                    }
                }
                else
                {
                    unnamedList.Add(arg);
                }
            }

            return unnamedList;
        }

        private static string GetOptionValue(IEnumerator<string> e)
        {
            Debug.Assert(e != null);

            string name = e.Current;

            if (!e.MoveNext() || e.Current.Length == 0)
                throw new ApplicationException(string.Format("Missing value for {0} argument.", name));

            return e.Current;
        }

        [Serializable]
        private sealed class Options
        {
            private Dictionary<string, string> _variables;
            private string _templatePath;
            private string _bodyName;
            private string _namePattern;

            public bool HasVariables
            {
                get { return _variables != null && _variables.Count > 0; }
            }

            public Dictionary<string, string> Variables
            {
                get
                {
                    if (_variables == null)
                        _variables = new Dictionary<string, string>();

                    return _variables;
                }
            }

            public string FindVariable(string name)
            {
                return FindVariable(name, string.Empty);
            }

            public string FindVariable(string name, string defaultValue)
            {
                string value;
                return HasVariables && Variables.TryGetValue(name, out value) ? value : defaultValue;
            }

            public string TemplatePath
            {
                get { return _templatePath ?? string.Empty; }
                set { _templatePath = value; }
            }

            public string BodyName
            {
                get { return _bodyName ?? string.Empty; }
                set { _bodyName = value; }
            }

            public string NamePattern
            {
                get { return _namePattern ?? string.Empty; }
                set { _namePattern = value; }
            }
        }
    }
}
