namespace UniqueListTests;


public class Tests
{
    private UniqueListLibrary.List list = new();

    [SetUp]
    public void Setup()
    {
        list = new();
    }

    [Test]
    public void PushToTheHeadTestShouldGiveSameValuesAndRightSize()
    {
        for (var i = 5; i >= 0; i--) 
        {
            list.Push(i);
            Assert.That(list.Size, Is.EqualTo(6 - i));
        }

        for (var i = 0; i < 5; i++)
        {
            Assert.That(list.Get(i), Is.EqualTo(i));
        }

        Assert.That(list.Size, Is.EqualTo(6));
    }

    [Test]
    public void Test2()
    {
        var list = new UniqueListLibrary.List();
        list.Push(5);
        list.Push(4);
        list.Push(3);
        list.Push(2);
        list.Push(1);
        list.Push(0);
        list.Insert(10, 2);
        list.Insert(11, 5);
        list.Insert(12, 0);
        list.Insert(44, 9);
        var a = new int[list.Size];
        for (int i = 0; i < list.Size; ++i)
        {
            a[i] = list.Get(i);
        }
        var b = 4;
        a[4] = 5;
    }
}