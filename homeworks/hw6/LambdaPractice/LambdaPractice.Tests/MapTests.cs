namespace LambdaPractice.Tests;

public class MapTests
{

    [Test]
    public void IntToIntTest()
    {
        var testList = Funcs.Map<int, int>(new List<int> { 1, 2, 3, 8, 10 }, x => x + 5);
        var expectedResult = new List<int> { 6, 7, 8, 13, 15 };
        Assert.That(testList, Is.EqualTo(expectedResult));
    }

    [Test]
    public void StringToIntTest()
    {
        var testList = Funcs.Map<string, int>(new List<string> { "Hi", "Test", "Yeeee" }, x => x.Length);
        var expectedResult = new List<int> { 2, 4, 5 };
        Assert.That(testList, Is.EqualTo(expectedResult));
    }
}