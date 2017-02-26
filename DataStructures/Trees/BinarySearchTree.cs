using DataStructures.Lists;
using System;


namespace DataStructures.Trees
{
    public class BinarySearchTree<T> : System.Collections.IEnumerable where T : IComparable
    {
        protected INode<T> _root;

        private Random rnd;

        private string _treeType;

        private bool _reversed;

        public INode<T> Root { get { return _root; } }

        public bool IsReversed { get { return _reversed; } }

        public BinarySearchTree() : this("bst") { }

        public BinarySearchTree(string treeType)
        {
            _treeType = treeType;
            rnd = new Random();
        }

        protected INode<T> GetNodeImplementation(T item)
        {
            return NodeFactory<T>.GetNodeImplementation(_treeType, item);
        }

        public bool Search(T item) { return Search(Root, item); }

        public virtual void Insert(T item)
        {
            if (Root == null)
            {
                _root = GetNodeImplementation(item);
            }
            else
            {
                Insert(Root, item);
            }
        }
        
        public virtual bool Remove(T item) { return Remove(Root, item); }

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

        public T FindMin()
        {
            INode<T> temp = FindMinNode(_root);
            return (temp != null) ? temp.Item : default(T);
        }

        protected INode<T> FindMinNode(INode<T> node)
        {
            while (node != null && node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public T FindMax()
        {
            INode<T> temp = FindMaxNode(_root);
            return (temp != null) ? temp.Item : default(T);
        }

        protected INode<T> FindMaxNode(INode<T> node)
        {
            while (node != null && node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }

        private void Insert(INode<T> node, T item)
        {
            if (item.CompareTo(node.Item) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = GetNodeImplementation(item);
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
                    node.Right = GetNodeImplementation(item);
                }
                else
                {
                    Insert(node.Right, item);
                }
            }
        }

        protected INode<T> FindPredecessor(INode<T> node)
        {
            INode<T> temp = null;

            if (node != null)
            {
                temp = FindMaxNode(node.Left);
            }

            return temp;
        }

        protected INode<T> FindSuccessor(INode<T> node)
        {
            INode<T> temp = null;

            if (node != null)
            {
                temp = FindMinNode(node.Right);
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

        public void Reverse()
        {
            _reversed = !_reversed;
            Reverse(_root);
        }

        private void Reverse(INode<T> node)
        {
            if (node == null)
            {
                return;
            }

            INode<T> temp = node.Left;
            node.Left = node.Right;
            node.Right = temp;

            Reverse(node.Left);
            Reverse(node.Right);
        }
    }
}
