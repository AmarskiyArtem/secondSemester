namespace ParsingTreeLibrary;
internal class Multiplication : Operation
{
    public override void Print()
    {
        Console.Write("* ");
        base.Print();
    }

    public override double Calculate()
        => LeftChild.Calculate() * RightChild.Calculate();
}
