﻿
namespace UniqueList;

public class ElementAlreadyExistException : Exception 
{
    public ElementAlreadyExistException() : base() { }

    public ElementAlreadyExistException(string message) : base(message) { }
}
