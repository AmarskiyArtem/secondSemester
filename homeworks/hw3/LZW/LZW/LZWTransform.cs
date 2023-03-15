namespace LZW;

using TrieLibrary;
using System.Collections.Generic;

public class LZWTransform
{
    private const byte alphabetSize = 65536;

    private static List<byte> FilledList()
    {
        var list = new List<byte>();
        for (byte i = 0; i < alphabetSize; ++i)
        {
            list.Add((byte)i);
        }
        return list;
    }

    public static byte[] Compress(byte[] input)
    {
        Trie trie = new();
        var currentIndex = 0;
        var output = new List<byte>();
        
        while (currentIndex < input.Length)
        {
            var bt = input[currentIndex];
            currentIndex++;
        }
        return null;
    }
}
