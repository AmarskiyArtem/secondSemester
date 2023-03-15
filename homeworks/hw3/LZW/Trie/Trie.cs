namespace TrieLibrary;

using System.Collections.Generic;

// Trie data structure
public class Trie
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; } = new();

        public bool IsTerminate { get; set; }

        public int WordsWithSamePrefix { get; set; }
    }

    private readonly TrieNode root = new();

    private bool isEmptyStringAdded;

    public int Size { get; private set; }

    // Add word to trie. Returns false if the word already been added otherwise true
    public bool Add(string word)
    {
        if (word == "")
        {
            if (isEmptyStringAdded)
            {
                return false;
            }
            isEmptyStringAdded = true;
            this.Size++;
            return true;
        }

        if (Contains(word))
        {
            return false;
        }

        TrieNode node = this.root;
        foreach (var ch in word)
        {
            if (!node.Children.ContainsKey(ch))
            {
                node.Children[ch] = new TrieNode();
            }
            node.WordsWithSamePrefix++;
            node = node.Children[ch];
        }
        node.WordsWithSamePrefix++;
        node.IsTerminate = true;
        this.Size++;
        return true;
    }

    public bool Add(char[] sequence)
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
        foreach (var ch in sequence)
        {
            if (!node.Children.ContainsKey(ch))
            {
                node.Children[ch] = new TrieNode();
            }
            node.WordsWithSamePrefix++;
            node = node.Children[ch];
        }
        node.WordsWithSamePrefix++;
        node.IsTerminate = true;
        this.Size++;
        return true;
    }

    // Check if word contatins in the trie
    public bool Contains(string word)
    {
        if (word == "")
        {
            return isEmptyStringAdded;
        }

        TrieNode node = this.root;
        foreach (var ch in word)
        {
            if (!node.Children.ContainsKey(ch))
            {
                return false;
            }
            node = node.Children[ch];
        }
        return node.IsTerminate;
    }

    public bool Contains(char[] sequence)
    {
        return Contains(new string(sequence));
    }

    // Remove element from the trie. Returns true if successful, false if element 
    // is not contained in the trie
    public bool Remove(string word)
    {
        if (word == "")
        {
            if (isEmptyStringAdded)
            {
                isEmptyStringAdded = false;
                return true;
            }
            return false;
        }

        if (!Contains(word))
        {
            return false;
        }

        TrieNode node = this.root;
        foreach (var ch in word)
        {
            node.WordsWithSamePrefix--;
            node = node.Children[ch];
        }
        node.IsTerminate = false;
        this.Size--;
        return true;

    }

    // Return how many word added to the trie starts with the passed prefix
    public int HowManyStartsWithPrefix(string prefix)
    {
        if (prefix == "")
        {
            return Convert.ToInt32(isEmptyStringAdded);
        }
        TrieNode node = this.root;
        foreach (var ch in prefix)
        {
            if (!node.Children.ContainsKey(ch))
            {
                return 0;
            }
            node = node.Children[ch];
        }
        return node.WordsWithSamePrefix;
    }
}