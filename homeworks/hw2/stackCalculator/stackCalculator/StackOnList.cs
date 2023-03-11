namespace StackCalculator;

using System;
using System.Collections.Generic;

// Stack implementation using a list
internal class StackOnList : IStack
{
    public StackOnList() 
        => this.data = new ();

    private readonly List<double> data;

    public void Push(double value)
        => this.data.Insert(0, value);

    public void Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        this.data.Remove(this.data[0]);
    }

    public double Top()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return this.data[0];
    }

    public bool IsEmpty()
        => this.data.Count == 0;

    // Tests
    public static bool Tests()
    {
        var stack = new StackOnList();
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