namespace UniqueListLibrary;

/// <summary>
/// Linked list, a linear collection of int
/// </summary>
public class List
{
    protected class ListElement
    {
        public ListElement(int value, ListElement? next)
        {
            this.Value = value;
            this.Next = next;
        }
        public int Value { get; set; }
        public ListElement? Next { get; set; }
    }

    /// <summary>
    /// Number of elements in list
    /// </summary>
    public int Size { get; private set; }

    protected ListElement? Head;

    /// <summary>
    /// Add new element with given value to the head of list
    /// </summary>
    public void Push(int value)
    {
        var newHead = new ListElement(value, this.Head);
        this.Head = newHead;
        Size++;
    }

    /// <summary>
    /// Returns value that lies at given index
    /// </summary>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public int Get(int index)
    {
        if (index >= Size || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var currentListElement = Head;
        for (var i = 0; i < index; i++)
        {
            currentListElement = currentListElement!.Next;
        }

        return currentListElement!.Value;
    }
    
    /// <summary>
    /// Insert new element with given value before element with given index
    /// </summary>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void Insert(int value, int index)
    {
        if (index > Size || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            Push(value);
            return;
        }

        var currentListElement = Head;
        for (var i = 0; i < index - 1; i++)
        {
            currentListElement = currentListElement!.Next;
        }

        var newElement = new ListElement(value, currentListElement!.Next);
        currentListElement.Next = newElement;
        Size++;
    }

    /// <summary>
    /// Changes the value for given index
    /// </summary>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void ChangeValueByIndex(int value, int index)
    {
        if (index >= Size || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var currentListElement = Head;
        for (var i = 0; i < index; i++)
        {
            currentListElement = currentListElement!.Next;
        }
        currentListElement!.Value = value;
    }

    /// <summary>
    /// Remove element with given index from list
    /// </summary>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void Remove(int index) 
    {
        if (index >= Size || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            Head = Head!.Next;
        }

        var currentListElement = Head;
        for (var i = 0; i < index - 1; i++)
        {
            currentListElement = currentListElement!.Next;
        }
        currentListElement!.Next = currentListElement.Next!.Next;
        Size--;
    }
}