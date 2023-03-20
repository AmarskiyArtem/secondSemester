namespace ParsingTreeLibrary;

/// <summary>
/// Implementation opetation for "/" case
/// </summary>
internal class Division : Operation
{
    /// <inheritdoc/>
    public override void Print()
    {
        Console.Write("/ ");
        base.Print();
    }

    /// <inheritdoc/>
    /// <exception cref="DivideByZeroException" ></exception>
    public override double Calculate()
    {
        if (Math.Abs(RightChild.Calculate()) < 0.001)
        {
            throw new DivideByZeroException();
        }
        return LeftChild.Calculate() / RightChild.Calculate();
    }
        
}
