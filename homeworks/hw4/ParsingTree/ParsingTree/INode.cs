namespace ParsingTreeLibrary;

/// <summary>
/// Interface of Node of parsing tree
/// </summary>
internal interface INode
{
    /// <summary>
    /// Print subtree
    /// </summary>
    public void Print();

    /// <summary>
    /// Calculate subtree
    /// </summary>
    public double Calculate();
}
