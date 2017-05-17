using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lists;
using System;

namespace DataStructures.Trees.Tests
{
    [TestClass()]
    public class AvlTreeTests
    {
        AvlTree<int> tree;

        [TestInitialize()]
        public void TestInit()
        {
            tree = new AvlTree<int>();
        }

        [TestMethod()]
        public void ShallowSetCopyTest()
        {
            Assert.Fail();
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
    }
}