namespace StackCalculator;

using System;
using System.Collections.Generic;

internal class StackOnList : IStack
{
    public StackOnList()
    {
        this.data = new List<double>();
    }

    private List <double> data;
    public void Push(double value)
    {
        this.data.Insert(0, value);
    }

    public void Pop()
    {
        this.data.Remove(this.data[0]);
    }

    public double Top()
    {
        return this.data[0];
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }
}

