namespace StackCalculator;

using System.Collections.Generic;

internal class StackOnLinkedList : IStack
{
    public StackOnLinkedList()
    {
        this.data = new LinkedList<double>();
    }

    private readonly LinkedList<double> data;

    public void Push(double value)
    {
        this.data.AddFirst(value);
    }

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

    public bool IsEmpty() => this.data.Count == 0;
}

