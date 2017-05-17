using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA.Common;
using System;

namespace Algorithms.Sorting.Tests
{
    [TestClass()]
    public class MergeSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            int[] a = Helpers.BuildRandomArray(30);
            Helpers.PrintArray(a);
            MergeSort.Sort(a);
            Helpers.PrintArray(a);

            for (int i = 1; i < a.Length; ++i)
            {
                Console.WriteLine("a[{0}]: {1}, a[{2}]: {3}", i - 1, a[i - 1], i, a[i]);
                Assert.IsTrue(a[i - 1] <= a[i]);
            }
        }
    }
}