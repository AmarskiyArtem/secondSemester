namespace LZW;

using LZW.Buffers;
using TrieLibrary;

internal static class LZWEncoder
{
    private static Trie FillTrieBySingleByteSequences()
    {
        Trie trie = new Trie();
        for (var i = 0; i < 256; i++)
        {
            trie.Add(new List<byte> { (byte)i }, i);
        }
        return trie;
    }

    public static byte[] Encode(byte[] data)
    {
        var trie = FillTrieBySingleByteSequences();
        var buffer = new CompressByteBuffer();
        buffer.Data.Add(0);
        var notRecordedSequence = new List<byte>();
        var currentTrieMaxSize = 512;
        const int trieMaxSize = 65536;
        for (var i = 0; i < data.Length; i++)
        {
            var newSequence = new List<byte>(notRecordedSequence) { data[i] };
            if (trie.Contains(newSequence))
            {
                notRecordedSequence = newSequence;
            }
            else
            {
                buffer.AddNumberToData(trie.Get(notRecordedSequence));
                if (trie.Size == trieMaxSize)
                {
                    trie = FillTrieBySingleByteSequences();
                    currentTrieMaxSize = 512;
                    buffer.CurrentNumberOfBitsPerNumber = 9;
                }
                if (trie.Size == currentTrieMaxSize)
                {
                    buffer.CurrentNumberOfBitsPerNumber++;
                    currentTrieMaxSize *= 2;
                }
                trie.Add(newSequence, trie.Size);
                notRecordedSequence.Clear();
                notRecordedSequence.Add(data[i]);
            }
        }

        if (buffer.CurrentByte != 0)
        {
            buffer.Data[0] = 1;
        }

        buffer.AddLastByte();
        return buffer.Data.ToArray();
    }
}
