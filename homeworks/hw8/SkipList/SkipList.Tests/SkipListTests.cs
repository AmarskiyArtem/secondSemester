namespace SkipListLibrary.Tests;

public class Tests
{
    private SkipList<int> skipList = new();

    [SetUp]
    public void Setup()
        => skipList = new SkipList<int>();

    private void FillSkipList()
    {
        for (int i = 0; i < 100; i++)
        {
            skipList.Add(i);
        }
        Assert.That(skipList.Count, Is.EqualTo(100));
    }

    [Test]
    public void ChangeIteratorShouldThrowsException()
    {
        FillSkipList();
        var iterator = skipList.GetEnumerator();
        iterator.MoveNext();
        skipList.Remove(31);
        Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }

    [Test]
    public void ForeachTestShouldRightSum()
    {
        FillSkipList();
        var sum = 0;
        foreach (var element in skipList)
        {
            sum += element;
        }
        Assert.That(sum, Is.EqualTo(4950));
    }

    [Test]
    public void IndexTestShouldRightOrder()
    {
        for (var i = 100; i >= 0; i -= 2)
        {
            skipList.Add(i);
        }
        for (var i = 0; i <= 50; i++)
        {
            Assert.That(skipList[i], Is.EqualTo(i * 2));
        }
    }

    [Test]
    public void ContainsNotExistingElementShouldFalse()
        => Assert.That(skipList.Contains(0), Is.False);

    [Test]
    public void RemoveElementAndAfterContainsShouldFalse()
    {
        skipList.Add(1);
        skipList.Add(2);
        skipList.Add(3);
        skipList.Remove(2);
        Assert.That(skipList.Contains(2), Is.False);
    }

    [Test]
    public void ContainsExistingElementShouldTrue()
    {
        FillSkipList();
        for (var i = 0; i < 100; ++i)
        {
            Assert.That(skipList.Contains(i), Is.True);
        }
    }

    [Test]
    public void CopyToTest()
    {
        FillSkipList();
        var array = new int[100];
        skipList.CopyTo(array, 0);
        for (var i = 0; i < 100; ++i)
        {
            Assert.That(array[i], Is.EqualTo(i));
        }
    }

    [Test]
    public void ClearTestShouldEmptySkipList()
    {
        FillSkipList();
        skipList.Clear();
        Assert.That(skipList.Count, Is.EqualTo(0));
    }

    [Test]
    public void IndexOfTestShouldRightIndexes()
    {
        for (var i = 0; i < 100; i++)
        {
            skipList.Add(i * 2);
        }
        for (var i = 0; i < 100; ++i)
        {
            Assert.That(skipList.IndexOf(i * 2), Is.EqualTo(i));
        }
    }
}