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

namespace BWTransform;

// A static class that implements direct and reverse Burrows–Wheeler transform
public static class BWT
{
    // Direct BWT, returns string after conversion and index of original string 
    // in shift table
    static (string, int) SlowDirectConversion(string originalString)
    {
        var shifts = originalString;
        var shiftTable = new string[originalString.Length];
        shiftTable[0] = originalString;
        for (var i = 1; i < shiftTable.Length; i++)
        {
            char firstChar = shifts[0];
            shifts = shifts.Substring(1) + firstChar;
            shiftTable[i] = shifts;
        }
        Array.Sort(shiftTable, StringComparer.Ordinal);
        string result = "";
        for (var i = 0; i < shiftTable.Length; i++)
        {
            result += shiftTable[i][shiftTable.Length - 1];
        }
        return (result, Array.IndexOf(shiftTable, originalString));
    }



    public static (byte[], int) FastDirectConversion(byte[] originalData)
    {
        var shifts = Enumerable.Range(0, originalData.Length).ToArray();
        Array.Sort(shifts, new ShiftsComparer(originalData));
        var result = new byte[shifts.Length];
        int originalSequenceIndex = 0;
        for (int i = 0; i < shifts.Length; i++)
        {
            result[i] = originalData[(shifts[i] + originalData.Length - 1) % originalData.Length];
            if (shifts[i] == 0)
            {
                originalSequenceIndex = i;
            }
        }
        return (result, originalSequenceIndex);
    }

    private const int alphabetSize = 256;

    // Reverse BWT, takes string after BWT and index of original string in sorted shifts table,
    // returns original string
    public static byte[] ReverseConversion(byte[] convertedBytes, int tableIndex)
    {
        var countSortArray = new int[alphabetSize];
        for (var i = 0; i < convertedBytes.Length; ++i)
        {
            ++countSortArray[convertedBytes[i]];
        }

        // Sort symbols to get first column of original table
        //countSortArray[i] to first position i-symbol in 1st column
        var sum = 0;
        for (var i = 0; i < alphabetSize; ++i)
        {
            sum += countSortArray[i];
            countSortArray[i] = sum - countSortArray[i];
        }

        var nextSymbolIndex = new int[convertedBytes.Length];
        for (var i = 0; i < nextSymbolIndex.Length; ++i)
        {
            nextSymbolIndex[countSortArray[convertedBytes[i]]] = i;
            countSortArray[convertedBytes[i]]++;
        }

        var nextSymbol = nextSymbolIndex[tableIndex];
        var answer = new byte[convertedBytes.Length];
        for (int i = 0; i < convertedBytes.Length; ++i)
        {
            answer[i] = convertedBytes[nextSymbol];
            nextSymbol = nextSymbolIndex[nextSymbol];
        }
        return answer;
    }
}