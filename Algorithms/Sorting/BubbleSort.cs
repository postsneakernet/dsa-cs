using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class BubbleSort
    {
        public static void Sort(int[] a)
        {
            int n = a.Length; //  n - 1 comparisons after each iteration of outer loop since largest elem is at end of array

            for (int i = 0; i < a.Length; ++i, --n)
            {
                bool swap = false;

                for (int j = 1; j < n; ++j)
                {
                    if (a[j - 1] > a[j])
                    {
                        int temp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = temp;
                        swap = true;
                    }
                }

                if (!swap) { break; } // already sorted, end early
            }
        }
    }
}
