namespace CalculatorLibrary.Test;

public class CalculatorTests
{
    private Calculator calculator = new();

    [TearDown]
    public void Teardown()
        => calculator.Clear();
    

    private void addExpressionToCalc(string expression)
    {
        foreach (var chr in expression)
        {
            if (char.IsDigit(chr))
            {
                calculator.AddNumber(chr);
            }
            if ("+-*/x÷".Contains(chr))
            {
                calculator.AddOperation(chr);
            }
            if (chr == '=')
            {
                calculator.Calculate();
            }
        }
    }

    [Test]
    public void InvalidDataShouldException()
    {
        Assert.Throws<ArgumentException>(() => calculator.AddNumber('*'));
        Assert.Throws<ArgumentException>(() => calculator.AddOperation('5'));
    }

    [Test]
    public void DivideByZeroShouldError()
    {
        addExpressionToCalc("6 / 0");
        calculator.Calculate();
        Assert.That(calculator.CurrentResult, Is.EqualTo("Error"));
    }

    [TestCase("4 + 3 - 6 * 2", "2")]
    [TestCase("1 * 4 - 5 / 2", "-0,5")]
    public void SomeCalculationShouldRightAnswer(string expression, string expected)
    {
        addExpressionToCalc(expression);
        calculator.Calculate();
        Assert.That(calculator.CurrentResult, Is.EqualTo(expected));
    }

    [Test]
    public void ChangeSignShouldCorrectReaction()
    {
        addExpressionToCalc("76 + 4 / 2 - 1");
        calculator.Calculate();
        calculator.SwitchSign();
        Assert.That(calculator.CurrentResult, Is.EqualTo("-39"));
    }

    public void LotsOfOperationShouldCorrectAnswer()
    {
        addExpressionToCalc("43 +-*- 2");
        calculator.Calculate();
        Assert.That(calculator.CurrentResult, Is.EqualTo("41"));
    }
}