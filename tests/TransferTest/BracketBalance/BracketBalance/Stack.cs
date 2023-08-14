namespace BracketBalance;


/// <summary>
/// Stack data structure
/// </summary>
public class Stack<T>
{

    private int topIndex = -1;

    private int currentArraySize = 2;

    private T[] stack;

    /// <summary>
    /// Initializes a new instance of the Stack class.
    /// </summary>
    public Stack()
    {
        this.stack = new T[this.currentArraySize];
    }


    private void ResizeStack()
    {
        currentArraySize *= 2;

        var tempArray = new T[currentArraySize];
        stack.CopyTo(tempArray, 0);
        stack = tempArray;
    }

    /// <summary>
    /// Adds new element to the stack
    /// </summary>
    public void Push(T newElement)
    {
        ++topIndex;

        if (topIndex == currentArraySize)
        {
            ResizeStack();
        }

        stack[topIndex] = newElement;
    }


    public bool IsEmpty() 
        => topIndex == -1;

    /// <summary>
    /// Returns element from top of the stack
    /// </summary>
    public T Top()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Top() from empty stack");
        }

        return stack[topIndex];
    }

    /// <summary>
    /// Delete element from the top of the stack
    /// </summary>
    public void Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty stack");
        }

        --topIndex;
    }
}