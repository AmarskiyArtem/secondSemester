using UniqueListLibrary;

namespace UniqueList;

public class UniqueList : List
{
    private bool Contains(int value)
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            if (currentNode.Value == value)
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        return false;
    }

    public new void Push(int value)
    {
        if (Contains(value))
        {
            throw new ElementAlreadyExistException($"{value} already added to the unique list");
        }
        base.Push(value);
    }
    
    public new void Insert(int value, int index)
    {
        if (Contains(value)) 
        {
            throw new ElementAlreadyExistException($"{value} already added to the unique list");
        }
        base.Insert(value, index);
    }

    public new void ChangeValueByIndex(int value, int index)
    {
        if (!Contains(value))
        {
            base.ChangeValueByIndex(value, index);
        }
        else if (Get(index) == value)
        {
            return;
        }
        throw new ElementAlreadyExistException($"{value} already added to the unique list");
    }
}
