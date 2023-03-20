namespace ParsingTreeLibrary;

public class ParsingTree
{
    public ParsingTree(string expression)
    {
        if (expression == null)
        {

            throw new ArgumentNullException();
        }

        if (expression == String.Empty)
        {
            throw new ArgumentException("String is empty.");
        }

        FillTree(expression);
    }

    private INode root;

    private void FillTree(string expression)
    {
        var parts = expression.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        var index = -1;
        INode AddNode()
        {
            index++;
            if (index >= parts.Length)
            {
                throw new ArgumentException("Incorrect math expression.");
            }
            if (char.IsDigit(parts[index][0]))
            {
                return new Operand(int.Parse(parts[index]));
            }

            Operation? newNode = parts[index] switch
            {
                "*" => new Multiplication(),
                "/" => new Division(),
                "+" => new Addition(),
                "-" => new Subtraction(),
                _ => throw new ArgumentException("Incorrect math expression."),
            };
            newNode.LeftChild = AddNode();
            newNode.RightChild = AddNode();
            return newNode;
        }
        root = AddNode();
        if (index != parts.Length - 1)
        {
            throw new ArgumentException("Incorrect math expression.");
        }
    }

    public double CalculateTree()
        => root.Calculate();

    public void PrintTree()
        => root.Print();
}
