namespace BWT
{
    class Programm
    {
        // Direct BWT, returns string after conversion and index of original string 
        //in shift table
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
            Array.Sort(shiftTable);
            string result = "";
            for (var i = 0; i < shiftTable.Length; i++)
            {
                result += shiftTable[i][shiftTable.Length - 1];
            }
            return (result, Array.IndexOf(shiftTable, originalString));
        }

        static string ReverseConversion(string convertedString, int tableIndex)
        {
            var countSortArray = new int[(int)char.MaxValue];
            for (var i = 0; i < convertedString.Length; ++i)
            {
                ++countSortArray[(int)convertedString[i]];
            }

            // Sort symbols to get first column of original table
            //countSortArray[i] to first position i-symbol in 1st column
            var sum = 0;
            for (var i = 0; i < (int)char.MaxValue; ++i)
            {
                sum += countSortArray[i];
                countSortArray[i] = sum - countSortArray[i];
            }


            var nextSymbolsIndex = new int[convertedString.Length];
            for (var i = 0; i < convertedString.Length; ++i)
            {
                nextSymbolsIndex[countSortArray[convertedString[i]]] = i;
                countSortArray[convertedString[i]]++;
            }

            var nextSymbol = nextSymbolsIndex[tableIndex];
            var answer = new char[convertedString.Length];
            for (int i = 0; i < convertedString.Length; ++i)
            {
                answer[i] = convertedString[nextSymbol];
                nextSymbol = nextSymbolsIndex[nextSymbol];
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
            return true;
        }
        static void Main(string[] args)
        {
            //if (!tests())
            //{
            //    Console.WriteLine("Tests failed");
            //    return;
            //}

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
            //Console.WriteLine("\n" + inputStringIndex + "\n");
            Console.WriteLine("String after BWT: " + stringAfterBWT);
            var reverseResult = ReverseConversion(stringAfterBWT, inputStringIndex);
            Console.WriteLine("String after reverse BWT: " + reverseResult);
        }

    }
}