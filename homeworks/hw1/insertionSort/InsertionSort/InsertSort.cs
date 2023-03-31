/*
 * This file is part of project "Second Semester".
 * Copyright (c) [2023] [Artem Amarskiy].
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     https://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
