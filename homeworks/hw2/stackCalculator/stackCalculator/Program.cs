using StackCalculator;


if (!(PostfixCalculator.Tests() && StackOnList.Tests() && StackOnLinkedList.Tests()))
{
    Console.WriteLine("Tests failed");
    return;
}

Console.WriteLine("Enter math expression in postfix form");
var expression = Console.ReadLine();

try
{
    var listStack = new StackOnList();
    var result = PostfixCalculator.CalculatePostfixExpression(expression, listStack);
    Console.WriteLine("Calculation result using stack on list: " + result);

    var linkedListStack = new StackOnLinkedList();
    result = PostfixCalculator.CalculatePostfixExpression(expression, linkedListStack);
    Console.WriteLine("Calculation result using stack on linked list: " + result);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Error! " + ex.Message);
}
catch (ArgumentException ex)
{
    Console.WriteLine("Error! " + ex.Message);
}



