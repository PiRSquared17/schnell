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
    using System.Diagnostics;

    #endregion

    internal sealed class Command<T> : ICommand where T : class
    {
        private readonly CommandID _id;
        private readonly T _target;
        private readonly Action<T> _onInvoke;
        private readonly Predicate<T> _onEnabled;

        public Command(CommandID id, Action<T> onInvoke) :
            this(id, onInvoke, null) {}

        public Command(CommandID id, Action<T> onInvoke, Predicate<T> onEnabled) :
            this(id, null, onInvoke, onEnabled) {}

        private Command(CommandID id, T target, Action<T> onInvoke, Predicate<T> onEnabled)
        {
            Debug.Assert(id != null);

            _id = id;
            _target = target;
            _onInvoke = onInvoke;
            _onEnabled = onEnabled;
        }

        public CommandID ID
        {
            get { return _id; }
        }

        public bool Enabled
        {
            get { return _onEnabled == null || _onEnabled(GetTarget()); }
        }

        public bool CanBindTo(object candidate)
        {
            if (candidate == null) 
                throw new ArgumentNullException("candidate");

            return candidate is T;
        }

        public ICommand Bind(object target)
        {
            if (target == null) 
                throw new ArgumentNullException("target");

            T typedTarget = target as T;
            if (typedTarget == null) 
                throw new ArgumentException(string.Format("Target object must be of type {0} (given type was {1}).", typeof(T), target.GetType()), "target");

            return new Command<T>(_id, typedTarget, _onInvoke, _onEnabled);
        }

        public void Execute()
        {
            if (_onInvoke != null)
                _onInvoke(GetTarget());
        }

        private T GetTarget()
        {
            if (_target == null)
                throw new InvalidOperationException("Operation is not valid on an unbound command.");

            return _target;
        }
    }
}