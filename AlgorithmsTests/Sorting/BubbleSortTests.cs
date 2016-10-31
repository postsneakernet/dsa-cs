using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting;
using DSA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting.Tests
{
    [TestClass()]
    public class BubbleSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            int[] a = Helpers.BuildRandomArray(50);
            BubbleSort.Sort(a);

            for (int i = 1; i < a.Length; ++i)
            {
                Console.WriteLine("a[{0}]: {1}, a[{2}]: {3}", i - 1, a[i - 1], i, a[i]);
                Assert.IsTrue(a[i - 1] <= a[i]);
            }
        }
    }
}