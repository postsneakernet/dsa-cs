using System.Collections;

namespace DataStructures.Lists
{
    public interface IList<T> : IEnumerable
    {
        T Get(int index);
        T GetFront();
        T GetBack();
        void AddAt(int index, T item);
        void Add(T item);
        void AddFront(T item);
        T RemoveAt(int index);
        T Remove();
        T RemoveFront();
        int FindFirstOccurrence(T item);
        int Size { get; }
    }
}
