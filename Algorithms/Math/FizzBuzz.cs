using System;
using System.Collections.Generic;

namespace Algorithms.Math
{
    public class FizzBuzz
    {
        public static List<string> Generate()
        {
            List<string> list = new List<string>();
            string result;
            for (int i = 1; i <= 100; ++i)
            {
                result = "";
                if (i % 3 == 0)
                {
                    result = "Fizz";
                }
                if (i % 5 == 0)
                {
                    result += "Buzz";
                }
                if (!(i % 3 == 0 || i % 5 == 0))
                {
                    result = i.ToString();
                }
                list.Add(result);
            }
            return list;
        }

        public static void Print(List<string> list)
        {
            foreach (string s in list) {
                Console.WriteLine(s);
            }
        }
    }
}
