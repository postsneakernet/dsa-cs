using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common
{
    public class Helpers
    {
        public static void PrintArray(int[] a)
        {
            foreach (int i in a)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
        }

        public static int[] BuildRandomArray(int size)
        {
            int[] a = new int[size];
            Random rnd = new Random();

            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = rnd.Next(-99, 100);
            }

            return a;
        }

        public static int[] BuildEvenArray(int size)
        {
            int[] a = new int[size];

            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = i * 2;
            }

            return a;
        }
    }
}
