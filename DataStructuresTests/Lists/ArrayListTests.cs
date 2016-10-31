using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists.Tests
{
    [TestClass()]
    public class ArrayListTests
    {
        ArrayList al;

        [TestInitialize()]
        public void TestInitialize()
        {
            al = new ArrayList();
            al.Add(1);
            al.Add(2);
            al.Add(3);
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.AreEqual(2, al.Get(1));
        }

        [TestMethod()]
        public void GetFrontTest()
        {
            Assert.AreEqual(1, al.GetFront());
        }

        [TestMethod()]
        public void GetBackTest()
        {
            Assert.AreEqual(3, al.GetBack());
        }

        [TestMethod()]
        public void AddAtTest()
        {
            int[] expected = new int[] { 5, 1, 2, 3, 4 };

            al.AddAt(3, 4);
            al.AddAt(0, 5);

            Assert.AreEqual(expected.Length, al.Size);

            for (int i = 0; i < expected.Length; ++i)
            {
                Assert.AreEqual(expected[i], al.Get(i));
            }
        }

        [TestMethod()]
        public void AddTest()
        {
            al.Add(4);
            Assert.AreEqual(4, al.Size);
            Assert.AreEqual(4, al.Get(3));
        }

        [TestMethod()]
        public void AddFrontTest()
        {
            al.AddFront(4);
            Assert.AreEqual(4, al.Size);
            Assert.AreEqual(4, al.GetFront());
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            int item = al.RemoveAt(0);
            Assert.AreEqual(1, item);
            Assert.AreEqual(2, al.Size);
            Assert.AreEqual(2, al.GetFront());

            item = al.RemoveAt(1);
            Assert.AreEqual(3, item);
            Assert.AreEqual(1, al.Size);
            Assert.AreEqual(2, al.GetFront());
        }

        [TestMethod()]
        public void RemoveTest()
        {
            int item = al.Remove();
            Assert.AreEqual(3, item);
            Assert.AreEqual(2, al.Size);
        }

        [TestMethod()]
        public void RemoveFrontTest()
        {
            int item = al.RemoveFront();
            Assert.AreEqual(1, item);
            Assert.AreEqual(2, al.Size);
            Assert.AreEqual(2, al.GetFront());
        }

        [TestMethod()]
        public void FindFirstOccurrenceTest()
        {
            int first = al.FindFirstOccurrence(3);
            Assert.AreEqual(2, first);

            first = al.FindFirstOccurrence(7);
            Assert.AreEqual(-1, first);
        }

        [TestMethod()]
        public void ClearAndResizeTest()
        {
            for (int i = 0; i < 30; ++i)
            {
                al.Add(i);
            }

            Assert.AreEqual(33, al.Size);
            Assert.AreEqual(40, al.Capacity);

            al.ClearAndResize(12);

            Assert.AreEqual(0, al.Size);
            Assert.AreEqual(12, al.Capacity);
        }

        [TestMethod()]
        public void ClearTest()
        {
            al.Clear();
            Assert.AreEqual(0, al.Size);
        }

        [TestMethod()]
        public void TrimToSizeTest()
        {
            for (int i = 0; i < 30; ++i)
            {
                al.Add(i);
            }

            al.Clear();

            for (int i = 0; i < 7; ++i)
            {
                al.Add(i);
            }

            al.TrimToSize();
            Assert.AreEqual(7, al.Size);
            Assert.AreEqual(7, al.Capacity);
        }
    }
}