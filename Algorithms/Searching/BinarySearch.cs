namespace Algorithms.Searching
{
    public class BinarySearch
    {
        public static int IndexOf(int[] a, int key)
        {
            int low = 0;
            int high = a.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (a[mid] < key) { low = mid + 1; }
                else if (a[mid] > key) { high = mid - 1; }
                else { return mid; }
            }

            return -1;
        }

        public static int IndexOfRecur(int[] a, int key)
        {
            return RecursiveIndexOf(a, 0, a.Length - 1, key);
        }

        private static int RecursiveIndexOf(int[] a, int low, int high, int key)
        {
            if (low == high) { return (a[low] == key) ? low : -1; }

            int mid = (low + high) / 2;

            if (a[mid] < key)
            {
                low = mid + 1;
                return RecursiveIndexOf(a, low, high, key);
            } else if (a[mid] > key)
            {
                high = mid - 1;
                return RecursiveIndexOf(a, low, high, key);
            } else
            {
                return mid;
            }
        }
    }
}
