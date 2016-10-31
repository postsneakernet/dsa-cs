using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Strings.Tests
{
    [TestClass()]
    public class ReverseTests
    {
        [TestMethod()]
        public void ReverseIterTest()
        {
            Assert.AreEqual("olleH", Reverse.ReverseIter("Hello"));
            Assert.AreEqual("taH", Reverse.ReverseIter("Hat"));
            Assert.AreEqual("aH", Reverse.ReverseIter("Ha"));
            Assert.AreEqual("H", Reverse.ReverseIter("H"));
            Assert.AreEqual("", Reverse.ReverseIter(""));
            Assert.AreEqual(null, Reverse.ReverseIter(null));
        }

        [TestMethod()]
        public void ReverseRecurTest()
        {
            Assert.AreEqual("olleH", Reverse.ReverseRecur("Hello"));
            Assert.AreEqual("taH", Reverse.ReverseRecur("Hat"));
            Assert.AreEqual("aH", Reverse.ReverseRecur("Ha"));
            Assert.AreEqual("H", Reverse.ReverseRecur("H"));
            Assert.AreEqual("", Reverse.ReverseRecur(""));
            Assert.AreEqual(null, Reverse.ReverseRecur(null));
        }
    }
}