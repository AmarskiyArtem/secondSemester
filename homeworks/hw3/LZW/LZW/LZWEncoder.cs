namespace LZW;

using TrieLibrary;

internal static class LZWEncoder
{
    public static byte[] Encode(byte[] data)
    {
        var trie = new Trie();
        for (var i = 0; i < 256; i++) 
        {
            trie.Add(new List<byte> { (byte)i }, i);
        }
        var output = new List<byte>();
        var currentSequence = new List<byte>();
        for (var i = 0; i < data.Length; i++)
        {
            var newSymbols = new List<byte>();
            newSymbols.AddRange(currentSequence);
            newSymbols.Add(data[i]);
            if (trie.Contains(newSymbols))
            {
                currentSequence = newSymbols;
            }
            else
            {
                var value = trie.Get(currentSequence);

            }
        }
        return new byte[5];
    }
}
