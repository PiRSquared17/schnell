namespace Schnell
{
    #region Imports

    using System.Collections.Generic;

    #endregion

    internal static class EmptyArray<T>
    {
        public static readonly T[] Value = new T[0];
        public static readonly IEnumerable<T> Enumerable = Value;
    }
}
