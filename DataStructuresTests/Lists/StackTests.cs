using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA.Common;

namespace DataStructures.Lists.Tests
{
    [TestClass()]
    public class StackTests
    {
        Stack<Item> s;

        [TestInitialize()]
        public void TestInitialize()
        {
            s = new Stack<Item>();
        }

        [TestMethod()]
        public void CreateFixedStackTest()
        {
            Stack<int> fixedStack = new Stack<int>(3, true);
            fixedStack.Push(1);
            fixedStack.Push(2);
            fixedStack.Push(3);

            Assert.AreEqual(3, fixedStack.Size);
            Assert.IsTrue(fixedStack.IsFull);
        }

        [TestMethod()]
        public void CreateDynamicStackTest()
        {
            Stack<int> dynamicStack = new Stack<int>(3, false);
            dynamicStack.Push(1);
            dynamicStack.Push(2);
            dynamicStack.Push(3);

            Assert.AreEqual(3, dynamicStack.Size);
            Assert.IsFalse(s.IsFull);

            dynamicStack.Push(4);
            Assert.AreEqual(4, dynamicStack.Size);
        }

        [TestMethod()]
        public void PushTest()
        {
            Assert.IsTrue(s.IsEmpty);
            s.Push(new Item("Lamp"));
            Assert.AreEqual(1, s.Size);
            Assert.IsFalse(s.IsEmpty);
        }

        [TestMethod()]
        [ExpectedException(typeof(StackIsFullException))]
        public void PushFullFixedTest()
        {
            Stack<int> fixedStack = Stack<int>.CreateFixedStack(3);
            fixedStack.Push(1);
            fixedStack.Push(2);
            fixedStack.Push(3);

            Assert.IsTrue(fixedStack.IsFull);

            fixedStack.Push(4);
        }

        [TestMethod()]
        public void PeekTest()
        {
            s.Push(new Item("Pencil"));
            s.Push(new Item("Lamp"));

            Assert.AreEqual("Lamp", s.Peek().Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(StackIsEmptyException))]
        public void PeekEmptyTest()
        {
            s.Peek();
        }

        [TestMethod()]
        public void PopTest()
        {
            s.Push(new Item("Lamp"));
            s.Push(new Item("Chair"));
            s.Push(new Item("Desk"));

            Assert.AreEqual("Desk", s.Pop().Name);
            Assert.AreEqual("Chair", s.Pop().Name);
            Assert.AreEqual("Lamp", s.Pop().Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(StackIsEmptyException))]
        public void PopEmptyTest()
        {
            s.Pop();
        }
    }
}