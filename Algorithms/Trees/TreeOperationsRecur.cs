using DataStructures.Trees;
using DataStructures.Lists;
using System;

namespace Algorithms.Trees
{
    public class TreeOperationsRecur<T> where T : IComparable
    {
        public static ArrayList<T> InOrderTraversal(INode<T> node)
        {
            var list = new ArrayList<T>();
            InOrderTraversal(node, list);
            return list;
        }

        private static void InOrderTraversal(INode<T> node, ArrayList<T> list)
        {
            if (node == null) { return; }
            InOrderTraversal(node.Left, list);
            list.Add(node.Item);
            InOrderTraversal(node.Right, list);
        }

        public static ArrayList<T> PreOrderTraversal(INode<T> node)
        {
            var list = new ArrayList<T>();
            PreOrderTraversal(node, list);
            return list;
        }

        private static void PreOrderTraversal(INode<T> node, ArrayList<T> list)
        {
            if (node == null) { return; }
            list.Add(node.Item);
            PreOrderTraversal(node.Left, list);
            PreOrderTraversal(node.Right, list);
        }

        public static ArrayList<T> PostOrderTraversal(INode<T> node)
        {
            var list = new ArrayList<T>();
            PostOrderTraversal(node, list);
            return list;
        }

        private static void PostOrderTraversal(INode<T> node, ArrayList<T> list)
        {
            if (node == null) { return; }
            PreOrderTraversal(node.Left, list);
            PreOrderTraversal(node.Right, list);
            list.Add(node.Item);
        }

        public static ArrayList<T> LevelOrderTraversal(INode<T> node)
        {
            throw new NotImplementedException();
            return null;
        }

        public static int Height(INode<T> node)
        {
            if (node == null) { return -1; }

            return System.Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        public static int Depth(INode<T> root, T item)
        {
            if (root == null) { return -1; }

            if (item.CompareTo(root.Item) < 0)
            {
                int result = Depth(root.Left, item);
                return (result > -1) ? result + 1 : -1;
            }
            else if (item.CompareTo(root.Item) > 0)
            {
                int result = Depth(root.Right, item);
                return (result > -1) ? result + 1 : -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
