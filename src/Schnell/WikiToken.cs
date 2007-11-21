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
    using System.Diagnostics;

    #endregion

    [ Serializable ]
    public abstract class WikiToken {}

    [ Serializable ]
    public sealed class WikiEndToken : WikiToken
    {
        private readonly WikiToken _start;
        
        public WikiEndToken(WikiToken start)
        {
            _start = start;
        }
        
        public WikiToken Start
        {
            get { return _start; }
        }
    }

    //
    // Inline tokens
    //

    [ Serializable ] public sealed class WikiBoldToken : WikiToken { }
    [ Serializable ] public sealed class WikiItalicToken : WikiToken { }
    [ Serializable ] public sealed class WikiStrikeToken : WikiToken { }
    [ Serializable ] public sealed class WikiSuperscriptToken : WikiToken { }
    [ Serializable ] public sealed class WikiSubscriptToken : WikiToken { }
    [ Serializable ] public sealed class WikiMonospaceToken : WikiToken { }

    //
    // Block tokens
    //

    [ Serializable ] public sealed class WikiCodeToken : WikiToken { }
    [ Serializable ] public sealed class WikiQuoteToken : WikiToken { }
    [ Serializable ] public sealed class WikiParaToken : WikiToken { }
    [ Serializable ] public sealed class WikiNumberedListToken : WikiToken { }
    [ Serializable ] public sealed class WikiBulletedListToken : WikiToken { }
    [ Serializable ] public sealed class WikiListItemToken : WikiToken { }
    [ Serializable ] public sealed class WikiTableToken : WikiToken { }
    [ Serializable ] public sealed class WikiRowToken : WikiToken { }
    [ Serializable ] public sealed class WikiCellToken : WikiToken { }
    
    [ Serializable ] 
    public sealed class WikiHeadingToken : WikiToken
    {
        private readonly int _level;
        
        public WikiHeadingToken(int level)
        {
            if (level < 1 || level > 6)
                throw new ArgumentOutOfRangeException("level", level, null);

            _level = level;
        }
        
        public int Level
        {
            get { return _level; }
        }
    }

    [ Serializable ]
    public sealed class WikiTagToken : WikiToken
    {
        private readonly string _key;
        private readonly string _value;
        
        public WikiTagToken(string key, string value)
        {
            _key = key;
            _value = value;
        }
        
        public string Key
        {
            get { return _key ?? string.Empty; }
        }

        public string Value
        {
            get { return _value ?? string.Empty; }
        }
    }

    [ Serializable ]
    public sealed class WikiImageToken : WikiToken
    {
        private readonly string _src;
        
        public WikiImageToken(string src)
        {
            _src = src;
        }
        
        public string Src
        {
            get { return _src ?? string.Empty; }
        }
    }

    [ Serializable ]
    public sealed class WikiHyperlinkToken : WikiToken
    {
        private readonly string _href;

        public WikiHyperlinkToken(string href)
        {
            _href = href;
        }
        
        public string Href
        {
            get { return _href ?? string.Empty; }
        }
    }

    [ Serializable ]
    public sealed class WikiWordToken : WikiToken
    {
        private readonly string _word;

        public WikiWordToken(string word)
        {
            _word = word;
        }

        public string Word
        {
            get { return _word ?? string.Empty; }
        }
    }
    
    [ Serializable ]
    public sealed class WikiTextToken : WikiToken
    {
        private readonly string _text;
        
        public WikiTextToken(string text)
        {
            _text = text;
        }
        
        public string Text
        {
            get { return _text ?? string.Empty; }
        }
    }
}