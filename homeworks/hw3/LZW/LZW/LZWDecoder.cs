using LZW.Buffers;

namespace LZW;

internal class LZWDecoder
{
    const int maxAmountOfRecords = 65536;

    public static byte[] Decode(byte[] data)
    {
        var output = new List<byte>();
        var dictionary = FillDictBySingleByteSequences();
        var numbers = GetNumbers(data);
        var dicionarySize = 256;
        var dictionaryPoiner = 256;
        List<byte> sequence;
        for (var i = 0; i < numbers.Length; i++)
        {
            var number = numbers[i];
            if (dicionarySize == maxAmountOfRecords)
            {
                dictionary = FillDictBySingleByteSequences();
                dicionarySize = 256;
                dictionaryPoiner = 256;
            }
            if (dictionary.ContainsKey(number))
            {
                if (dicionarySize > 256)
                {
                    sequence = new List<byte>(dictionary[numbers[i - 1]]) { dictionary[number][0] };
                    while (dictionary.ContainsKey(dictionaryPoiner))
                    {
                        dictionaryPoiner++;
                    }
                    dictionary.Add(dictionaryPoiner, sequence);
                    dictionaryPoiner++;
                }
                output.AddRange(dictionary[number]);
            }
            else
            {
                sequence = new List<byte>(dictionary[numbers[i - 1]]) { dictionary[numbers[i - 1]][0] };
                dictionary.Add(number, sequence);
                output.AddRange(sequence);
            }
            dicionarySize++;
        }
        return output.ToArray();
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

    private static int[] GetNumbers(byte[] data)
    {
        var buffer = new DecompressByteBuffer();
        var amountOfRecords = 256;
        var maxAmountOfRecordsWithCurrentBitsPerNumber = 512;
        for (var i = 1; i < data.Length - 1; i++)
        {
            var bt = data[i];
            if (amountOfRecords == maxAmountOfRecordsWithCurrentBitsPerNumber)
            {
                maxAmountOfRecordsWithCurrentBitsPerNumber *= 2;
                buffer.BitsPerNumber++;
            }
            if (amountOfRecords == maxAmountOfRecords)
            {
                amountOfRecords = 256;
                maxAmountOfRecordsWithCurrentBitsPerNumber = 512;
                buffer.BitsPerNumber = 9;
            }
            if (buffer.AddByteToData(bt))
            {
                amountOfRecords++;
            }
        }
        if (data[0] == 1)
        {
            buffer.AddLastByteToData(data[^1]);
        }
        else
        {
            buffer.AddByteToData(data[^1]);
        }
        return buffer.Data.ToArray();
    }
}
