namespace TrieHomework;

using System.Collections.Generic;

/// <summary>
/// Trie data structure
/// </summary>
public class Trie
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; } = new();

        public bool IsTerminate { get; set; }

        public int WordsWithSamePrefix { get; set; }
    }

    private readonly TrieNode root = new ();

    private bool isEmptyStringAdded;

    public int Size { get; private set; }

    /// <summary>
    /// Add word to trie.
    /// </summary>
    /// <param name="word">Word to add</param>
    /// <returns>false if the word already been added otherwise true</returns>
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

    /// <summary>
    /// Check if word contatins in the trie
    /// </summary>
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

    /// <summary>
    /// Remove element from the trie. 
    /// </summary>
    /// <returns>true if successful, false if element is not contained in the trie</returns>
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

    /// <summary>
    /// Return how many word added to the trie starts with the passed prefix
    /// </summary>
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

