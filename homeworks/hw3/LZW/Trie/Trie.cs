namespace TrieLibrary;

using System.Collections.Generic;

// Trie data structure
public class Trie
{
    private class TrieNode
    {
        public Dictionary<byte, TrieNode> Children { get; set; } = new();

        public bool IsTerminate { get; set; }

        public int SequencesWithSamePrefix { get; set; }
    }

    private readonly TrieNode root = new();

    private bool isEmptyStringAdded;

    public int Size { get; private set; }

    // Add sequence to trie. Returns false if the sequence already been added otherwise true
    public bool Add(byte[] sequence)
    {
        if (sequence.Length == 0)
        {
            if (isEmptyStringAdded)
            {
                return false;
            }
            isEmptyStringAdded = true;
            this.Size++;
            return true;
        }

        if (Contains(sequence))
        {
            return false;
        }

        TrieNode node = this.root;
        foreach (var bt in sequence)
        {
            if (!node.Children.ContainsKey(bt))
            {
                node.Children[bt] = new TrieNode();
            }
            node.SequencesWithSamePrefix++;
            node = node.Children[bt];
        }
        node.SequencesWithSamePrefix++;
        node.IsTerminate = true;
        this.Size++;
        return true;
    }

    // Check if sequence contatins in the trie
    public bool Contains(byte[] sequence)
    {
        if (sequence.Length == 0)
        {
            return isEmptyStringAdded;
        }

        TrieNode node = this.root;
        foreach (var bt in sequence)
        {
            if (!node.Children.ContainsKey(bt))
            {
                return false;
            }
            node = node.Children[bt];
        }
        return node.IsTerminate;
    }

    // Remove element from the trie. Returns true if successful, false if element 
    // is not contained in the trie
    public bool Remove(byte[] sequence)
    {
        if (sequence.Length == 0)
        {
            if (isEmptyStringAdded)
            {
                isEmptyStringAdded = false;
                return true;
            }
            return false;
        }

        if (!Contains(sequence))
        {
            return false;
        }

        TrieNode node = this.root;
        foreach (var bt in sequence)
        {
            node.SequencesWithSamePrefix--;
            node = node.Children[bt];
        }
        node.IsTerminate = false;
        this.Size--;
        return true;

    }

    // Return how many word added to the trie starts with the passed prefix
    public int HowManyStartsWithPrefix(byte[] prefix)
    {
        if (prefix.Length == 0)
        {
            return Convert.ToInt32(isEmptyStringAdded);
        }
        TrieNode node = this.root;
        foreach (var bt in prefix)
        {
            if (!node.Children.ContainsKey(bt))
            {
                return 0;
            }
            node = node.Children[bt];
        }
        return node.SequencesWithSamePrefix;
    }

    static public bool Tests()
    {
        var testTrie = new Trie();
        byte[] a1 = { (byte)'C', (byte)'a', (byte)'t' };
        byte[] a2 = { (byte)'C', (byte)'a', (byte)'t', (byte)'t', (byte)'y' };
        byte[] a3 = { (byte)'C', (byte)'a', (byte)'t', (byte)'L', (byte)'A' };
        byte[] a4 = { (byte)'S', (byte)'o' };
        byte[] a5 = { (byte)'C', (byte)'a', (byte)'t', (byte)'O' };
        byte[] a6 = { (byte)'C', (byte)'a'};
        if (!testTrie.Add(a1) || testTrie.Size != 1)
        {
            return false;
        }
        if (!testTrie.Add(a2) || testTrie.Size != 2)
        {
            return false;
        }
        if (!testTrie.Add(a3) || testTrie.Size != 3)
        {
            return false;
        }
        if (!testTrie.Add(a4) || testTrie.Size != 4)
        {
            return false;
        }
        if (!testTrie.Contains(a2) || testTrie.Contains(a5))
        {
            return false;
        }
        if (testTrie.HowManyStartsWithPrefix(a1) != 3 || testTrie.HowManyStartsWithPrefix(a5) != 0)
        {
            return false;
        }
        if (!testTrie.Remove(a1) || testTrie.Size != 3 || testTrie.Remove(a1))
        {
            return false;
        }
        return testTrie.HowManyStartsWithPrefix(a6) == 2;
    }

}