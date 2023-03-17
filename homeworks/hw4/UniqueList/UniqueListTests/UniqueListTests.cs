namespace UniqueListTests;


public class UniqueListTests
{
    private UniqueList uniqueList = new();

    [SetUp]
    public void Setup()
    {
        uniqueList = new();
        ListsTests.FillList(uniqueList);
    }

    [Test]
    public void PushAlreadyExistingShouldException()
    {
        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Push(0));
        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Push(4));
    }

    [Test]
    public void InsertAlreadyExistingShouldException()
    {
        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Insert(3, 5));
    }

    [Test]
    public void ChangeValueToAlreadyExistingShouldException()
    {
        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.ChangeValueByIndex(0, 3));
    }

    [Test]
    public void ChangeValueToTheSameShouldNothingChange()
    {
        uniqueList.ChangeValueByIndex(1, 1);
        Assert.That(uniqueList.Get(1), Is.EqualTo(1));
    }
}
