namespace UniqueListLibrary;

/// <summary>
/// Exception for collections containing unique elements
/// </summary>
public class ElementAlreadyExistException : Exception 
{
    public ElementAlreadyExistException() : base() { }

    public ElementAlreadyExistException(string message) : base(message) { }
}
