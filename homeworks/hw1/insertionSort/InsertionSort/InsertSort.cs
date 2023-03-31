namespace InsertionSortLibrary;

/// <summary>
/// Static class implementing insertion sort in ascending order for int[] arrays
/// </summary>
public static class InsertSort
{
    private static void Swap(ref int x, ref int y)
    {
        if (x == y)
        {
            return;
        }
        x ^= y;
        y ^= x;
        x ^= y;
    }

    /// <summary>
    /// Takes int[] array and sort it in ascending order
    /// </summary>
    /// <param name="array">array for sorting</param>
    public static void InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var j = i;
            while (j > 0 && array[j - 1] > array[j])
            {
                Swap(ref array[j], ref array[j - 1]);
                --j;
            }
        }
    }
}
