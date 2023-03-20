namespace ParsingTreeTests;

public class TreeTests
{
    [Test]
    public void CommonExpressionShouldRightAnswer()
    {
        var tree = new ParsingTree("(* (+ 11 10) 20)");
        Assert.That(tree.CalculateTree(), Is.EqualTo(420).Within(0.001));
    }

    [Test]
    public void DivisionByZeroShouldException()
    {
        var tree = new ParsingTree("+( / 1 0) 3");
        Assert.Throws<DivideByZeroException>(() => tree.CalculateTree());
    }

    [Test]
    public void ExtraOperationsShouldException()
    {
        Assert.Throws<ArgumentException>(() => new ParsingTree("(- +(* 61 3) 4)"));
    }

    [Test]
    public void ExtraOperandsShouldException()
    {
        Assert.Throws<ArgumentException>(() => new ParsingTree("+ 45 43 34"));
    }

    [Test]
    public void EmptyStringShouldException()
    {
        var e = Assert.Throws<ArgumentException>(() => new ParsingTree(String.Empty));
        Assert.That(e.Message, Is.EqualTo("String is empty."));
    }

    [Test]
    public void NullStringShouldException()
    {
        var e = Assert.Throws<ArgumentNullException>(() => new ParsingTree(null));
    }
}