namespace ParsingTreeLibrary;

internal abstract class Operation : INode
{
    public INode? LeftChild { get; set; }

    public INode? RightChild { get; set; }

    public virtual void Print()
    {
        LeftChild?.Print();
        RightChild?.Print();
    }

    public abstract double Calculate();
}
