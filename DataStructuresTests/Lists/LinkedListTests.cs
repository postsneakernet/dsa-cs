using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.Lists.Tests
{
    [TestClass()]
    public class LinkedListTests
    {
        LinkedList<int> list;

        [TestInitialize()]
        public void TestInit()
        {
            list = new LinkedList<int>();
        }

        [TestMethod()]
        public void ShallowListCopyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            for (int i = 0; i < 3; ++i)
            {
                Assert.AreEqual(i + 1, list.Get(i));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetEmptyTest()
        {
            list.Get(1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetOutOfRangeTest()
        {
            list.Add(1);
            list.Get(5);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetFrontEmptyTest()
        {
            list.GetFront();
        }

        [TestMethod()]
        public void GetFrontTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(1, list.GetFront());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetBackEmptyTest()
        {
            list.GetBack();
        }

        [TestMethod()]
        public void GetBackTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(3, list.GetBack());
        }

        [TestMethod()]
        public void AddTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(3, list.Size);

            int i = 1;
            foreach (var item in list)
            {
                Assert.AreEqual(i, item);
                ++i;
            }
        }

        [TestMethod()]
        public void AddFrontTest()
        {
            list.AddFront(2);
            list.Add(3);
            list.Add(4);
            list.AddFront(1);
            list.Add(5);

            Assert.AreEqual(5, list.Size);

            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(i + 1, list.Get(i));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddAtNegativeIndexTest()
        {
            list.AddAt(-1, 55);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddAtOutOfRangeTest()
        {
            list.Add(1);
            list.Add(2);
            list.AddAt(5, 55);
        }

        [TestMethod()]
        public void AddAtTest()
        {
            list.AddAt(0, 2);
            list.Add(3);
            list.Add(5);
            list.AddAt(2, 4);
            list.Add(6);
            list.AddAt(0, 1);
            list.Add(7);
            list.AddAt(7, 8);
            list.Add(9);

            Assert.AreEqual(9, list.Size);

            for (int i = 0; i < 9; ++i)
            {
                Assert.AreEqual(i + 1, list.Get(i));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveEmptyTest()
        {
            list.Remove();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            list.Add(1);
            Assert.AreEqual(1, list.Size);

            int result = list.Remove();
            Assert.AreEqual(result, 1);
            Assert.AreEqual(0, list.Size);

            list.Add(12);
            list.Add(13);
            Assert.AreEqual(2, list.Size);

            result = list.Remove();
            Assert.AreEqual(result, 13);
            Assert.AreEqual(1, list.Size);
            Assert.AreEqual(12, list.Get(0));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveFrontEmptyTest()
        {
            list.RemoveFront();
        }

        [TestMethod()]
        public void RemoveFrontTest()
        {
            list.Add(-1);
            Assert.AreEqual(-1, list.RemoveFront());
            Assert.AreEqual(0, list.Size);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.AreEqual(1, list.RemoveFront());
            Assert.AreEqual(4, list.Size);

            list.AddFront(1);
            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(i + 1, list.Get(i));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtEmptyTest()
        {
            list.RemoveAt(0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtNegavtiveIndexTest()
        {
            list.Add(1);
            list.RemoveAt(-1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtOutOfRangeTest()
        {
            list.Add(1);
            list.RemoveAt(12);
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            list.Add(1);
            int result = list.RemoveAt(0);
            Assert.AreEqual(1, result);
            Assert.AreEqual(0, list.Size);

            list.Add(11);
            list.Add(12);
            result = list.RemoveAt(0);
            Assert.AreEqual(11, result);
            Assert.AreEqual(1, list.Size);
            Assert.AreEqual(12, list.Get(0));

            list.Add(13);
            list.Add(44);
            result = list.RemoveAt(2);
            Assert.AreEqual(44, result);
            Assert.AreEqual(2, list.Size);

            list.Add(14);
            result = list.RemoveAt(1);
            Assert.AreEqual(13, result);
            Assert.AreEqual(2, list.Size);

            list.Add(16);
            Assert.AreEqual(3, list.Size);
            Assert.AreEqual(12, list.Get(0));
            Assert.AreEqual(14, list.Get(1));
            Assert.AreEqual(16, list.Get(2));
        }

        [TestMethod()]
        public void ReverseTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            list.Reverse();
            list.AddFront(10);

            for (int i = 0; i <= 10; ++i)
            {
                Assert.AreEqual(10 - i, list.Get(i));
            }

            list.Reverse();
            list.Add(11);

            for (int i = 0; i <= 11; ++i)
            {
                Assert.AreEqual(i, list.Get(i));
            }
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            int j = 0;
            foreach (var item in list)
            {
                Assert.AreEqual(j, item);
                ++j;
            }
        }
    }
}