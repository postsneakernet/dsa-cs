using DataStructures.Maps;
using System;

namespace DataStructures.Trees
{
    public class AvlTree<T> : BinarySearchTree<T> where T : IComparable
    {
        public AvlTree() : base("avl") { }

        public static new AvlTree<T> ShallowSetCopy(ISet<T> originalSet)
        {
            AvlTree<T> set = new AvlTree<T>();
            foreach (T item in originalSet)
            {
                set.Insert(item);
            }
            return set;
        }

        public override void Insert(T item)
        {
            _root = Insert(Root, item);
        }

        private INode<T> Insert(INode<T> node, T item)
        {
            if (node == null)
            {
                node = GetNodeImplementation(item);
                return node;
            }
            else if (item.CompareTo(node.Item) < 0)
            {
                node.Left = Insert(node.Left, item);
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                node.Right = Insert(node.Right, item);
            }
            else
            {
                return node;
            }

            AvlNode<T> avlNode = ((AvlNode<T>) node);
            AdjustHeight(avlNode);
            int balance = GetBalance(avlNode);
            return CheckCasesInsert(balance, avlNode, item);
        }

        public override bool Remove(T item)
        {
            bool[] result = { false };
            _root = Remove(Root, item, result);
            return result[0];
        }

        private INode<T> Remove(INode<T> node, T item, bool[] result)
        {
            if (node == null)
            {
                return node;
            }
            else if (item.CompareTo(node.Item) < 0)
            {
                node.Left = Remove(node.Left, item, result);
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                node.Right = Remove(node.Right, item, result);
            }
            else
            {
                result[0] = true;

                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    INode<T> succ = FindSuccessor(node);
                    node.Item = succ.Item;
                    node.Right = Remove(node.Right, succ.Item, result);
                }
            }

            AvlNode<T> avlNode = (AvlNode<T>) node;
            AdjustHeight(avlNode);
            int balance = GetBalance(avlNode);
            return CheckCasesRemove(balance, avlNode);
        }

        private int GetHeight(AvlNode<T> node)
        {
            if (node == null) { return 0; }

            return node.Height;
        }

        private void AdjustHeight(AvlNode<T> node)
        {
            node.Height = System.Math.Max(GetHeight(node.AvlLeft), GetHeight(node.AvlRight)) + 1;
        }

        private int GetBalance(AvlNode<T> node)
        {
            return GetHeight(node.AvlLeft) - GetHeight(node.AvlRight);
        }

        private INode<T> CheckCasesInsert(int balance, AvlNode<T> avlNode, T item)
        {
            if (balance > 1 && item.CompareTo(avlNode.Left.Item) < 0) // left left case
            {
                Console.WriteLine("left left case");
                return RightRotate(avlNode);
            }
            else if (balance < -1 && item.CompareTo(avlNode.Right.Item) > 0) // right right case
            {
                Console.WriteLine("right right case");
                return LeftRotate(avlNode);
            }
            else if (balance > 1 && item.CompareTo(avlNode.Left.Item) > 0) // left right case
            {
                Console.WriteLine("left right case");
                avlNode.Left = LeftRotate(avlNode.AvlLeft);
                return RightRotate(avlNode);
            }
            else if (balance < -1 && item.CompareTo(avlNode.Right.Item) < 0) // right left case
            {
                Console.WriteLine("right left case");
                avlNode.Right = RightRotate(avlNode.AvlRight);
                return LeftRotate(avlNode);
            }
            else
            {
                return avlNode;
            }
        }

        private INode<T> CheckCasesRemove(int balance, AvlNode<T> avlNode)
        {
            if (balance > 1 && GetBalance(avlNode.AvlLeft) >= 0) // left left case
            {
                Console.WriteLine("left left case");
                return RightRotate(avlNode);
            }
            else if (balance < -1 && GetBalance(avlNode.AvlRight) <= 0) // right right case
            {
                Console.WriteLine("right right case");
                return LeftRotate(avlNode);
            }
            else if (balance > 1 && GetBalance(avlNode.AvlLeft) < 0) // left right case
            {
                Console.WriteLine("left right case");
                avlNode.Left = LeftRotate(avlNode.AvlLeft);
                return RightRotate(avlNode);
            }
            else if (balance < -1 && GetBalance(avlNode.AvlRight) > 0) // right left case
            {
                Console.WriteLine("right left case");
                avlNode.Right = RightRotate(avlNode.AvlRight);
                return LeftRotate(avlNode);
            }
            else
            {
                return avlNode;
            }
        }

        private AvlNode<T> LeftRotate(AvlNode<T> x)
        {
            AvlNode<T> y = x.AvlRight;
            AvlNode<T> t2 = y.AvlLeft;

            y.AvlLeft = x;
            x.AvlRight = t2;

            AdjustHeight(x);
            AdjustHeight(y);

            return y;
        }

        private AvlNode<T> RightRotate(AvlNode<T> y)
        {
            AvlNode<T> x = y.AvlLeft;
            AvlNode<T> t2 = x.AvlRight;

            x.AvlRight = y;
            y.AvlLeft = t2;

            AdjustHeight(y);
            AdjustHeight(x);

            return x;
        }
    }
}
