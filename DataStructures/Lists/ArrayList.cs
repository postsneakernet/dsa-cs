using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class ArrayList : System.Collections.IEnumerable
    {
        private const int _capacity = 10;
        private int[] _items;
        private int _end; // index of last item

        public ArrayList() : this(_capacity) { }
        public ArrayList(int capacity) { InitializeArray(capacity); }

        public int Size { get { return _end + 1; } }

        public int Capacity { get { return _items.Length; } }

        public int Get(int index)
        {
            if (index < 0 || index > _end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _items[index];
        }

        public int GetFront() { return Get(0); }

        public int GetBack() { return Get(_end); }

        public void AddAt(int index, int item)
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

        public void Add(int item)
        {
            AddAt(_end + 1, item);
        }

        public void AddFront(int item)
        {
            AddAt(0, item);
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index > _end)
            {
                throw new ArgumentOutOfRangeException();
            }

            int item = _items[index];

            if (index < _end)
            {
                ShiftLeft(index);
            }

            --_end;

            return item;
        }

        public int Remove()
        {
            return RemoveAt(_end);
        }

        public int RemoveFront()
        {
            return RemoveAt(0);
        }

        public int FindFirstOccurrence(int item)
        {
            int index = -1;

            for (int i = 0; i < Size; ++i)
            {
                if (_items[i] == item)
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

        public System.Collections.IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Size; ++i)
            {
                yield return _items[i];
            }
        }

        private void Resize(int capacity)
        {
            int[] a = new int[capacity];

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

            _items = new int[capacity];
            _end = -1;
        }
    }
}
