namespace TrieLibraryTests;

using TrieHomework;

// If you somehow got here. Please, dont read it. AND NEVER TRY TO USE IT.
// If you want to see how I write unit tests, you can do it in any other task
public class TrieTest
{
    [Test]
    public void LonelyTest()
    {
        Trie testTrie = new();
        Assert.That(testTrie.Add("Cat"), Is.True);
        Assert.That(testTrie.Add("Catyy"), Is.True);
        Assert.That(testTrie.Add("CatLand"), Is.True);
        Assert.That(testTrie.Add("SomeAnotherPrefix"), Is.True);
        Assert.That(testTrie.Size, Is.EqualTo(4));
        Assert.IsTrue(testTrie.Contains("Catyy"));
        Assert.IsFalse(testTrie.Contains("WordWhichDontExist"));
        Assert.That(testTrie.HowManyStartsWithPrefix("Cat"), Is.EqualTo(3));
        Assert.That(testTrie.HowManyStartsWithPrefix("Soma"), Is.EqualTo(0));
        Assert.IsTrue(testTrie.Remove("Cat"));
        Assert.IsFalse(testTrie.Remove("Cat"));
        Assert.That(testTrie.Size, Is.EqualTo(3));
        Assert.That(testTrie.HowManyStartsWithPrefix("Ca"), Is.EqualTo(2));
    }
}