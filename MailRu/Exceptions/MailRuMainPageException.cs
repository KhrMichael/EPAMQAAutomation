using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuMainPageException : MailRuException
{
    public MailRuMainPageException()
    {
    }

    protected MailRuMainPageException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuMainPageException(string? message) : base(message)
    {
    }

    public MailRuMainPageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}