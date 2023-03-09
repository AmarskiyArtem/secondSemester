namespace StackCalculator;

using System;
using System.Collections.Generic;

internal class StackOnList : IStack
{
    public StackOnList()
    {
        this.data = new List<double>();
    }

    private readonly List <double> data;

    public void Push(double value)
    {
        this.data.Insert(0, value);
    }

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

    public bool IsEmpty() => this.data.Count == 0;
}

