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

#region Imports

using System.Reflection;
using System.Runtime.InteropServices;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//

[assembly: AssemblyTitle("Schwiki")]
[assembly: AssemblyDescription("Schnell Wiki Tool")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Schnell")]
[assembly: AssemblyCopyright("Copyright (c) Atif Aziz 2007. All rights reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//
// Configuration (test, debug, release)
//

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

//
// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
//

[assembly: ComVisible(false)]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
//

[assembly: AssemblyVersion("0.1.9419.0")]
[assembly: AssemblyFileVersion("0.1.9419.1657")]
