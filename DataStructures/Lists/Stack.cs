using System;

namespace DataStructures.Lists
{
    public class Stack<T>
    {
        private const int _capacity = 10;
        private T[] _items;
        private int _top;
        private bool _isFixedSize;

        public int Size { get { return _top + 1; } }
        public bool IsEmpty { get { return Size == 0; } }
        public bool IsFull { get { return _isFixedSize && Size == _items.Length; } }

        public Stack() : this(_capacity, false) { }

        public Stack(int capacity, bool isFixedSize)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _items = new T[capacity];
            _top = -1;
            _isFixedSize = isFixedSize;
        }

        public static Stack<T> CreateFixedStack(int capacity = _capacity)
        {
            return new Stack<T>(capacity, true);
        }

        public static Stack<T> CreateDynamicStack(int capacity = _capacity)
        {
            return new Stack<T>(capacity, false);
        }

        public void Push(T item)
        {
            if (Size == _items.Length && _isFixedSize)
            {
                throw new StackIsFullException("Stack is full, cannot push item");
            }
            else if (Size == _items.Length)
            {
                Resize();
            }

            _items[++_top] = item;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new StackIsEmptyException("Stack is empty, nothing to peek");
            }

            return _items[_top];
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new StackIsEmptyException("Stack is empty, nothing to pop");
            }

            return _items[_top--];
        }

        private void Resize()
        {
            T[] a = new T[_items.Length * 2];

            for (int i = 0; i < _items.Length; ++i)
            {
                a[i] = _items[i];
            }

            _items = a;
        }
    }

    public class StackIsFullException : Exception
    {
        public StackIsFullException() { }

        public StackIsFullException(string message) : base(message) { }

        public StackIsFullException(string message, Exception inner) : base(message, inner) { }
    }

    public class StackIsEmptyException : Exception
    {
        public StackIsEmptyException() { }

        public StackIsEmptyException(string message) : base(message) { }

        public StackIsEmptyException(string message, Exception inner) : base(message, inner) { }
    }
}
