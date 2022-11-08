using System.Runtime.Serialization;

namespace Application.Errors;
public class NotFoundException : BaseException
{
    public NotFoundException()
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }

    public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
