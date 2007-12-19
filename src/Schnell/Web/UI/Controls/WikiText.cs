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

namespace Schnell.Web.UI.Controls
{
    #region Imports

    using System.Collections.Specialized;
    using System.IO;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;

    #endregion

    [ ToolboxData("<{0}:WikiText1 runat=server></{0}:WikiText1>") ]
    [ DefaultProperty("Text") ]
    [ ParseChildren(false) ]
    public class WikiText : WebControl
    {
        public WikiText() : base(HtmlTextWriterTag.Div) { }

        [ UrlProperty, DefaultValue("") ]
        public virtual string Src
        {
            get { return ((string) ViewState["Src"]) ?? string.Empty; }
            set { ViewState["Src"] = value; }
        }

        [ DefaultValue("") ]
        public virtual string WikiWordUrlFormat
        {
            get { return ((string) ViewState["WikiWordUrlFormat"]) ?? string.Empty; }
            set { ViewState["WikiWordUrlFormat"] = value; }
        }

        [DefaultValue("")]
        public virtual string Text
        {
            get
            {
                if (IsLiteralContent())
                    return ((LiteralControl) Controls[0]).Text;

                if (HasControls() && Controls.Count == 1 && Controls[0] is DataBoundLiteralControl)
                    return ((DataBoundLiteralControl) Controls[0]).Text;
                
                if (Controls.Count > 0)
                    throw new HttpException(string.Format("Inner content of {0} is not literal.", ID));

                return string.Empty;
            }

            set
            {
                Controls.Clear();
                Controls.Add(new LiteralControl(value));
                ViewState["Text"] = value;
            }
        }

        public virtual NameValueCollection GetHeaders()
        {
            NameValueCollection headers = new NameValueCollection();
            using (TextReader reader = GetSourceReader())
                Parse(reader, headers);
            return headers;
        }
        
        protected override void AddParsedSubObject(object obj)
        {
            if (!(obj is LiteralControl) && !(obj is DataBoundLiteralControl))
            {
                throw new HttpException(string.Format(
                    "Cannot have children of type {0} within {1}.",
                    obj.GetType().Name, GetType().Name));
            }

            base.AddParsedSubObject(obj);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            using (TextReader reader = GetSourceReader())
                Format(Parse(reader), writer);
        }

        protected virtual TextReader GetSourceReader() 
        {
            string src = Src;
            if (src.Length > 0)
            {
                Stream stream = null;

                try
                {
                    stream = VirtualPathProvider.OpenFile(ResolveUrl(src));
                    StreamReader reader = new StreamReader(stream);
                    stream = null; // ownership transferred to reader
                    return reader;
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
            }

            return new StringReader(Text.Trim());
        }

        protected virtual IEnumerable<WikiToken> Parse(TextReader reader)
        {
            return Parse(reader, null);
        }

        protected virtual IEnumerable<WikiToken> Parse(TextReader reader, NameValueCollection headers)
        {
            WikiParser parser = new WikiParser();

            string src = Src;
            string urlFormat = WikiWordUrlFormat;
            if (src.Length > 0 && urlFormat.Length > 0)
            {
                string basePath = VirtualPathUtility.GetDirectory(src);
                string extension = VirtualPathUtility.GetExtension(src);
                parser.WikiWordResolver = delegate(string word)
                {
                    string path = VirtualPathUtility.Combine(basePath, word + extension);
                    if (!HostingEnvironment.VirtualPathProvider.FileExists(path))
                        return null;
                    return new Uri(ResolveUrl(string.Format(urlFormat, word)), UriKind.Relative);
                };
            }

            return parser.Parse(reader, headers);
        }

        protected virtual void Format(IEnumerable<WikiToken> tokens, HtmlTextWriter writer)
        {
            new HtmlFormatter().Format(tokens, writer);
        }
    }
}