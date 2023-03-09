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
    }

    private TrieNode root;

    public bool Add(string word)
    {
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
        return true;
    }
    public bool Remove(string word) { return false; }

    public bool Contains(string word)
    {
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

    public int HowManyStartsWithPrefix(string prefix)
    {
        return 0;
    }
}

