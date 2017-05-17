using DataStructures.Trees;
using DataStructures.Lists;
using Algorithms.Trees;
using System;

namespace Algorithms.Trees
{
    public class TreeOperationsIter<T> where T : IComparable
    {
        public static IList<T> LevelOrderTraversalAsPbt(INode<T> node)
        {
            var pbt = new ArrayList<T>();
            var q = new Queue<INode<T>>();
            q.Enqueue(node);
            int height = TreeOperationsRecur<T>.Height(node);

            while (!q.IsEmpty && height >= 0)
            {
                --height;
                int level = q.Size;

                while (level > 0)
                {
                    --level;
                    INode<T> n = q.Dequeue();

                    if (n != null)
                    {
                        pbt.Add(n.Item);
                        q.Enqueue(n.Left);
                        q.Enqueue(n.Right);
                    }
                    else
                    {
                        pbt.Add(default(T));
                        q.Enqueue(null);
                        q.Enqueue(null);
                    }
                }
            }

            return pbt;
        } 
    }
}
