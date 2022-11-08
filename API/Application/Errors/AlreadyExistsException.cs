using System.Runtime.Serialization;

namespace Application.Errors;

public class AlreadyExistsException : BaseException
{
    public AlreadyExistsException()
    {
    }

    public AlreadyExistsException(string? message) : base(message)
    {
    }

    public AlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public AlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
