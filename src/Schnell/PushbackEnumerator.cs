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
    using System.Collections;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Allows pushing back values on to a base enumerator to provide
    /// peeking.
    /// </summary>

    internal sealed class PushbackEnumerator<T> : IEnumerator<T>
    {
        private IEnumerator<T> _inner;
        private Stack<T> _stack;

        public PushbackEnumerator(IEnumerator<T> inner)
        {
            if (inner == null) throw new ArgumentNullException("inner");

            _inner = inner;
            _stack = new Stack<T>();
        }

        public void Push(T value)
        {
            if (_stack.Count == 0)
                _stack.Push(_inner.Current);

            _stack.Push(value);
        }

        public T Current
        {
            get { return _stack.Count == 0 ? _inner.Current : _stack.Peek(); }
        }

        public bool MoveNext()
        {
            if (_stack.Count > 0)
            {
                _stack.Pop();

                if (_stack.Count > 0)
                    return true;
            }

            return _inner.MoveNext();
        }

        void IEnumerator.Reset()
        {
            throw new NotSupportedException();
        }

        void IDisposable.Dispose()
        {
            if (_inner == null)
                return;

            _inner.Dispose();
            _inner = null;
            _stack = null;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}