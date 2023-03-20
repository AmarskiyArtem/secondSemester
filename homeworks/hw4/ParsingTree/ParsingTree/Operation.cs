namespace ParsingTreeLibrary;

internal abstract class Operation : INode
{
    public INode leftChild { get; set; }

    public INode rightChild { get; set; }

    public abstract void Print();

    public abstract double Calculate();
}
