namespace UniqueListTests;

public class ListsTests
{
    private UniqueListLibrary.List list = new();

    [SetUp]
    public void Setup()
    {
        list = new();
        FillList(list);

    }

    private static void FillList(UniqueListLibrary.List list)
    {
        for (var i = 5; i >= 0; i--)
        {
            list.Push(i);
            Assert.That(list.Size, Is.EqualTo(6 - i));
        }
    }

    [Test]
    public void PushToTheHeadTestShouldGiveSameValuesAndRightSize()
    {
        for (var i = 0; i < 5; i++)
        {
            Assert.That(list.Get(i), Is.EqualTo(i));
        }

        Assert.That(list.Size, Is.EqualTo(6));
    }

    [Test]
    public void InsertToHeadTailMiddleShouldRightInsertion()
    {
        list.Insert(10, 2);
        list.Insert(11, 5);
        list.Insert(12, 0);
        list.Insert(44, 9);
        var rightOrder = new int[] { 12, 0, 1, 10, 2, 3, 11, 4, 5, 44};
        for (int i = 0; i < list.Size; ++i)
        {
            Assert.That(list.Get(i), Is.EqualTo(rightOrder[i]));
        }
    }

    [Test]
    public void InsertToInvalidIndexShouldException()
    {
        Assert.Throws<IndexOutOfRangeException> (() => list.Insert(0, -1));
        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(0, 7));
    }

    [Test]
    public void RemoveFromHeadShouldChangeHeadPointer()
    {
        list.Remove(0);
        Assert.Multiple(() =>
        {
            Assert.That(list.Size, Is.EqualTo(5));
            Assert.That(list.Get(0), Is.EqualTo(1));
        });
    }

    [Test]
    public void RemoveFromTailAndMiddleShouldExpectedReaction()
    {
        list.Remove(1);
        Assert.Multiple(() =>
        {
            Assert.That(list.Size, Is.EqualTo(5));
            Assert.That(list.Get(0), Is.EqualTo(0));
            Assert.That(list.Get(1), Is.EqualTo(2));
        });
        list.Remove(4);
        Assert.That(list.Get(3), Is.EqualTo(4));
    }

    [Test]
    public void RemoveWithInvalidIndexShouldException()
    {
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove (-1));
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(7));
    }

    [Test]
    public void ChangeValuesInHeadTailMiddleShouldExpectedReaction()
    {
        list.ChangeValueByIndex(10, 0);
        list.ChangeValueByIndex(20, 3);
        list.ChangeValueByIndex(30, 5);
        var rightList = new int[] { 10, 1, 2, 20, 4, 30 };
        for (int i = 0; i < list.Size; ++i)
        {
            Assert.That(list.Get(i), Is.EqualTo(rightList[i]));
        }
    }

    [Test]
    public void ChangeWithInvalidIndexShouldException()
    {
        Assert.Throws<IndexOutOfRangeException>(() => list.ChangeValueByIndex(10, -1));
        Assert.Throws<IndexOutOfRangeException>(() => list.ChangeValueByIndex(20, 7));
    }
}