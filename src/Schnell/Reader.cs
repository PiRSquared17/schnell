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
    using System.Diagnostics;

    #endregion

    /// <summary>
    /// Adds reading semantics to a base <see cref="IEnumerator{T}"/> with the 
    /// option to un-read and instead new elements while consuming the source.
    /// </summary>

    internal sealed class Reader<T> : IDisposable
    {
        private IEnumerator<T> _enumerator;
        private Stack<T> _buffer;

        public Reader(IEnumerator<T> e)
        {
            Debug.Assert(e != null);

            _enumerator = e;
            _buffer = new Stack<T>();
            RealRead();
        }
        
        public bool HasMore
        {
            get
            {
                EnsureAlive();
                return _buffer.Count > 0;
            }
        }

        public void Unread(T value)
        {
            EnsureAlive();
            _buffer.Push(value);
        }

        public T Read()
        {
            if (!HasMore)
                throw new InvalidOperationException();

            T value = _buffer.Pop();

            if (_buffer.Count == 0)
                RealRead();

            return value;
        }

        public T Peek()
        {
            if (!HasMore)
                throw new InvalidOperationException();

            return _buffer.Peek();
        }

        public void BulkReadTo(ICollection<T> collection)
        {
            if (collection == null) 
                throw new ArgumentNullException("collection");

            EnsureAlive();

            while (!HasMore)
                collection.Add(Read());
        }

        private void RealRead() 
        {
            EnsureAlive();

            if (_enumerator.MoveNext())
                Unread(_enumerator.Current);
        }

        public void Close()
        {
            Dispose();
        }

        void IDisposable.Dispose() { Dispose(); }

        void Dispose()
        {
            if (_enumerator != null)
            {
                _enumerator.Dispose();
                _enumerator = null;
                _buffer = null;
            }
        }

        private void EnsureAlive()
        {
            if (_enumerator == null)
                throw new ObjectDisposedException(GetType().Name);
        }
    }
}