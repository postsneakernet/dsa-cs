using System;
using System.Collections;

namespace DataStructures.Lists
{
    public class LinkedList<T> : IList<T>
    {
        private Node<T> _head;

        public int Size { get { return GetSize(); } }

        public LinkedList() { }

        public static LinkedList<T> ShallowListCopy(IList<T> originalList)
        {
            LinkedList<T> list = new LinkedList<T>();
            foreach (T item in originalList)
            {
                list.Add(item);
            }
            return list;
        }

        public T Get(int index)
        {
            Node<T> temp = _head;

            if (index < 0 || temp == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0)
            {
                return temp.Item;
            }

            while (index > 0 && temp != null)
            {
                temp = temp.Next;
                --index;
            }

            if (index == 0 && temp != null)
            {
                return temp.Item;
            } else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public T GetFront()
        {
            Node<T> temp = _head;

            if (temp == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return temp.Item;
        }

        public T GetBack()
        {
            Node<T> temp = _head;

            if (temp == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            return temp.Item;
        }

        public void Add(T item)
        {
            Node<T> n = new Node<T>(item);

            if (_head == null)
            {
                _head = n;
                return;
            }

            Node<T> temp = _head;

            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = n;
        }

        public void AddFront(T item)
        {
            Node<T> n = new Node<T>(item);
            n.Next = _head;
            _head = n;
        }

        public void AddAt(int index, T item)
        {
            Node<T> n = new Node<T>(item);

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            } else if (index == 0)
            {
                AddFront(item);
                return;
            }

            Node<T> temp = _head;

            while (index > 1 && temp.Next != null)
            {
                temp = temp.Next;
                --index;
            }

            if (index == 1 && temp != null)
            {
                n.Next = temp.Next;
                temp.Next = n;
            } else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public T Remove()
        {
            T item;
            Node<T> temp = _head;

            if (temp == null)
            {
                throw new ArgumentOutOfRangeException();
            } else if (temp.Next == null)
            {
                item = temp.Item;
                _head = null;
                return item;
            }

            while (temp.Next != null && temp.Next.Next != null)
            {
                temp = temp.Next;
            }

            item = temp.Next.Item;
            temp.Next = null;

            return item;
        }

        public T RemoveFront()
        {
            T item;
            Node<T> temp = _head;

            if (temp == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            item = temp.Item;
            _head = temp.Next;

            return item;
        }

        public T RemoveAt(int index)
        {
            T item;
            Node<T> temp = _head;

            if (temp == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0)
            {
                return RemoveFront();
            }

            while (index > 1 && temp.Next != null)
            {
                temp = temp.Next;
                --index;
            }

            if (index == 1 && temp.Next != null)
            {
                item = temp.Next.Item;
                temp.Next = temp.Next.Next;
                return item;
            } else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int FindFirstOccurrence(T item)
        {
            int index = -1;

            /*
            for (int i = 0; i < Size; ++i)
            {
                if (_items[i].CompareTo(item) == 0)
                {
                    index = i;
                    break;
                }
            }
            */
            throw new NotImplementedException();

            return index;
        }

        public void Reverse()
        {
            if (_head == null || _head.Next == null) { return; }

            Node<T> curr = _head;
            Node<T> prev = null;
            Node<T> next = curr.Next;

            while (next != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            _head = prev;
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> temp = _head;

            while (temp != null)
            {
                T item = temp.Item;
                temp = temp.Next;
                yield return item;
            }
        }

        private int GetSize()
        {
            int count = 0;

            Node<T> temp = _head;

            while (temp != null)
            {
                temp = temp.Next;
                ++count;
            }

            return count;
        }
    }

    class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        public Node() { }

        public Node(T item)
        {
            Item = item;
        }

        public Node(T item, Node<T> next)
        {
            Item = item;
            Next = next;
        }
    }
}
