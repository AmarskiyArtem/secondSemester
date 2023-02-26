namespace BWT;

using System;

class Programm
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

    // Reverse BWT, takes string after BWT and index of original string in sorted shifts table,
    // returns original string
    static string ReverseConversion(string convertedString, int tableIndex)
    {
        var countSortArray = new int[256];
        for (var i = 0; i < convertedString.Length; ++i)
        {
            ++countSortArray[convertedString[i]];
        }

        // Sort symbols to get first column of original table
        //countSortArray[i] to first position i-symbol in 1st column
        var sum = 0;
        for (var i = 0; i < 256; ++i)
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
        return string.Join("", answer);
    }

    static bool tests()
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
        if (!tests())
        {
            Console.WriteLine("Tests failed");
            return;
        }

        Console.WriteLine("Input a string (only ASCII symbols)");
        string? input = Console.ReadLine();
        while (!(input is String) || !(input.All(char.IsAscii)))
        {
            Console.WriteLine("Incorrect input.\n Waiting for string (only ASCII symbols)");
            input = Console.ReadLine();
        }
        var DirectBWTResult = SlowDirectConversion(input);
        var stringAfterBWT = DirectBWTResult.Item1;
        var inputStringIndex = DirectBWTResult.Item2;
        Console.WriteLine("String after BWT: " + stringAfterBWT);
        var reverseResult = ReverseConversion(stringAfterBWT, inputStringIndex);
        Console.WriteLine("String after reverse BWT: " + reverseResult);
    }
}
