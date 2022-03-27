using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuException : Exception
{
    public MailRuException()
    {
    }

    protected MailRuException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuException(string? message) : base(message)
    {
    }

    public MailRuException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}