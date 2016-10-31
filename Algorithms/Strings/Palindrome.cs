using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Strings
{
    public class Palindrome
    {
        public static bool isPalindrome(string s)
        {
            if (s == null) { return false; }
            if (s.Length < 2) { return true; }

            s = s.ToLower();

            for (int i = 0, j = s.Length - 1; i < j; ++i, --j)
            {
                if (!s[i].Equals(s[j]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
