using DataStructures.Lists;
using System;


namespace DataStructures.Trees
{
    public class BinarySearchTree<T> : System.Collections.IEnumerable where T : IComparable
    {
        private INode<T> _root;

        private Random rnd;

        public INode<T> Root { get { return _root; } }

        public BinarySearchTree() { rnd = new Random(); }

        public bool Search(T item) { return Search(Root, item); }

        public void Insert(T item)
        {
            if (Root == null)
            {
                _root = new BstNode<T>(item);
            }
            else
            {
                Insert(Root, item);
            }
        }
        
        public bool Remove(T item) { return Remove(Root, item); }

        public System.Collections.IEnumerator GetEnumerator()
        {
            INode<T> node = Root;
            var s = new Stack<INode<T>>();

            while (node != null || !s.IsEmpty)
            {
                if (node != null)
                {
                    s.Push(node);
                    node = node.Left;
                }

                if (node == null && !s.IsEmpty)
                {
                    node = s.Pop();

                    T item = node.Item;
                    node = node.Right;
                    yield return item;
                }
            }
        }

        private bool Search(INode<T> node, T item)
        {
            if (node == null)
            {
                return false;
            }
            else if (item.CompareTo(node.Item) < 0)
            {
                return Search(node.Left, item);
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                return Search(node.Right, item);
            }
            else
            {
                return true;

            }
        }

        private void Insert(INode<T> node, T item)
        {
            if (item.CompareTo(node.Item) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BstNode<T>(item);
                }
                else
                {
                    Insert(node.Left, item);
                }
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new BstNode<T>(item);
                }
                else
                {
                    Insert(node.Right, item);
                }
            }
        }

        private INode<T> FindPredecessor(INode<T> node)
        {
            INode<T> temp = null;

            if (node != null && node.Left != null)
            {
                temp = node.Left;
                while (temp.Right != null)
                {
                    temp = temp.Right;
                }
            }

            return temp;
        }

        private INode<T> FindSuccessor(INode<T> node)
        {
            INode<T> temp = null;

            if (node != null && node.Right != null)
            {
                temp = node.Right;
                while (temp.Left != null)
                {
                    temp = temp.Left;
                }
            }

            return temp;
        }
        
        private bool Remove(INode<T> node, T item)
        {
            if (node == null) { return false; }

            if (item.CompareTo(node.Item) == 0)
            {
                if (node.Left == null && node.Right == null)
                {
                    _root = null;
                }
                else if (node.Left == null)
                {
                    _root = node.Right;
                }
                else if (node.Right == null)
                {
                    _root = node.Left;
                }
                else
                {
                    INode<T> predOrSucc = (rnd.Next(2) == 0) ? FindPredecessor(Root) : FindSuccessor(Root);
                    Remove(Root, predOrSucc.Item);
                    Root.Item = predOrSucc.Item;
                }
                return true;
            }
            else if (item.CompareTo(node.Item) < 0)
            {
                if (node.Left != null && item.CompareTo(node.Left.Item) == 0)
                {
                    if (node.Left.Left == null && node.Left.Right == null)
                    {
                        node.Left = null;
                    }
                    else if (node.Left.Left == null)
                    {
                        node.Left = node.Left.Right;
                    }
                    else if (node.Left.Right == null)
                    {
                        node.Left = node.Left.Left;
                    }
                    else
                    {
                        INode<T> predOrSucc = (rnd.Next(2) == 0) ? FindPredecessor(node.Left) : FindSuccessor(node.Left);
                        Remove(node.Left, predOrSucc.Item);
                        node.Left.Item = predOrSucc.Item;
                    }
                    return true;
                }

                return Remove(node.Left, item);
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                if (node.Right != null && item.CompareTo(node.Right.Item) == 0)
                {
                    if (node.Right.Left == null && node.Right.Right == null)
                    {
                        node.Right = null;
                    }
                    else if (node.Right.Left == null)
                    {
                        node.Right = node.Right.Right;
                    }
                    else if (node.Right.Right == null)
                    {
                        node.Right = node.Right.Left;
                    }
                    else
                    {
                        INode<T> predOrSucc = (rnd.Next(2) == 0) ? FindPredecessor(node.Right) : FindSuccessor(node.Right);
                        Remove(node.Right, predOrSucc.Item);
                        node.Right.Item = predOrSucc.Item;
                    }
                    return true;
                }

                return Remove(node.Right, item);
            }
            else
            {
                return false;
            }
        }
    }

    public class BstNode<T> : INode<T>
    {
        public INode<T> Left { get; set;}
        public INode<T> Right { get; set; }
        public T Item { get; set; }

        public BstNode() { }
        public BstNode(T item) { Item = item; }
    }
}
