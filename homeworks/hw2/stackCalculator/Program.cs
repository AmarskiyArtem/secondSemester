namespace StackCalculator;

using System;

class Programm
{

    static void Main()
    {
        Console.WriteLine("Enter math expression in postfix form");
        var expression = Console.ReadLine();

        expression = null;
        var listStack = new StackOnList();
        Console.WriteLine("Calculation result using stack on list");
        Console.WriteLine(StackCalculator.CalculatePostfixExpression(expression, listStack));

        var linkedListStack = new StackOnLinkedList();
        Console.WriteLine("Calculation result using stack on linked list");
        Console.WriteLine(StackCalculator.CalculatePostfixExpression(expression, linkedListStack));
    }
}