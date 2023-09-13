namespace MostCommonElement.Tests;


public class MostCommonTests
{
    [Test]
    public void IntegersShouldExpectedAnswer()
    {
        var input = new List<int> { 1, 2, 3, 2, 2, 4, 5, 5, 5, 5 };
        var mostCommon = MostCommon.GetMostCommonElement(input);
        Assert.That(mostCommon, Is.EqualTo(5));
    }

    [Test]
    public void StringssShouldExpectedAnswer()
    {
        var input = new List<string> { "apple", "banana", "apple", "apple", "orange", "banana" };
        var mostCommon = MostCommon.GetMostCommonElement(input);
        Assert.That(mostCommon, Is.EqualTo("apple"));
    }

    [Test]
    public void EmptyListShouldException()
    {
        var input = new List<int>();
        Assert.Throws<ArgumentException>(() => MostCommon.GetMostCommonElement(input));
    }

    [Test]
    public void AllElementsHaveTheSameFrequencyShouldFirst()
    {
        var input = new List<int> { 1, 3, 1, 3, 4, 4, 5, 5 };
        var mostCommon = MostCommon.GetMostCommonElement(input);
        Assert.That(mostCommon, Is.EqualTo(1));
    }
}