namespace Routers;

public class IncorrectLineException : Exception
{
    public IncorrectLineException(string message) : base(message) { }
}
