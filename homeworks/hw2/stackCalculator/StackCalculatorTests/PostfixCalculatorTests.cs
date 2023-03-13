namespace StackCalculatorTests;

public class PostfixCalculatorTests
{
    private StackOnLinkedList stack;

    [SetUp]
    public void Setup()
    {
        stack = new StackOnLinkedList();
    }

    [Test]
    public void StandartExpessionShouldRightAnswer()
    {
        var result = PostfixCalculator.CalculatePostfixExpression("5 7 + 3 * 4 /", stack);
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void OnlyOneNumberShouldReturnTheSame()
    {
        var result = PostfixCalculator.CalculatePostfixExpression("4", stack);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void DivideByZeroShouldException()
    {
        Assert.Throws<DivideByZeroException>(()
            => PostfixCalculator.CalculatePostfixExpression("1 5 3 / 5 3 / - /", stack));
    }

    [Test]
    public void ExtraNumbersShouldException()
    {
        var ex = Assert.Throws<ArgumentException>(()
            => PostfixCalculator.CalculatePostfixExpression("1 2 3 +", stack));
        Assert.That(ex.Message, Is.EqualTo("Incorrect math expression."));
    }

    [Test]
    public void ExtraOperandsShouldException()
    {
        var ex = Assert.Throws<ArgumentException>(()
            => PostfixCalculator.CalculatePostfixExpression("1 3 + -", stack));
        Assert.That(ex.Message, Is.EqualTo("Incorrect math expression."));
    }

    [Test]
    public void UnresolvedCharactersShouldException()
    {
        var ex = Assert.Throws<ArgumentException>(()
            => PostfixCalculator.CalculatePostfixExpression("1 3 + (5 5) *", stack));
        Assert.That(ex.Message, Is.EqualTo("Incorrect math expression."));
    }

}