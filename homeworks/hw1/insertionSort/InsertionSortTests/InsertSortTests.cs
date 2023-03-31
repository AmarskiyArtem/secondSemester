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

namespace InsertionSortTests;

public class Tests
{
    private static bool IsSorted(int[] array)
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

    [Test]
    public void CommonArraysShouldRightSorting()
    {
        int[] testArrayOne = { 1, 2, 3, 4 };
        int[] testArrayTwo = { 4, 3, 2, 1 };
        int[] testArrayThree = { 5, 6, 4, 3, 10, 2, 7 };
        var testArrays = new[] { testArrayOne, testArrayTwo, testArrayThree };
        for (var i = 0; i < testArrays.Length; ++i)
        {
            InsertSort.InsertionSort(testArrays[i]);
            Assert.IsTrue(IsSorted(testArrays[i]));
        }
    }

    [Test]
    public void EmptyArrayShouldNoException()
    {
        InsertSort.InsertionSort(new int[] { });
    }

    [Test]
    public void ArrayWithSimularValuesShouldNothingChange()
    {
        var testArray = new[] { 1, 1, 1, 1, 1, 1 };
        InsertSort.InsertionSort(testArray);
        for (var i = 0; i < 6; ++i)
        {
            Assert.IsTrue(testArray[i] == 1);
        }
        Assert.IsTrue(testArray.Length == 6);
    }
}