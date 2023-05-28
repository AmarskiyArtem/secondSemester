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

namespace BWTLibrary;

/// <summary>
/// Burrows-Wheeler transform, the algorithm used to prepare data before compressing it
/// </summary>
public static class BWTTransform
{
    /// <summary>
    /// Slow direct BWT, returns string after conversion and index of original string 
    /// </summary>
    /// <returns>String after conversion and index of original string in shifts table</returns>
    public static(string, int) SlowDirectConversion(string originalString)
    {
        if (originalString == String.Empty)
        {
            throw new ArgumentException("String can`t be empty.");
        }
        var shifts = originalString;
        var shiftTable = new string[originalString.Length];
        shiftTable[0] = originalString;
        for (var i = 0; i < shiftTable.Length; i++)
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

    /// <summary>
    /// Fast direct BWT, returns string after conversion and index of original string 
    /// </summary>
    /// <returns>String after conversion and index of original string in shifts table</returns>
    public static (string, int) FastDirectConversion(string originalString)
    {
        if (originalString == String.Empty)
        {
            throw new ArgumentException("String can`t be empty.");
        }
        var shifts = Enumerable.Range(0, originalString.Length).ToArray();
        Array.Sort(shifts, new ShiftsComparer(originalString));
        var result = new char[shifts.Length];
        int originalSequenceIndex = 0;
        for (int i = 0; i < shifts.Length; i++)
        {
            result[i] = originalString[(shifts[i] + originalString.Length - 1) % originalString.Length];
            if (shifts[i] == 0)
            {
                originalSequenceIndex = i;
            }
        }
        return (new string(result), originalSequenceIndex);
    }

    private const int alphabetSize = 65536;

    /// <summary>
    /// Reverse BWT
    /// </summary>
    /// <param name="convertedString">string after BWT</param>
    /// <param name="tableIndex">index of original string in sorted shifts table</param>
    /// <returns>original string</returns>
    public static string ReverseConversion(string convertedString, int tableIndex)
    {
        if (convertedString == String.Empty)
        {
            throw new ArgumentException("String can`t be empty.");
        }
        var countSortArray = new int[alphabetSize];
        for (var i = 0; i < convertedString.Length; ++i)
        {
            ++countSortArray[convertedString[i]];
        }

        // Sort symbols to get first column of original table
        //countSortArray[i] to first position i-symbol in 1st column
        var sum = 0;
        for (var i = 0; i < alphabetSize; ++i)
        {
            sum += countSortArray[i];
            countSortArray[i] = sum - countSortArray[i];
        }

        var nextSymbolIndex = new int[convertedString.Length];
        for (var i = 0; i < nextSymbolIndex.Length; ++i)
        {
            nextSymbolIndex[countSortArray[convertedString[i]]] = i;
            countSortArray[convertedString[i]]++;
        }

        var nextSymbol = nextSymbolIndex[tableIndex];
        var answer = new char[convertedString.Length];
        for (int i = 0; i < convertedString.Length; ++i)
        {
            answer[i] = convertedString[nextSymbol];
            nextSymbol = nextSymbolIndex[nextSymbol];
        }
        return new string(answer);
    }
}


