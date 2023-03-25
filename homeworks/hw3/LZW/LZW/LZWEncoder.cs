namespace LZW;

using TrieLibrary;

/// <summary>
/// Class for LZW (optional with BWT) encode, works with byte[]
/// </summary>
internal static partial class LZWEncoder
{
    private static Trie FillTrieBySingleByteSequences()
    {
        var trie = new Trie();
        for (var i = 0; i < 256; i++)
        {
            trie.Add(new List<byte> { (byte)i });
        }
        return trie;
    }

    /// <summary>
    /// Encode byte[]
    /// </summary>
    /// <param name="data">bytes</param>
    /// <param name="withBWT">Flag whether to use BWT when compressing</param>
    /// <returns>Encoded data</returns>
    public static byte[] Encode(byte[] data, bool withBWT)
    {
        
        var buffer = new CompressByteBuffer();
        if (withBWT)
        {
            int dataIndex;
            (data, dataIndex) = BWTransform.BWT.FastDirectConversion(data);
            buffer.Data.AddRange(BitConverter.GetBytes(dataIndex));
        }
        var trie = FillTrieBySingleByteSequences();
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
                trie.Add(newSequence);
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
                notRecordedSequence.Clear();
                notRecordedSequence.Add(data[i]);
            }
        }
        buffer.AddNumberToData(trie.Get(notRecordedSequence));
        if (buffer.CurrentNumberOfBitsPerNumber != 0)
        {
            buffer.AddByteToData();
        }
        return buffer.Data.ToArray();
    }
}
