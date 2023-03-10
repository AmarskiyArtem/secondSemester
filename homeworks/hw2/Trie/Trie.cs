namespace TrieHomework;

using System.Collections.Generic;

// Trie data structure
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
            if (!node.children.ContainsKey(ch))
            {
                return false;
            }
            node = node.children[ch];
        }
        return node.IsTerminate;
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

    // Return how many word added to the trie starts with the passed prefix
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

    // Tests
    static public bool Tests()
    {
        Trie testTrie = new Trie();
        if (!testTrie.Add("Cat") || testTrie.Size != 1)
        {
            return false;
        }
        if (!testTrie.Add("Catyy") || testTrie.Size != 2)
        {
            return false;
        }
        if (!testTrie.Add("CatLand") || testTrie.Size != 3)
        {
            return false;
        }
        if (!testTrie.Add("SomeAnotherPrefix") || testTrie.Size != 4)
        {
            return false;
        }
        if (!testTrie.Contains("Catyy") || testTrie.Contains("WordWhichDontExist"))
        {
            return false;
        }
        if (testTrie.HowManyStartsWithPrefix("Cat") != 3 || testTrie.HowManyStartsWithPrefix("Soma") != 0)
        {
            return false;
        }
        if (!testTrie.Remove("Cat") || testTrie.Size != 3 || testTrie.Remove("Cat"))
        {
            return false;
        }
        return testTrie.HowManyStartsWithPrefix("Ca") == 2;
    }
}

