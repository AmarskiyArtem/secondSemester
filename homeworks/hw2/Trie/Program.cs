namespace Trie;

using System;

class Prorgam
{
    static void Main()
    {
        Trie trie = new Trie();
        trie.Add("Catyu");
        trie.Add("Catland");
        trie.Add("Catlaad");
        trie.Add("Catlandy");
        trie.Add("Fuck");
        Console.WriteLine(trie.HowManyStartsWithPrefix("Catl"));
        //Console.WriteLine(trie.Contains("LOLOL"));
        //Console.WriteLine(trie.Contains("LOUU"));
        //Console.WriteLine(trie.Remove("LOUU"));
        //Console.WriteLine(trie.Remove("LOUU"));
        //Console.WriteLine(trie.Contains("LOUU"));
        //Console.WriteLine(trie.Contains("bdshvn"));
        
    }
}