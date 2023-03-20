﻿namespace ParsingTreeLibrary;

/// <summary>
/// Implementation opetation for "*" case
/// </summary>
internal class Multiplication : Operation
{
    /// <inheritdoc/>
    public override void Print()
    {
        Console.Write("* ");
        base.Print();
    }

    /// <inheritdoc/>
    public override double Calculate()
        => LeftChild.Calculate() * RightChild.Calculate();
}
