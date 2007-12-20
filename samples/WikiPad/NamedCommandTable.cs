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
    using System.ComponentModel.Design;
    using System.Reflection;

    #endregion

    [ Serializable ]
    internal sealed class NamedCommandTable
    {
        private Dictionary<string, NamedCommand> _byName;
        private Dictionary<CommandID, NamedCommand> _byID;

        private bool HasByName
        {
            get { return _byName != null && _byName.Count > 0; }
        }

        private Dictionary<string, NamedCommand> ByName
        {
            get
            {
                if (_byName == null)
                    _byName = new Dictionary<string, NamedCommand>(StringComparer.OrdinalIgnoreCase);
                
                return _byName;
            }
        }

        private bool HasByID
        {
            get { return _byID != null && _byID.Count > 0; }
        }

        private Dictionary<CommandID, NamedCommand> ByID
        {
            get
            {
                if (_byID == null)
                    _byID = new Dictionary<CommandID, NamedCommand>();

                return _byID;
            }
        }

        public void FillStandardCommands()
        {
            FieldInfo[] fields = typeof(StandardCommands).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(CommandID))
                {
                    CommandID command = (CommandID) field.GetValue(null);
                    NamedCommand named = new NamedCommand(command.Guid, command.ID, field.Name);
                    ByName.Add(field.Name, named);
                    ByID.Add(command, named);
                }
            }
        }

        public IEnumerable<string> Names
        {
            get
            {
                if (!HasByName)
                    return EmptyArray<string>.Value;

                return ByName.Keys;
            }
        }

        public IEnumerable<NamedCommand> Commands
        {
            get
            {
                if (!HasByName) 
                    return EmptyArray<NamedCommand>.Value;

                return ByName.Values;
            }
        }

        public NamedCommand FindByName(string name)
        {
            if (string.IsNullOrEmpty(name) || !HasByName)
                return null;

            NamedCommand command;
            return ByName.TryGetValue(name, out command) ? command : null;
        }

        public string GetCommandName(CommandID command)
        {
            return GetCommandName(command, string.Empty);
        }

        public string GetCommandName(CommandID command, string defaultName)
        {
            if (command == null || !HasByID)
                return defaultName;

            NamedCommand named;
            return ByID.TryGetValue(command, out named) ? named.Name : defaultName;
        }
    }
}
