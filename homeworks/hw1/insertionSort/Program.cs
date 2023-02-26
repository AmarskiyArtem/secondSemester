namespace InsertionSort;

using System;

// Class for reading an array of numbers and sort them using insertion sort 
class Program
{
    static void Swap(ref int x, ref int y)
    {
        if (x == y)
        {
            return;
        }
        x ^= y;
        y ^= x;
        x ^= y;
    }

    static void InsertionSort(int[] array)
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

    static void PrintArray(int[] array)
    {
        for (var i = 0; i < array.Length; ++i)
        {
            Console.Write(array[i] + " ");
        }
    }

    static bool IsSorted(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    static bool Tests()
    {
        int[] testArrayOne = { 1, 1, 1, 1 };
        int[] testArrayTwo = { 4, 3, 2, 1 };
        int[] testArrayThree = { 5, 6, 4, 3, 10, 2, 7 };
        InsertionSort(testArrayOne);
        if (!IsSorted(testArrayOne))
        {
            return false;
        }
        InsertionSort(testArrayTwo);
        if (!IsSorted(testArrayTwo))
        {
            return false;
        }
        InsertionSort(testArrayThree);
        if (!IsSorted(testArrayThree))
        {
            return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        if (!Tests())
        {
            Console.WriteLine("Tests failed");
            return;
        }
        Console.WriteLine("Input amount of elements");
        var arraySize = int.Parse(Console.ReadLine());
        var array = new int[arraySize];
        Console.WriteLine("Input numbers");
        for (var i = 0; i < arraySize; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Array after sorting");
        InsertionSort(array);
        PrintArray(array);
    }
}

