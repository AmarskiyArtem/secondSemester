namespace PriorityQueueLibrary;

/// <summary>
/// An exception thrown if there are no items in the queue
/// </summary>
public class PriorityQueueIsEmptyException : Exception
{
    public PriorityQueueIsEmptyException() : base() { }
}
