namespace ParsingTreeLibrary;

internal class Operand : INode
{
    public Operand(int value)
    {
        this.Value = value;
    }

    public int Value { get; }

    public void Print()
    {
        Console.Write($"{Value} ");
    }

    public double Calculate()
        => Value;
}
