namespace TrieLibrary;

using System.Collections.Generic;

// Trie data structure
public class Trie
{
    private class TrieNode
    {
        public TrieNode(int value) 
        {
            Value = value;
            Children = new();
        }
        public Dictionary<byte, TrieNode> Children { get; set; } = new();

        public bool IsTerminate { get; set; }

        public int SequencesWithSamePrefix { get; set; }

        public int Value { get; private set; }
    }

    public Trie() { }

    private readonly TrieNode root = new(-1);

    private bool isEmptyStringAdded;

    public int Size { get; private set; }

    // Add sequence to trie. Returns false if the sequence already been added otherwise true
    public bool Add(List<byte> sequence)
    {
        if (sequence.Count == 0)
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

        var node = this.root;
        foreach (var bt in sequence)
        {
            if (!node.Children.ContainsKey(bt))
            {
                node.Children[bt] = new TrieNode(Size);
                Size++;
            }
            node.SequencesWithSamePrefix++;
            node = node.Children[bt];
        }
        node.SequencesWithSamePrefix++;
        node.IsTerminate = true;
        return true;
    }

    // Check if sequence contatins in the trie
    public bool Contains(List<byte> sequence)
    {
        if (sequence.Count == 0)
        {
            return isEmptyStringAdded;
        }

        var node = this.root;
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
    public bool Remove(List<byte> sequence)
    {
        if (sequence.Count == 0)
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

        var node = this.root;
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
    public int HowManyStartsWithPrefix(List<byte> prefix)
    {
        if (prefix.Count == 0)
        {
            return Convert.ToInt32(isEmptyStringAdded);
        }
        var node = this.root;
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

    public int Get(List<byte> sequence)
    {
        var node = this.root;
        foreach (var bt in sequence)
        {
            node = node.Children[bt];
        }
        return node.Value;
    }
}