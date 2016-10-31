using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Searching.Tests
{
    [TestClass()]
    public class BinarySearchTests
    {
        [TestMethod()]
        public void IndexOfTest()
        {
            int[] a = new int[] { 1, 2, 3, 4 };
            int index = BinarySearch.IndexOf(a, 6);
            Assert.AreEqual(-1, index);
            index = BinarySearch.IndexOf(a, 1);
            Assert.AreEqual(0, index);
            index = BinarySearch.IndexOf(a, 4);
            Assert.AreEqual(3, index);
            index = BinarySearch.IndexOf(a, 3);
            Assert.AreEqual(2, index);

            a = new int[] { 1, 2, 3 };
            index = BinarySearch.IndexOf(a, 6);
            Assert.AreEqual(-1, index);
            index = BinarySearch.IndexOf(a, 1);
            Assert.AreEqual(0, index);
            index = BinarySearch.IndexOf(a, 3);
            Assert.AreEqual(2, index);
            index = BinarySearch.IndexOf(a, 2);
            Assert.AreEqual(1, index);

            a = new int[] { 1, 2 };
            index = BinarySearch.IndexOf(a, 6);
            Assert.AreEqual(-1, index);
            index = BinarySearch.IndexOf(a, 1);
            Assert.AreEqual(0, index);
            index = BinarySearch.IndexOf(a, 2);
            Assert.AreEqual(1, index);

            a = new int[] { 1 };
            index = BinarySearch.IndexOf(a, 6);
            Assert.AreEqual(-1, index);
            index = BinarySearch.IndexOf(a, 1);
            Assert.AreEqual(0, index);
        }

        [TestMethod()]
        public void IndexOfRecurTest()
        {
            int[] a = new int[] { 1, 2, 3, 4 };
            int index = BinarySearch.IndexOfRecur(a, 6);
            Assert.AreEqual(-1, index);
            index = BinarySearch.IndexOfRecur(a, 1);
            Assert.AreEqual(0, index);
            index = BinarySearch.IndexOfRecur(a, 4);
            Assert.AreEqual(3, index);
            index = BinarySearch.IndexOfRecur(a, 3);
            Assert.AreEqual(2, index);

            a = new int[] { 1, 2, 3 };
            index = BinarySearch.IndexOfRecur(a, 6);
            Assert.AreEqual(-1, index);
            index = BinarySearch.IndexOfRecur(a, 1);
            Assert.AreEqual(0, index);
            index = BinarySearch.IndexOfRecur(a, 3);
            Assert.AreEqual(2, index);
            index = BinarySearch.IndexOfRecur(a, 2);
            Assert.AreEqual(1, index);

            a = new int[] { 1, 2 };
            index = BinarySearch.IndexOfRecur(a, 6);
            Assert.AreEqual(-1, index);
            index = BinarySearch.IndexOfRecur(a, 1);
            Assert.AreEqual(0, index);
            index = BinarySearch.IndexOfRecur(a, 2);
            Assert.AreEqual(1, index);

            a = new int[] { 1 };
            index = BinarySearch.IndexOfRecur(a, 6);
            Assert.AreEqual(-1, index);
            index = BinarySearch.IndexOfRecur(a, 1);
            Assert.AreEqual(0, index);
        }
    }
}