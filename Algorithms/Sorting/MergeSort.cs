using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class MergeSort
    {
        public static void Sort(int[] a)
        {
            if (a == null || a.Length < 2) { return; }

            int mid = a.Length / 2;

            int[] left = new int[mid];

            for (int i = 0; i < left.Length; ++i)
            {
                left[i] = a[i];
            }

            int[] right = new int[a.Length - mid];

            for (int i = mid; i < a.Length; ++i)
            {
                right[i - mid] = a[i];
            }

            Sort(left);
            Sort(right);
            Merge(left, right, a);
        }

        private static void Merge(int[] left, int[] right, int[] a)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                a[k++] = (left[i] <= right[j]) ? left[i++] : right[j++];
            }

            while (i < left.Length)
            {
                a[k++] = left[i++];
            }

            while (j < right.Length)
            {
                a[k++] = right[j++];
            }
        }
    }
}
