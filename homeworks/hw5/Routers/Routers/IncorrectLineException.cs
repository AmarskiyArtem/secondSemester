namespace Routers;

public class IncorrectLineException : Exception
{
    IncorrectLineException(string message) : base(message) { }
}
