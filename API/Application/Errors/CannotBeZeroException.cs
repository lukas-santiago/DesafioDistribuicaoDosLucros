using System.Runtime.Serialization;

namespace Application.Errors;

public class CannotBeZeroException : Exception
{
    public CannotBeZeroException()
    {
    }

    public CannotBeZeroException(string? message) : base(message)
    {
    }

    public CannotBeZeroException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CannotBeZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
