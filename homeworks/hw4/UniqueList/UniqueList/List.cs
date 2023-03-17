namespace UniqueListLibrary;

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

    public int Size { get; private set; }

    protected ListElement? Head;

    public void Push(int value)
    {
        var newHead = new ListElement(value, this.Head);
        this.Head = newHead;
        Size++;
    }

    public int Get(int index)
    {
        if (index >= Size)
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