namespace ParsingTreeLibrary;

/// <summary>
/// Abstact implementation for INode interface for operation case
/// </summary>
internal abstract class Operation : INode
{
    public INode? LeftChild { get; set; }

    public INode? RightChild { get; set; }

    /// <inheritdoc/>
    public virtual void Print()
    {
        LeftChild?.Print();
        RightChild?.Print();
    }

    /// <inheritdoc/>
    public abstract double Calculate();
}
