namespace Trie;

using System.Collections.Generic;

internal class Trie
{
    private class TrieNode
    {
        public TrieNode() 
        {
            this.children = new Dictionary<char, TrieNode>();
            this.IsTerminate = false;
        }
        public Dictionary<char, TrieNode> children;
        public bool IsTerminate { get; set; }
    }

    public Trie()
    {
        this.root = new TrieNode();
        this.Size = 0;
        this.isEmptyStringAdded = false;
    }

    private readonly TrieNode root;

    private bool isEmptyStringAdded;

    public int Size { get; private set; }

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

        TrieNode node = this.root;
        foreach (var ch in word)
        {
            if (!node.children.ContainsKey(ch))
            {
                node.children[ch] = new TrieNode();
            }
            node = node.children[ch];
        }
        if (node.IsTerminate) 
        {
            return false;
        }
        node.IsTerminate = true;
        this.Size++;
        return true;
    }

    public bool Contains(string word)
    {
        if (word == "")
        {
            return isEmptyStringAdded;
        }

        TrieNode node = this.root;
        foreach (var ch in word)
        {
            if (!node.children.ContainsKey(ch))
            {
                return false;
            }
            node = node.children[ch];
        }
        return node.IsTerminate;
    }

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

        TrieNode node = this.root;
        foreach (var ch in word)
        {
            if (!node.children.ContainsKey(ch))
            {
                return false;
            }
            node = node.children[ch];
        }
        if (node.IsTerminate)
        {
            node.IsTerminate = false;
            this.Size--;
            return true;
        }
        return false;
    }

    private int CountWords(TrieNode node)
    {
        var result = Convert.ToInt32(node.IsTerminate);
        foreach (var key in node.children.Keys)
        {
            result += CountWords(node.children[key]);
        }
        return result;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        TrieNode node = this.root;
        foreach (var ch in prefix)
        {
            if (!node.children.ContainsKey(ch))
            {
                return 0;
            }
            node = node.children[ch];
        }
        return CountWords(node);
    }
}

