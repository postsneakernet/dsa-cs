﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Trees;
using DSA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees.Tests
{
    [TestClass()]
    public class HeapTests
    {
        Heap h;
        int[] a;

        [TestInitialize()]
        public void TestInitialize()
        {
           
        }

        [TestMethod()]
        public void HeapTest()
        {
            Heap h = new Heap();
            Assert.AreEqual(10, h.Capacity);
            Assert.IsTrue(h.IsMaxHeap);
        }

        [TestMethod()]
        public void HeapFromCapacityAndTypeTest()
        {
            Heap h = new Heap(15, false);
            Assert.AreEqual(15, h.Capacity);
            Assert.IsTrue(h.IsMinHeap);
        }

        [TestMethod()]
        public void HeapFromArrayAndTypeTest()
        {
            Heap h = new Heap(Helpers.BuildRandomArray(25), false);
            Assert.AreEqual(25, h.Capacity);
            Assert.AreEqual(25, h.HeapSize);
            Assert.IsTrue(h.IsMinHeap);
        }

        [TestMethod()]
        public void CreateMaxHeapTest()
        {
            Heap h = Heap.CreateMaxHeap(12);
            Assert.AreEqual(12, h.Capacity);
            Assert.IsTrue(h.IsMaxHeap);
        }

        [TestMethod()]
        public void CreateMinHeapTest()
        {
            Heap h = Heap.CreateMinHeap(12);
            Assert.AreEqual(12, h.Capacity);
            Assert.IsTrue(h.IsMinHeap);
        }

        [TestMethod()]
        public void MaxHeapifyTest()
        {
            a = Helpers.BuildRandomArray(30);
            h = Heap.MaxHeapify(a);

            int[] result = h.ExportArray();

            Assert.AreEqual(30, result.Length);

            for (int i = 0; i < result.Length; ++i)
            {
                int left = i * 2 + 1;
                int right = left + 1;

                if (left >= result.Length) { break; }
                else if (result.Length - left == 1)
                {
                    Assert.IsTrue(result[i] >= result[left]);
                }
                else
                {
                    Assert.IsTrue(result[i] >= result[left] && result[i] >= result[right]);
                }
            }
        }

        [TestMethod()]
        public void MinHeapifyTest()
        {
            a = Helpers.BuildRandomArray(30);
            h = Heap.MinHeapify(a);

            int[] result = h.ExportArray();

            Assert.AreEqual(30, result.Length);

            for (int i = 0; i < result.Length; ++i)
            {
                int left = i * 2 + 1;
                int right = left + 1;

                if (left >= result.Length) { break; }
                else if (result.Length - left == 1)
                {
                    Assert.IsTrue(result[i] <= result[left], String.Format(
                        "result[{0}]: {1}, result[{2}]: {3}",
                        i, result[i], left, result[left]));
                }
                else
                {
                    Assert.IsTrue(result[i] <= result[left] && result[i] <= result[right],
                        String.Format(
                        "result[{0}]: {1}, result[{2}]: {3}, result[{4}]: {5}",
                        i, result[i], left, result[left], right, result[right]));
                }
            }
        }

        [TestMethod()]
        public void PushTest()
        {
            Heap h = new Heap();
            h.Push(5);
            h.Push(70);
            h.Push(10);

            Assert.AreEqual(3, h.HeapSize);
            Assert.AreEqual(70, h.Peek());
        }

        [TestMethod()]
        public void PeekTest()
        {
            Heap h = new Heap();
            h.Push(5);
            Assert.AreEqual(5, h.Peek());
            Assert.AreEqual(1, h.HeapSize);
        }

        [TestMethod()]
        public void PopTest()
        {
            Heap h = new Heap();
            h.Push(4);
            Assert.AreEqual(4, h.Pop());
            Assert.IsTrue(h.IsEmpty);
        }

        [TestMethod()]
        public void ExportArrayTest()
        {
            h = Heap.MaxHeapify(Helpers.BuildRandomArray(8));
            a = h.ExportArray();
            h.Push(1);
            h.Push(2);
            h.Push(3);
            Assert.AreEqual(8, a.Length);
        }

        [TestMethod()]
        public void SortTest()
        {
            a = Helpers.BuildRandomArray(30);
            h = Heap.MaxHeapify(a);

            int[] heapResult = h.ExportArray();

            h.Sort();
            int[] sortResult = h.ExportArray();

            for (int i = 1; i < sortResult.Length; ++i)
            {
                Assert.IsTrue(sortResult[i - 1] <= sortResult[i], String.Format(
                    "sortResult[{0}]: {1}, sortResult[{2}]: {3}",
                    i - 1, sortResult[i - 1], i, sortResult[i]));
            }
        }

        [TestMethod()]
        public void HeapifyTest()
        {
            a = Helpers.BuildRandomArray(30);
            h = Heap.MaxHeapify(a);

            h.Sort();
            int[] sortResult = h.ExportArray();
            for (int i = 1; i < sortResult.Length; ++i)
            {
                Assert.IsTrue(sortResult[i - 1] <= sortResult[i], String.Format(
                    "sortResult[{0}]: {1}, sortResult[{2}]: {3}",
                    i - 1, sortResult[i - 1], i, sortResult[i]));
            }

            Assert.IsTrue(h.IsSortOrder);

            h.Heapify();

            Assert.IsTrue(h.IsHeapOrder);

            int[] result = h.ExportArray();

            for (int i = 0; i < result.Length; ++i)
            {
                int left = i * 2 + 1;
                int right = left + 1;

                if (left >= result.Length) { break; }
                else if (result.Length - left == 1)
                {
                    Assert.IsTrue(result[i] >= result[left]);
                }
                else
                {
                    Assert.IsTrue(result[i] >= result[left] && result[i] >= result[right]);
                }
            }
        }

        [TestMethod()]
        public void ReHeapifyMaxTest()
        {
            a = Helpers.BuildRandomArray(30);
            h = Heap.MinHeapify(a);

            Assert.IsTrue(h.IsMinHeap);
            Assert.AreEqual(30, h.HeapSize);

            a = Helpers.BuildRandomArray(20);
            h.ReHeapifyMax(a);

            Assert.IsTrue(h.IsMaxHeap);
            Assert.AreEqual(20, h.HeapSize);
        }

        [TestMethod()]
        public void ReHeapifyMinTest()
        {
            a = Helpers.BuildRandomArray(30);
            h = Heap.MaxHeapify(a);

            Assert.IsTrue(h.IsMaxHeap);
            Assert.AreEqual(30, h.HeapSize);

            a = Helpers.BuildRandomArray(20);
            h.ReHeapifyMin(a);

            Assert.IsTrue(h.IsMinHeap);
            Assert.AreEqual(20, h.HeapSize);
        }
    }
}