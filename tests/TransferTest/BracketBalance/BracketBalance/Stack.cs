namespace BracketBalance;

using System.Collections.Generic;

public class Stack<T>
{
    public Stack()
        => this.data = new();

    private readonly List<T> data;
    public void Push(T value)
        => this.data.Insert(0, value);

    public void Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        this.data.RemoveAt(0);
    }

    public T Top()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return this.data[0];
    }

    public bool IsEmpty()
        => this.data.Count == 0;
}
