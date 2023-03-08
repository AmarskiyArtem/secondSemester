namespace StackCalculator;

class Programm
{
    static void Main()
    {
        StackOnList stack = new StackOnList();
        stack.Push(1);
        stack.Push(2);
        System.Console.WriteLine(stack.Top());
        stack.Pop();
        System.Console.WriteLine(stack.Top());
    }
}