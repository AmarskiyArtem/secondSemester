namespace ParsingTreeLibrary;

/// <summary>
/// Implementation INode interface for numbers
/// </summary>
internal class Operand : INode
{
    public Operand(int value)
    {
        this.Value = value;
    }

    public int Value { get; }

    /// <inheritdoc/>
    public void Print()
    {
        Console.Write($"{Value} ");
    }

    /// <inheritdoc/>
    public double Calculate()
        => Value;
}
