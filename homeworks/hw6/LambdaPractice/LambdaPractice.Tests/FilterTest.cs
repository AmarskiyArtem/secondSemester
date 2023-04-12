namespace LambdaPractice.Tests;

public class FilterTest
{
    [Test]
    public void IntTest()
    {
        var testList = Funcs.Filter<int>(new List<int>() { 1, 2, 3, 4, 5, 6 }, x => x % 2 == 0);
        var expectedResult = new List<int> { 2, 4, 6 };
        Assert.That(testList, Is.EqualTo(expectedResult));
    }

    [Test]
    public void StringTest()
    {
        var testList = Funcs.Filter<string>(new List<string>() {"One", "12", "424567", "Nan", "Inf" }, x => int.TryParse(x, out _));
        var expectedResult = new List<string> { "12", "424567" };
        Assert.That(testList, Is.EqualTo(expectedResult));
    }
}
