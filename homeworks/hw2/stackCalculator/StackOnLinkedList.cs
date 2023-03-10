namespace StackCalculator;

using System.Collections;
using System.Collections.Generic;

// Stack implementation using a linked list
internal class StackOnLinkedList : IStack
{

    public StackOnLinkedList() 
        => this.data = new();

    private readonly LinkedList<double> data;

    public void Push(double value)
        => this.data.AddFirst(value);

    public void Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        this.data.RemoveFirst();
    }

    public double Top()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return this.data.First();
    }

    public bool IsEmpty()
        => this.data.Count == 0;

    // Tests
    public static bool Tests()
    {
        var stack = new StackOnLinkedList();
        try
        {
            stack.Pop();
            return false;
        }
        catch (InvalidOperationException) { }
        stack.Push(5);
        stack.Push(8);
        stack.Push(4);
        if (stack.Top() != 4)
        {
            return false;
        }
        stack.Pop();
        stack.Pop();
        if (stack.Top() != 5)
        {
            return false;
        }
        stack.Pop();
        try
        {
            stack.Top();
            return false;
        }
        catch (InvalidOperationException) { }
        return true;
    }
}