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



namespace BWT;

using System;

class Program
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

    private const int alphabetSize = 65536;

    // Reverse BWT, takes string after BWT and index of original string in sorted shifts table,
    // returns original string
    static string ReverseConversion(string convertedString, int tableIndex)
    {
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

    static bool Tests()
    {
        var result = SlowDirectConversion("ABACABA");
        if (result.Item1 != "BCABAAA" || result.Item2 != 2)
        {
            return false;
        }
        result = SlowDirectConversion("baNanaNaS");
        if (result.Item1 != "aaanbNNSa" || result.Item2 != 7)
        {
            return false;
        }
        result = SlowDirectConversion("you want a different string instance");
        if (result.Item1 != "tagtu twn rfcfindr aiiaeyetn nnsso e" || result.Item2 != 35)
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

        Console.WriteLine("Input a string");
        string? input = Console.ReadLine();
        while (input == null)
        {
            Console.WriteLine("Incorrect input.\n Waiting for string");
            input = Console.ReadLine();
        }
        var (stringAfterBWT, inputStringIndex) = SlowDirectConversion(input);
        Console.WriteLine("String after BWT: " + stringAfterBWT);
        var reverseResult = ReverseConversion(stringAfterBWT, inputStringIndex);
        Console.WriteLine("String after reverse BWT: " + reverseResult);
    }
}
