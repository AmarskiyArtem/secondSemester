using System;
using System.Text;

namespace BWT
{
    class Programm
    {
        static string DirectConversion(string originalString, ref int resultStringIndex)
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
            //Console.WriteLine("{0}", string.Join("\n", shiftTable));
            string result = "";
            for (var i = 0; i < shiftTable.Length; i++)
            {
                result += shiftTable[i][shiftTable.Length - 1];
            }
            resultStringIndex = Array.IndexOf(shiftTable, originalString);
            return result;
        }

        static string ReverseConversion(string convertedString, int tableIndex)
        {
            var count = new int[(int)char.MaxValue];
            for (var i = 0; i < convertedString.Length; ++i)
            {
                ++count[convertedString[i]];
            }
            var sum = 0;
            for (var i = 0; i < (int)char.MaxValue; ++i) 
            { 
                sum += count[i];
                count[i] = sum - count[i];
            }
            var t = new int[convertedString.Length];
            for (var i = 0; i < convertedString.Length; ++i)
            {
                t[count[convertedString[i]]] = i;
                count[convertedString[i]]++;
            }
            var j = t[tableIndex];
            var answer = new char[convertedString.Length];
            for (int i = 0; i < convertedString.Length; ++i)
            {
                answer[i] = convertedString[j];
                j = t[j];
            }

            return string.Join("", answer);
        }
        static void Main(string[] args)
        {
            var str = "ABACABA";
            var resultIndex = 0;
            var newStr = DirectConversion(str, ref resultIndex);
            //Console.WriteLine(resultIndex);
            Console.WriteLine(ReverseConversion(newStr, resultIndex));
        }

    }
}