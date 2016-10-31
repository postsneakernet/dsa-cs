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
    public class QueueTests
    {
        Queue q;

        [TestInitialize()]
        public void TestInit()
        {
            q = new Queue();
        }

        [TestMethod()]
        public void QueueTest()
        {
            Assert.IsTrue(q.IsEmpty);
            Assert.AreEqual(0, q.Size);
        }

        [TestMethod()]
        public void EnqueueTest()
        {
            q.Enqueue(1);
            Assert.IsFalse(q.IsEmpty);
            Assert.AreEqual(1, q.Size);

            for (int i = 2; i <= 10; ++i)
            {
                q.Enqueue(i);
            }

            Assert.AreEqual(10, q.Size);

            q.Enqueue(11);
            Assert.AreEqual(11, q.Size);
        }

        [TestMethod()]
        public void DequeueTest()
        {
            q.Enqueue(81);
            int item = q.Dequeue();
            Assert.AreEqual(81, item);
            Assert.IsTrue(q.IsEmpty);
        }

        [TestMethod()]
        public void PeekTest()
        {
            q.Enqueue(81);
            int item = q.Peek();
            Assert.AreEqual(81, item);
            Assert.IsFalse(q.IsEmpty);
            Assert.AreEqual(1, q.Size);
        }

        [TestMethod()]
        public void CanEnqueueAfterFillingHalfAndClearingTest()
        {
            for (int i = 1; i <= 6; ++i)
            {
                q.Enqueue(i);
            }

            for (int i = 1; i <= 6; ++i)
            {
                Assert.AreEqual(i, q.Dequeue());
            }

            Assert.AreEqual(0, q.Size);

            for (int i = 1; i <= 6; ++i)
            {
                q.Enqueue(i * 2);
            }

            Assert.AreEqual(6, q.Size);

            for (int i = 1; i <= 6; ++i)
            {
                Assert.AreEqual(i * 2, q.Dequeue());
            }
        }

        [TestMethod()]
        public void CanEnqueueAfterFillingAndClearingTest()
        {
            for (int i = 1; i <= 10; ++i)
            {
                q.Enqueue(i);
            }

            Assert.AreEqual(10, q.Size);
            Assert.IsFalse(q.IsEmpty);

            for (int i = 1; i <= 10; ++i)
            {
                Assert.AreEqual(i, q.Dequeue());
            }

            Assert.AreEqual(0, q.Size);
            Assert.IsTrue(q.IsEmpty);

            q.Enqueue(17);
            Assert.AreEqual(1, q.Size);
            Assert.IsFalse(q.IsEmpty);
            Assert.AreEqual(17, q.Dequeue());
        }
    }
}