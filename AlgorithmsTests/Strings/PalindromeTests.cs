using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Strings;
using System;

namespace Algorithms.Strings.Tests
{
    [TestClass()]
    public class PalindromeTests
    {
        [TestMethod()]
        public void isPalindromeTest()
        {
            String s = "";
            Assert.IsTrue(Palindrome.isPalindrome(s));

            s = "A";
            Assert.IsTrue(Palindrome.isPalindrome(s));

            s = "Aa";
            Assert.IsTrue(Palindrome.isPalindrome(s));

            s = "At";
            Assert.IsFalse(Palindrome.isPalindrome(s));

            s = "Tat";
            Assert.IsTrue(Palindrome.isPalindrome(s));

            s = "Tan";
            Assert.IsFalse(Palindrome.isPalindrome(s));

            s = "toot";
            Assert.IsTrue(Palindrome.isPalindrome(s));

            s = "loot";
            Assert.IsFalse(Palindrome.isPalindrome(s));

            s = "Radar";
            Assert.IsTrue(Palindrome.isPalindrome(s));

            s = "hello";
            Assert.IsFalse(Palindrome.isPalindrome(s));
        }
    }
}