using System;
using System.Collections;

namespace DataStructures.Lists
{
    public class Queue<T>
    {
        private const int _capacity = 10;
        private int _front; // index of next to pop
        private int _back; // index of next to push
        private T[] _items;

        public int Size { get { return _back - _front; } }
        public bool IsEmpty { get { return _front == _back; } }

        public Queue(int capacity = _capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _items = new T[capacity];
            _front = 0;
            _back = 0;
        }

        public void Enqueue(T item)
        {
            if (Size == _items.Length || _back == _items.Length)
            {
                Resize();
            }

            _items[_back++] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new QueueIsEmptyException();
            }

            return _items[_front++];
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new QueueIsEmptyException();
            }

            return _items[_front];
        }

        private void Resize()
        {
            if (IsEmpty)
            {
                _front = 0;
                _back = 0;
            } else if (Size != _items.Length)
            {
                ShiftLeft(_items);
            } else
            {
                ShiftLeft(new T[_items.Length * 2]);
            }
        }

        private void ShiftLeft(T[] dst)
        {
            for (int i = _front; i < _back; ++i)
            {
                dst[i - _front] = _items[i];
            }

            _items = dst;
            _back = _back - _front;
            _front = 0;
        }
    }

    public class QueueIsEmptyException : Exception
    {
        public QueueIsEmptyException() { }

        public QueueIsEmptyException(string message) : base(message) { }

        public QueueIsEmptyException(string message, Exception inner) : base(message, inner) { }
    }
}
