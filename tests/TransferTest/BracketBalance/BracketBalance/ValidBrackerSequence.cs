namespace BracketBalance;

public static class ValidBrackerSequence
{
    public static bool IsValidBracketSequence(string sequence)
    {
        var stack = new Stack<char>();

        foreach (var bracket in sequence)
        {
            if (bracket == '(' || bracket == '[' || bracket == '<')
            {
                stack.Push(bracket);
            }
            else if (bracket == ')' || bracket == ']' || bracket == '>')
            {
                if (stack.IsEmpty())
                {
                    return false;
                }

                var openBracket = stack.Top();
                if ((bracket == ')' && openBracket == '(') ||
                    (bracket == ']' && openBracket == '[') ||
                    (bracket == '>' && openBracket == '<'))
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return stack.IsEmpty();
    }
}

