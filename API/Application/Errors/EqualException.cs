using System.Runtime.Serialization;

namespace Application.Errors;

public class EqualException : BaseException
{
    public EqualException()
    {
    }

    public EqualException(string? message) : base(message)
    {
    }

    public EqualException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public EqualException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
