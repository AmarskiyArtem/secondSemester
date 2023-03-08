namespace StackCalculator;

internal interface IStack
{
    public void Push(double value);

    public void Pop();

    public double Top();

    public bool IsEmpty();

}

