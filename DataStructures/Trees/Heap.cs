using System;

namespace DataStructures.Trees
{
    public class Heap<T> where T : IComparable
    {
        private const int _capacity = 10;
        private T[] _items;
        private bool _isMaxHeap;
        private int _end; // Index of last item
        private int _heapSize;

        public Heap() : this(_capacity, true) { }

        public Heap(int capacity, bool isMaxHeap)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _items = new T[capacity];
            _isMaxHeap = isMaxHeap;
            _end = -1;
            _heapSize = 0;
        }

        public Heap(T[] a, bool isMaxHeap)
        {
            ReHeapify(a, isMaxHeap);
        }

        public static Heap<T> CreateMaxHeap(int capacity = _capacity) { return new Heap<T>(capacity, true); }
        public static Heap<T> CreateMinHeap(int capacity = _capacity) { return new Heap<T>(capacity, false); }

        public static Heap<T> MaxHeapify(T[] a) { return new Heap<T>(a, true); }
        public static Heap<T> MinHeapify(T[] a) { return new Heap<T>(a, false); }

        public bool IsMaxHeap { get { return _isMaxHeap; } }
        public bool IsMinHeap { get { return !_isMaxHeap; } }

        public bool IsHeapOrder { get { return HeapSize == Size; } }
        public bool IsSortOrder { get { return !IsHeapOrder; } }

        public int HeapSize { get { return _heapSize; } }
        public int Size { get { return _end + 1; } }
        public bool IsEmpty { get { return Size == 0; } }
        public int Capacity { get { return _items.Length; } }

        public void Push(T item)
        {
            if (Size == _items.Length)
            {
                Resize();
            }

            if (Size != HeapSize)
            {
                Heapify();
            }

            _items[++_end] = item;
            _heapSize = Size;
            SiftUp();
        }

        public T Peek()
        {
            if (IsEmpty) { throw new ArgumentOutOfRangeException(); }
            return _items[0];
        }

        public T Pop()
        {
            if (IsEmpty) { throw new ArgumentOutOfRangeException(); }

            if (Size != HeapSize)
            {
                Heapify();
            }

            T item = _items[0];
            _items[0] = _items[_end];
            _items[_end--] = item;
            _heapSize = Size;

            SiftDown();
            return item;
        }

        public T[] ExportArray()
        {
            if (Size == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T[] a = new T[Size];

            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = _items[i];
            }

            return a;
        }

        public void Sort()
        {
            if (Size != HeapSize)
            {
                return;
            }

            int size = Size;

            for (int i = 0; i < size; ++i)
            {
                Pop();
            }

            _end = size - 1;
        }

        public void Heapify()
        {
            int size = Size;
            _end = -1;
            _heapSize = Size;

            for (int i = 0; i < size; ++i)
            {
                Push(_items[i]);
            }
        }

        public void ReHeapifyMax(T[] a)
        {
            ReHeapify(a, true);
        }

        public void ReHeapifyMin(T[] a)
        {
            ReHeapify(a, false);
        }

        private void ReHeapify(T[] a, bool isMaxHeap)
        {
            _items = new T[a.Length];

            for (int i = 0; i < a.Length; ++i)
            {
                _items[i] = a[i];
            }

            _isMaxHeap = isMaxHeap;
            _end = a.Length - 1;
            _heapSize = 0;
            Heapify();
        }

        private void Resize()
        {
            T[] a = new T[_items.Length * 2];

            for (int i = 0; i < Size; ++i)
            {
                a[i] = _items[i];
            }

            _items = a;
        }

        private void SiftUp()
        {
            int current = _end;
            int father = (_end - 1) / 2;

            while (father >= 0 && CheckSiftUp(_items[current], _items[father]))
            {
                T temp = _items[father];
                _items[father] = _items[current];
                _items[current] = temp;
                current = father;
                father = (current - 1) / 2;
            }
        }

        private bool CheckSiftUp(T current, T father)
        {
            if (IsMaxHeap) { return current.CompareTo(father) > 0; }
            else { return current.CompareTo(father) < 0; }
        }

        private void SiftDown()
        {
            int current = 0;
            int left = current * 2 + 1;
            int right = left + 1;

            while (left < HeapSize)
            {
                int greaterOrLesser;

                if (HeapSize - left == 1)
                {
                    greaterOrLesser = left;
                } else
                {
                    greaterOrLesser = GetGreaterOrLesser(_items[left], _items[right], left, right);
                }

                if (CheckSiftDown(_items[current], _items[greaterOrLesser]))
                {
                    T temp = _items[greaterOrLesser];
                    _items[greaterOrLesser] = _items[current];
                    _items[current] = temp;
                } else
                {
                    return;
                }

                current = greaterOrLesser;
                left = current * 2 + 1;
                right = left + 1;
            }
        }

        private int GetGreaterOrLesser(T leftItem, T rightItem, int leftIndex, int rightIndex)
        {
            if (IsMaxHeap) { return (leftItem.CompareTo(rightItem) >= 0) ? leftIndex : rightIndex; }
            else { return (leftItem.CompareTo(rightItem) <= 0) ? leftIndex : rightIndex; }
        }

        private bool CheckSiftDown(T current, T greater)
        {
            if (IsMaxHeap) { return current.CompareTo(greater) < 0; }
            else { return current.CompareTo(greater) > 0; }
        }
    }
}
