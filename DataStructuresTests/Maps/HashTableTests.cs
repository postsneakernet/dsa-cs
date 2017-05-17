using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA.Common;
using System;

namespace DataStructures.Maps.Tests
{
    [TestClass()]
    public class HashTableTests
    {
        string[] keys = {"Apple", "Air", "Article", "Arnold",
                         "Banana", "Battle", "Bike", "Boston",
                         "Carl", "Cake", "Canister", "Cape",
                         "Deano", "Dino", "Dollar", "Dapper Drake",
                         "Elliot", "East", "Election", "Eerie"
        };

        HashTable<Item> ht;

        [TestInitialize()]
        public void TestInit()
        {
            ht = new HashTable<Item>();

            foreach (var s in keys)
            {
                ht.Put(s, new Item(s));
            }
        }

        [TestMethod()]
        public void HashTableTest()
        {
            ht = new HashTable<Item>();

            Assert.AreEqual(0, ht.Size);
            Assert.AreEqual(0, ht.Load);
        }

        [TestMethod()]
        public void GetTest()
        {
            Item i = ht.Get("Battle");
            Assert.AreEqual("Battle", i.Name);

            i = ht.Get("Asdf");
            Assert.IsTrue(i == null);
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.AreEqual(20, ht.Size);
            Assert.AreEqual(32, ht.Slots);
            Assert.IsTrue(ht.Load < 0.75);

            ht.Put("Dollar", new Item("New Dollar"));
            Assert.AreEqual(20, ht.Size);
            Assert.AreEqual("New Dollar", ht.Get("Dollar").Name);

            ht.Put("ralloD", new Item("ralloD"));
            Assert.AreEqual(21, ht.Size);

            foreach (var s in keys)
            {
                ht.Put("The new " + s, new Item("The new " + s));
                ht.Put("The old " + s, new Item("The old " + s));
                ht.Put(s.ToUpper() + s.ToLower(), new Item(s.ToUpper() + s.ToLower()));
                ht.Put(s.ToLower() + s.ToUpper() + s, new Item(s.ToLower() + s.ToUpper() + s));
            }

            Console.WriteLine(ht.Load);
            Assert.AreEqual(101, ht.Size);
            Assert.AreEqual(128, ht.Slots);
            Assert.IsTrue(ht.Load < 0.75);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            foreach (var s in keys)
            {
                ht.Remove(s);
            }

            Assert.AreEqual(0, ht.Size);
            Assert.AreEqual(0, ht.Load);

            ht.Put("Hello", new Item("Hello"));

            Assert.AreEqual(1, ht.Size);
            Assert.IsTrue(ht.Load > 0);
        }

        [TestMethod()]
        public void GetKeySetTest()
        {
            string[] keySet = ht.GetKeySet();

            foreach (var s in keySet)
            {
                Assert.IsTrue(Array.IndexOf(keys, s) > -1);
            }
        }
    }
}