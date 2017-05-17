using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Math.Tests
{
    [TestClass()]
    public class FizzBuzzTests
    {
        [TestMethod()]
        public void GenerateFizzBuzzTest()
        {
            List<string> results = FizzBuzz.Generate();

            for (int i = 15; i <= 100; i +=15)
            {
                Assert.AreEqual("FizzBuzz", results.ElementAt(i - 1));
            }

            for (int i = 3; i <= 100; i += 3)
            {
                if (i % 15 == 0) { continue; }
                Assert.AreEqual("Fizz", results.ElementAt(i - 1));
            }

            for (int i = 5; i <= 100; i += 5)
            {
                if (i % 15 == 0) { continue; }
                Assert.AreEqual("Buzz", results.ElementAt(i - 1));
            }

            for (int i = 1; i <= 100; ++i)
            {
                if (i % 3 == 0 || i % 5 == 0) { continue; }
                Assert.AreEqual(i.ToString(), results.ElementAt(i - 1));
            }
        }
    }
}