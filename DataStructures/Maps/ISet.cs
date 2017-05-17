using System;
using System.Collections;

namespace DataStructures.Maps
{
    public interface ISet<T> : IEnumerable where T : IComparable
    {
        void Insert(T item);
        bool Remove(T item);
        bool Contains(T item);
        int Size { get; }
    }
}
