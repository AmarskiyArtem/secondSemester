using System;

namespace InsertionSort
{
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
                    Swap(ref array[j], ref array[j- 1]);
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
        static void Main(string[] args)
        {
            Console.WriteLine("Input amount of elements");
            var arraySize = int.Parse(Console.ReadLine());
            int[] array = new int[arraySize];
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
}