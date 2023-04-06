

namespace Routers.Exceptions;

public class DisconnectedGraphException : Exception
{
    public DisconnectedGraphException() : base() { }

    public DisconnectedGraphException(string message) : base(message) { }

}
