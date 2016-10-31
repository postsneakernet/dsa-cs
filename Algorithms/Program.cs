using Algorithms.Concurrency;
using Algorithms.Graphs;
using Algorithms.Math;
using Algorithms.Searching;
using Algorithms.Sorting;
using Algorithms.Strings;
using Algorithms.Trees;
using DSA.Common;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting algorithm program");

            int[] a = Helpers.BuildEvenArray(1);
            BinarySearch.IndexOf(a, 4);
            
            Console.WriteLine("finished algorithm program");
            Console.Read();
        }
    }
}
