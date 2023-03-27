namespace BWTLibraryTests;

public class BWTTests
{
    [Test]
    public void DirectAndReverseConversionsShouldRightAnswer()
    {
        var original = "ABACABA";
        var (result, index) = BWTTransform.FastDirectConversion(original);
        Assert.That(original, Is.EqualTo(BWTTransform.ReverseConversion(result, index)));
    }

    [Test]
    public void EmptyStringShouldException()
    {
        Assert.Throws<ArgumentException>(() => BWTTransform.FastDirectConversion(String.Empty));
        Assert.Throws<ArgumentException>(() => BWTTransform.ReverseConversion(String.Empty, 0));
    }

    [Test]
    public void OnlyDirectShouldRightReturns()
    {
        var (result, index) = BWTTransform.FastDirectConversion("you want a different string instance");
        Assert.That(result, Is.EqualTo("tagtu twn rfcfindr aiiaeyetn nnsso e"));
        Assert.That(index, Is.EqualTo(35));
    }

    [Test]
    public void OnlyReverseShouldRightReturns()
    {
        var original = BWTTransform.ReverseConversion("a5* a4S6_ aaNnNb7 ", 16);
        Assert.That(original, Is.EqualTo("ba_Na * na45 NaS67"));
    }
}