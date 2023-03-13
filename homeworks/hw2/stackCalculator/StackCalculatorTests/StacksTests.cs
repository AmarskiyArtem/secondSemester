using StackCalculator;

namespace StackCalculatorTests;

public class StacksTests
{
    private static IEnumerable<TestCaseData> Stack()
    {
        yield return new TestCaseData(new StackOnLinkedList());
        yield return new TestCaseData(new StackOnList());
    }

    [TestCaseSource(nameof(Stack))]
    public void PushAndTopShouldSameValue(IStack stack)
    {
        stack.Push(1);
        Assert.That(stack.Top, Is.EqualTo(1));
    }

    [TestCaseSource(nameof(Stack))]
    public void TwoPushAndTwoTopShouldSameValue(IStack stack)
    {
        stack.Push(2);
        stack.Push(3);
        Assert.That(stack.Top, Is.EqualTo(3));
        stack.Pop();
        Assert.That(stack.Top, Is.EqualTo(2));
    }

    [TestCaseSource(nameof(Stack))]
    public void TopFromEmptyStackShouldException(IStack stack)
    {
        Assert.Throws<InvalidOperationException>(() => stack.Top());
    }

    [TestCaseSource(nameof(Stack))]
    public void PopFromEmptyStackShouldException(IStack stack)
    {
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
}
