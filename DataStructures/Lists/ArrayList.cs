using System;
using System.Collections;

namespace DataStructures.Lists
{
    public class ArrayList<T> : IList<T> where T : IComparable
    {
        private const int _capacity = 10;
        private T[] _items;
        private int _end; // index of last item

        public ArrayList() : this(_capacity) { }
        public ArrayList(int capacity) { InitializeArray(capacity); }

        public static ArrayList<T> ShallowListCopy(IList<T> originalList)
        {
            ArrayList<T> list = new ArrayList<T>();
            foreach (T item in originalList)
            {
                list.Add(item);
            }
            return list;
        }

        public int Size { get { return _end + 1; } }

        public int Capacity { get { return _items.Length; } }

        public T Get(int index)
        {
            if (index < 0 || index > _end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _items[index];
        }

        public T GetFront() { return Get(0); }

        public T GetBack() { return Get(_end); }

        public void AddAt(int index, T item)
        {
            if (index < 0 || index > _end + 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Size == _items.Length)
            {
                Resize();
            }

            if (index <= _end)
            {
                ShiftRight(index);
            }

            _items[index] = item;
            ++_end;
        }

        public void Add(T item)
        {
            AddAt(_end + 1, item);
        }

        public void AddFront(T item)
        {
            AddAt(0, item);
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index > _end)
            {
                throw new ArgumentOutOfRangeException();
            }

            T item = _items[index];

            if (index < _end)
            {
                ShiftLeft(index);
            }

            --_end;

            return item;
        }

        public T Remove()
        {
            return RemoveAt(_end);
        }

        public T RemoveFront()
        {
            return RemoveAt(0);
        }

        public int FindFirstOccurrence(T item)
        {
            int index = -1;

            for (int i = 0; i < Size; ++i)
            {
                if (_items[i].CompareTo(item) == 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void ClearAndResize(int capacity) { InitializeArray(capacity); }

        public void Clear() { _end = -1; }

        public void TrimToSize()
        {
            if (Size == _items.Length) { return; }

            Resize(Size);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Size; ++i)
            {
                yield return _items[i];
            }
        }

        private void Resize(int capacity)
        {
            T[] a = new T[capacity];

            for (int i = 0; i < Size; ++i)
            {
                a[i] = _items[i];
            }

            _items = a;
        }

        private void Resize()
        {
            Resize(_items.Length * 2);
        }

        private void ShiftRight(int start)
        {
            for (int i = _end; i >= start; --i)
            {
                _items[i + 1] = _items[i];
            }
        }

        private void ShiftLeft(int start)
        {
            for (int i = start; i < _end; ++i)
            {
                _items[i] = _items[i + 1];
            }
        }

        private void InitializeArray(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _items = new T[capacity];
            _end = -1;
        }
    }
}
