namespace BracketBalance.Tests;
public class StackTests
{

    Stack<int> stack = new();

    [SetUp]
    public void Setup()
    {
        stack = new();
    }

    [Test]
    public void PushAndTopShouldSameValue()
    {
        stack.Push(1);
        Assert.That(stack.Top(), Is.EqualTo(1));
    }

    [Test]
    public void TwoPushAndTwoTopShouldSameValue()
    {
        stack.Push(2);
        stack.Push(3);
        Assert.That(stack.Top, Is.EqualTo(3));
        stack.Pop();
        Assert.That(stack.Top, Is.EqualTo(2));
    }

    [Test]
    public void TopFromEmptyStackShouldException()
    {
        Assert.Throws<InvalidOperationException>(() => stack.Top());
    }

    [Test]
    public void PopFromEmptyStackShouldException()
    {
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

}
