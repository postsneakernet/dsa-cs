namespace Algorithms.Sorting
{
    public class SelectionSort
    {
        public static void Sort(int[] a)
        {
            if (a == null) { return; }

            for (int i = 0; i < a.Length - 1; ++i)
            {
                int min = i;

                for (int j = i + 1; j < a.Length; ++j)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }

                int temp = a[i];
                a[i] = a[min];
                a[min] = temp;
            }
        }
    }
}
