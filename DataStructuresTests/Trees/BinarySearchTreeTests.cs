using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Trees;
using DataStructures.Lists;
using System;

namespace DataStructures.Trees.Tests
{
    [TestClass()]
    public class BinarySearchTreeTests
    {
        BinarySearchTree<int> tree;

        [TestInitialize()]
        public void TestInit()
        {
            tree = new BinarySearchTree<int>();
        }

        [TestMethod()]
        public void SearchTest()
        {
            Assert.IsTrue(tree.Search(2) == false);

            tree.Insert(5);
            Assert.IsTrue(tree.Search(5) == true);

            Assert.IsTrue(tree.Search(2) == false);

            tree.Insert(2);
            Assert.IsTrue(tree.Search(2) == true);

            tree.Insert(9);
            Assert.IsTrue(tree.Search(9) == true);

            tree.Insert(1);
            Assert.IsTrue(tree.Search(1) == true);

            tree.Insert(3);
            Assert.IsTrue(tree.Search(3) == true);

            tree.Insert(10);
            Assert.IsTrue(tree.Search(10) == true);

            tree.Insert(7);
            Assert.IsTrue(tree.Search(7) == true);
        }

        [TestMethod()]
        public void InsertTest()
        {
            int[] seed = { 5, 3, 9, 1, 2 };

            foreach (int i in seed)
            {
                tree.Insert(i);
            }

            tree.Insert(5);

            var inOrder = new ArrayList<int>();

            foreach (int i in tree)
            {
                inOrder.Add(i);
            }

            Assert.AreEqual(seed.Length, inOrder.Size);

            for (int i = 1; i < inOrder.Size; ++i)
            {
                Console.WriteLine("a[{0}]: {1}, a[{2}]: {3}", i - 1, inOrder.Get(i - 1), i, inOrder.Get(i));
                Assert.IsTrue(inOrder.Get(i - 1) <= inOrder.Get(i));
            }
        }

        [TestMethod()]
        public void RemoveTest()
        {
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(9);

            tree.Remove(9);

            var inOrder = new ArrayList<int>();

            foreach (int i in tree)
            {
                inOrder.Add(i);
            }

            Assert.AreEqual(3, inOrder.Size);

            tree.Remove(9);

            inOrder = new ArrayList<int>();

            foreach (int i in tree)
            {
                inOrder.Add(i);
            }

            tree.Remove(5);

            inOrder = new ArrayList<int>();

            foreach (int i in tree)
            {
                inOrder.Add(i);
            }

            Assert.AreEqual(2, inOrder.Size);

            for (int i = 1; i < inOrder.Size; ++i)
            {
                Console.WriteLine("a[{0}]: {1}, a[{2}]: {3}", i - 1, inOrder.Get(i - 1), i, inOrder.Get(i));
                Assert.IsTrue(inOrder.Get(i - 1) <= inOrder.Get(i));
            }
        }

        [TestMethod()]
        public void FindMinTest()
        {
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(1);
            tree.Insert(6);

            Assert.AreEqual(1, tree.FindMin());
        }

        [TestMethod()]
        public void FindMaxTest()
        {
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(1);
            tree.Insert(6);

            Assert.AreEqual(9, tree.FindMax());
        }

        [TestMethod()]
        public void ReverseTest()
        {
            int[] seed = { 5, 3, 9, 1, 2 };

            foreach (int i in seed)
            {
                tree.Insert(i);
            }

            Assert.IsFalse(tree.IsReversed);
            tree.Reverse();
            Assert.IsTrue(tree.IsReversed);

            var inOrder = new ArrayList<int>();

            foreach (int i in tree)
            {
                inOrder.Add(i);
            }

            for (int i = 1; i < inOrder.Size; ++i)
            {
                Console.WriteLine("a[{0}]: {1}, a[{2}]: {3}", i - 1, inOrder.Get(i - 1), i, inOrder.Get(i));
                Assert.IsTrue(inOrder.Get(i - 1) >= inOrder.Get(i));
            }

            tree.Reverse();
            Assert.IsFalse(tree.IsReversed);

            inOrder = new ArrayList<int>();

            foreach (int i in tree)
            {
                inOrder.Add(i);
            }

            for (int i = 1; i < inOrder.Size; ++i)
            {
                Console.WriteLine("a[{0}]: {1}, a[{2}]: {3}", i - 1, inOrder.Get(i - 1), i, inOrder.Get(i));
                Assert.IsTrue(inOrder.Get(i - 1) <= inOrder.Get(i));
            }
        }
    }
}