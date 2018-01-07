namespace QuickSortWPF
{
    public class SortEngine
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        static void QuickSort(int[] array, int index, int pivotIndex)
        {
            if (index >= pivotIndex) return;
            index = Partitioning(array, index, pivotIndex);
            QuickSort(array, index, pivotIndex);
            QuickSort(array, 0, index - 1);
        }

        static int Partitioning(int[] array, int index, int pivotIndex)
        {
            int current = index;
            while (index <= pivotIndex && current < pivotIndex)
            {
                while(array[current] > array[pivotIndex])
                {
                    current++;
                }
                if (index <= pivotIndex && array[index] > array[current])
                {
                    Swap(array, index, current);
                    index++;
                } else { current++; index++; }
            }
            return index;
        }

        static void Swap(int[] array, int left, int rigth)
        {
            int temp = array[left];
            array[left] = array[rigth];
            array[rigth] = temp;
        }
    }
}
