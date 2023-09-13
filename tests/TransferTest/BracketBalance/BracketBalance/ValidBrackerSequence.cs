namespace BracketBalance;

/// <summary>
/// Provides methods for validating a bracket sequence.
/// </summary>
public static class ValidBrackerSequence
{
    /// <summary>
    /// Validates whether the given string contains a valid bracket sequence.
    /// Empty string it is considered correct bracket sequence.
    /// </summary>
    /// <param name="sequence">The string containing the bracket sequence to be validated.</param>
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

