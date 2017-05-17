using System.Linq;

namespace Algorithms.Strings
{
    public class Reverse
    {
        public static string ReverseIter(string s)
        {
            if (s == null || s.Length < 2) { return s; }

            for (int i = 0; i < s.Length; ++i)
            {
                s = s.Substring(0, i) + s.ElementAt(s.Length - 1) + s.Substring(i, s.Length - 1 - i);
            }

            return s;
        }

        public static string ReverseRecur(string s)
        {
            if (s == null || s.Length < 2) { return s; }

            return ReverseRecur(s.Substring(1)) + s[0];
        }
    }
}
