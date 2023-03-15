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
}