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

namespace LZW;

/// <summary>
/// Class for LZW (with BWT) decode, works with byte[]
/// </summary>
public partial class LZWDecoder
{
    const int maxAmountOfRecords = 65536;

    /// <summary>
    /// Decodes byte[]
    /// </summary>
    /// <param name="data">coded data</param>
    /// <returns>Decoded data</returns>
    public static byte[] Decode(byte[] data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }
        if (data.Length == 0)
        {
            throw new ArgumentException("data can't be empty");
        }

        var output = new List<byte>();
        var dictionary = FillDictBySingleByteSequences();
        var numbers = GetNumbers(data[4..]);
        var dictionaryPoiner = 256;
        var dictionarySize = 256;
        var sequence = new List<byte>();
        for (var i = 0; i < numbers.Count; i++)
        {
            if (dictionarySize == maxAmountOfRecords)
            {
                dictionary = FillDictBySingleByteSequences();
                dictionarySize = 256;
                dictionaryPoiner = 256;
            }
            if (dictionary.ContainsKey(numbers[i]))
            {
                if (dictionarySize != 256)
                {
                    while (dictionary.ContainsKey(dictionaryPoiner))
                    {
                        dictionaryPoiner++;
                    }
                    sequence = new List<byte>(dictionary[numbers[i - 1]]) { dictionary[numbers[i]][0] };
                    dictionary.Add(dictionaryPoiner, sequence);
                    ++dictionaryPoiner;
                }
                output.AddRange(dictionary[numbers[i]]);
            }
            else
            {
                sequence = new List<byte>(dictionary[numbers[i - 1]]) { dictionary[numbers[i - 1]][0] };
                dictionary.Add(numbers[i], sequence);
                output.AddRange(sequence);
            }
            dictionarySize++;
        }
        return BWTransform.BWT.ReverseConversion(output.ToArray(), BitConverter.ToInt32(data[0..4]));
    }

    private static Dictionary<int, List<byte>> FillDictBySingleByteSequences()
    {
        var dictionary = new Dictionary<int, List<byte>>();
        for (int i = 0; i < 256; i++)
        {
            dictionary[i] = new List<byte>() { (byte)i };
        }
        return dictionary;
    }

    private static List<int> GetNumbers(byte[] data)
    {
        var buffer = new DecompressByteBuffer();
        var amountOfRecords = 256;
        var maxAmountOfRecordsWithCurrentBitsPerNumber = 512;
        for (var i = 0; i < data.Length - 1; i++)
        {
            if (amountOfRecords == maxAmountOfRecords)
            {
                amountOfRecords = 256;
                maxAmountOfRecordsWithCurrentBitsPerNumber = 512;
                buffer.CurrentBitsPerNumber = 9;
            }
            if (amountOfRecords == maxAmountOfRecordsWithCurrentBitsPerNumber)
            {
                maxAmountOfRecordsWithCurrentBitsPerNumber *= 2;
                buffer.CurrentBitsPerNumber++;
            }
            if (buffer.AddByteToData(data[i]))
            {
                amountOfRecords++;
            }
        }
        if (buffer.BitsInCurrentNumber + 8 == buffer.CurrentBitsPerNumber)
        {
            buffer.AddByteToData(data[^1]);
        }
        else
        {
            buffer.AddLastByteToData(data[^1]);
        }
        return buffer.Data;
    }
}
