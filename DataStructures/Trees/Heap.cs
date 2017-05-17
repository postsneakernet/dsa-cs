using System;

namespace DataStructures.Trees
{
    public class Heap
    {
        private const int _capacity = 10;
        private int[] _items;
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

            _items = new int[capacity];
            _isMaxHeap = isMaxHeap;
            _end = -1;
            _heapSize = 0;
        }

        public Heap(int[] a, bool isMaxHeap)
        {
            ReHeapify(a, isMaxHeap);
        }

        public static Heap CreateMaxHeap(int capacity = _capacity) { return new Heap(capacity, true); }
        public static Heap CreateMinHeap(int capacity = _capacity) { return new Heap(capacity, false); }

        public static Heap MaxHeapify(int[] a) { return new Heap(a, true); }
        public static Heap MinHeapify(int[] a) { return new Heap(a, false); }

        public bool IsMaxHeap { get { return _isMaxHeap; } }
        public bool IsMinHeap { get { return !_isMaxHeap; } }

        public bool IsHeapOrder { get { return HeapSize == Size; } }
        public bool IsSortOrder { get { return !IsHeapOrder; } }

        public int HeapSize { get { return _heapSize; } }
        public int Size { get { return _end + 1; } }
        public bool IsEmpty { get { return Size == 0; } }
        public int Capacity { get { return _items.Length; } }

        public void Push(int item)
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

        public int Peek()
        {
            if (IsEmpty) { throw new ArgumentOutOfRangeException(); }
            return _items[0];
        }

        public int Pop()
        {
            if (IsEmpty) { throw new ArgumentOutOfRangeException(); }

            if (Size != HeapSize)
            {
                Heapify();
            }

            int item = _items[0];
            _items[0] = _items[_end];
            _items[_end--] = item;
            _heapSize = Size;

            SiftDown();
            return item;
        }

        public int[] ExportArray()
        {
            if (Size == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] a = new int[Size];

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

        public void ReHeapifyMax(int[] a)
        {
            ReHeapify(a, true);
        }

        public void ReHeapifyMin(int[] a)
        {
            ReHeapify(a, false);
        }

        private void ReHeapify(int[] a, bool isMaxHeap)
        {
            _items = new int[a.Length];

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
            int[] a = new int[_items.Length * 2];

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
                int temp = _items[father];
                _items[father] = _items[current];
                _items[current] = temp;
                current = father;
                father = (current - 1) / 2;
            }
        }

        private bool CheckSiftUp(int current, int father)
        {
            if (IsMaxHeap) { return current > father; }
            else { return current < father; }
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
                    int temp = _items[greaterOrLesser];
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

        private int GetGreaterOrLesser(int leftItem, int rightItem, int leftIndex, int rightIndex)
        {
            if (IsMaxHeap) { return (leftItem >= rightItem) ? leftIndex : rightIndex; }
            else { return (leftItem <= rightItem) ? leftIndex : rightIndex; }
        }

        private bool CheckSiftDown(int current, int greater)
        {
            if (IsMaxHeap) { return current < greater; }
            else { return current > greater; }
        }
    }
}
