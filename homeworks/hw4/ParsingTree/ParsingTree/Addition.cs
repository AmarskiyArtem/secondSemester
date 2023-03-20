namespace ParsingTreeLibrary;

internal class Addition : Operation
{
    public override void Print()
    {
        Console.Write("+ ");
        base.Print();
    }

    public override double Calculate()
        => LeftChild.Calculate() + RightChild.Calculate();
}
