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
            Console.WriteLine("Calculation result using stack on list");
            Console.WriteLine(StackCalculator.CalculatePostfixExpression(expression, listStack));

            var linkedListStack = new StackOnLinkedList();
            Console.WriteLine("Calculation result using stack on linked list");
            Console.WriteLine(StackCalculator.CalculatePostfixExpression(expression, linkedListStack));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error! " + ex.Message);
        }
    }
}