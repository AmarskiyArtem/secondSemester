namespace ParsingTreeLibrary;

internal class Division : Operation
{
    public override void Print()
    {
        Console.Write("/ ");
        base.Print();
    }

    public override double Calculate()
    {
        if (Math.Abs(RightChild.Calculate()) < 0.001)
        {
            throw new DivideByZeroException();
        }
        return LeftChild.Calculate() / RightChild.Calculate();
    }
        
}
