namespace BWT
{
    class Programm
    {
        static (string, int) DirectConversion(string originalString)
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
            //countSortArray[i] to first position i-symbol inn 1st column
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

        static void Main(string[] args)
        {
            //Console.WriteLine("Input a string");
            //string? input = Console.ReadLine();
            var input = "AVACABA";
            var DirectBWTResult = DirectConversion(input);
            var stringAfterBWT = DirectBWTResult.Item1;
            var inputStringIndex = DirectBWTResult.Item2;
            var reverseResult = ReverseConversion(stringAfterBWT, inputStringIndex);
        }

    }
}