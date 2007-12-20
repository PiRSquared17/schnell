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

namespace WikiPad
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;

    #endregion

    [ ProvideProperty("Command", typeof(ToolStripItem)) ]
    internal partial class StandardCommandProvider : Component, IExtenderProvider
    {
        private Dictionary<ToolStripItem, string> _commandNameByTool;
        private NamedCommandTable _commandTable;

        public event EventHandler<StandardCommandEventArgs> CommandClick;

        public StandardCommandProvider()
        {
            InitializeComponent();
        }

        public StandardCommandProvider(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is ToolStripItem) && !GetType().IsAssignableFrom(extendee.GetType());
        }

        private Dictionary<ToolStripItem, string> CommandNameByTool
        {
            get
            {
                if (_commandNameByTool == null)
                    _commandNameByTool = new Dictionary<ToolStripItem, string>();

                return _commandNameByTool;
            }
        }

        [ Browsable(false) ]
        public IEnumerable<ToolStripItem> Extendees
        {
            get { return CommandNameByTool.Keys; }
        }

        [ Browsable(false) ]
        public NamedCommandTable CommandTable
        {
            get { return _commandTable; }
            set { _commandTable = value; }
        }

        public IEnumerable<ToolStripItem> GetToolsByCommand(CommandID command)
        {
            if (command != null && CommandTable != null)
            {
                string commandName = CommandTable.GetCommandName(command);

                if (commandName.Length > 0)
                    return GetToolsByCommand(commandName);
            }

            return EmptyArray<ToolStripItem>.Value;
        }

        public IEnumerable<ToolStripItem> GetToolsByCommand(string command)
        {
            if (!string.IsNullOrEmpty(command))
            {
                foreach (KeyValuePair<ToolStripItem, string> pair in CommandNameByTool)
                {
                    if (pair.Value.Equals(command))
                        yield return pair.Key;
                }
            }
        }

        [ DefaultValue("") ]
        [ TypeConverter(typeof(CommandConverter)) ]
        public string GetCommand(ToolStripItem tool)
        {
            string result;
            return CommandNameByTool.TryGetValue(tool, out result) ? 
                result ?? string.Empty : string.Empty;
        }

        public void SetCommand(ToolStripItem tool, string command)
        {
            if (command != null)
            {
                CommandNameByTool[tool] = command;

                if (Site == null || !Site.DesignMode)
                    tool.Click += Item_OnClick;
            }
            else
            {
                CommandNameByTool.Remove(tool);

                if (Site == null || !Site.DesignMode)
                    tool.Click -= Item_OnClick;
            }
        }

        private void Item_OnClick(object sender, EventArgs e)
        {
            if (CommandTable == null)
                return;

            string commandName = CommandNameByTool[(ToolStripItem) sender];

            CommandID command = CommandTable.FindByName(commandName);
            if (command == null)
                return;

            OnCommandClick(new StandardCommandEventArgs(command));
        }

        protected virtual void OnCommandClick(StandardCommandEventArgs e)
        {
            EventHandler<StandardCommandEventArgs> handler = CommandClick;

            if (handler != null)
                handler(this, e);
        }

        private sealed class CommandConverter : TypeConverter
        {
            private string[] _names;

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                if (_names == null)
                {
                    NamedCommandTable commands = new NamedCommandTable();
                    commands.FillStandardCommands();
                    string[] names = Enumerable.ToArray(commands.Names);
                    Array.Sort(names, StringComparer.InvariantCulture);
                    _names = names;
                }

                return new StandardValuesCollection(_names);
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
        }
    }
}
