using Algorithms.Concurrency;
using Algorithms.Graphs;
using Algorithms.Math;
using Algorithms.Searching;
using Algorithms.Sorting;
using Algorithms.Strings;
using Algorithms.Trees;
using DataStructures.Lists;
using DataStructures.Trees;
using DSA.Common;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting algorithm program");

            var tree = new AvlTree<int>();
            tree.Insert(11);
            tree.Insert(7);
            tree.Insert(12);
            tree.Insert(2);
            tree.Insert(8);
            tree.Insert(13);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(4);

            PrettyPrintTree<int>.Print(tree.Root);

            tree.Remove(12);

            PrettyPrintTree<int>.Print(tree.Root);

            var pol = TreeOperationsRecur<int>.PreOrderTraversal(tree.Root);

            foreach (var i in pol)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            Console.WriteLine("finished algorithm program");
            Console.Read();
        }
    }
}
