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
    using System.ComponentModel.Design;
    using System.Globalization;

    #endregion

    //
    // NOTE: We don't override GetHashCode and Equals so this means
    // that two NamedCommand instances will be equal if their group
    // GUID and numerical ID matches but vary by name! This is by
    // intention.
    //

    [ Serializable ]
    internal sealed class NamedCommand : CommandID 
    {
        private readonly string _name;

        public NamedCommand(Guid menuGroup, int commandID) :
            this(menuGroup, commandID, null) {}

        public NamedCommand(Guid menuGroup, int commandID, string name) : 
            base(menuGroup, commandID)
        {
            if (string.IsNullOrEmpty(name))
                name = "#" + commandID.ToString(CultureInfo.InvariantCulture);

            _name = name;
        }
        
        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
