namespace UniqueListLibrary;

/// <summary>
/// Linked list which contains only unique elements
/// </summary>
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

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"></exception>
    public new void Push(int value)
    {
        if (Contains(value))
        {
            throw new ElementAlreadyExistException($"{value} already added to the unique list");
        }
        base.Push(value);
    }

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"></exception>
    public new void Insert(int value, int index)
    {
        if (Contains(value)) 
        {
            throw new ElementAlreadyExistException($"{value} already added to the unique list");
        }
        base.Insert(value, index);
    }

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"></exception>
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
