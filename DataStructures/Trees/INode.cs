using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public interface INode<T>
    {
        INode<T> Left { get; set; }
        INode<T> Right { get; set; }
        T Item { get; set; }
    }

    public class BstNode<T> : INode<T>
    {
        public INode<T> Left { get; set; }
        public INode<T> Right { get; set; }
        public T Item { get; set; }

        public BstNode() { }
        public BstNode(T item) { Item = item; }
    }

    public class AvlNode<T> : INode<T>
    {
        public AvlNode<T> AvlLeft { get; set; }
        public AvlNode<T> AvlRight { get; set; }

        public INode<T> Left
        {
            get { return AvlLeft; }
            set { AvlLeft = (AvlNode<T>) value; }
        }

        public INode<T> Right
        {
            get { return AvlRight; }
            set { AvlRight = (AvlNode<T>) value; }
        }

        public T Item { get; set; }
        public int Height { get; set; }

        public AvlNode() { }
        public AvlNode(T item)
        {
            Item = item;
            Height = 1;
        }
    }

    public class NodeFactory<T>
    {
        public static INode<T> GetNodeImplementation(String treeType, T item)
        {
            if (treeType == "avl")
            {
                return new AvlNode<T>(item);
            }
            else
            {
                return new BstNode<T>(item);
            }
        }
    }
}
