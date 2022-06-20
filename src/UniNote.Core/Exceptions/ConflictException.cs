namespace UniNote.Core.Exceptions;

public class ConflictException : Exception
{
    public ConflictException()
    {
    }

    public ConflictException(string? message) : base(message)
    {
    }
}