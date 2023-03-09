namespace StackCalculator;

using System;

class Programm
{

    static void Main()
    {
        if (!(StackCalculator.Tests() && StackOnList.Tests() && StackOnLinkedList.Tests()))
        {
            Console.WriteLine("Tests failed");
            return;
        }

        Console.WriteLine("Enter math expression in postfix form");
        var expression = Console.ReadLine();

        try
        {
            var listStack = new StackOnList();
            var result = StackCalculator.CalculatePostfixExpression(expression, listStack);
            Console.WriteLine("Calculation result using stack on list: " + result);

            var linkedListStack = new StackOnLinkedList();
            result = StackCalculator.CalculatePostfixExpression(expression, linkedListStack);
            Console.WriteLine("Calculation result using stack on linked list: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error! " + ex.Message);
        }
    }
}