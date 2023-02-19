using System;

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
                char lastChar = shifts[originalString.Length - 1];
                shifts = lastChar + shifts.Substring(0, shifts.Length - 1);
                shiftTable[i] = shifts;
            }
            Array.Sort(shiftTable);
            string result = "";
            for (var i = 0; i < shiftTable.Length; i++)
            {
                result += shiftTable[i][shiftTable.Length - 1];
            }
            resultStringIndex = Array.IndexOf(shiftTable, result) + 1;
            return result;
        }
        static void Main(string[] args)
        {
            var str = "123456";
            int resultIndex = 0;
            Console.WriteLine(DirectConversion(str, ref resultIndex));
            Console.WriteLine(resultIndex);
        }
    }
}