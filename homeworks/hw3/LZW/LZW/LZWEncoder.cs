namespace LZW;

using TrieLibrary;

internal static class LZWEncoder
{
    private static Trie InitTrie()
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
        var trie = InitTrie();
        
    }
}
