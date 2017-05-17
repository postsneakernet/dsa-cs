namespace Algorithms.Sorting
{
    public class QuickSort
    {
        public static void Sort(int[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(int[] a, int left, int right)
        {
            if (left >= right) { return; }

            int pivot = a[(left + right) / 2];
            int index = Partition(a, left, right, pivot);
            Sort(a, left, index - 1);
            Sort(a, index, right);
        }

        private static int Partition(int[] a, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (a[left] < pivot)
                {
                    ++left;
                }

                while (a[right] > pivot)
                {
                    --right;
                }

                if (left < right)
                {
                    Swap(a, left, right);
                    ++left;
                    --right;
                }
            }

            return left;
        }

        private static void Swap(int[] a, int left, int right)
        {
            int temp = a[left];
            a[left] = a[right];
            a[right] = temp;
        }
    }
}
