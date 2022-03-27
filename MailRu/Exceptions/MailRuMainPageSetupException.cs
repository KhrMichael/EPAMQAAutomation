using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuMainPageSetupException : MailRuMainPageException
{
    public MailRuMainPageSetupException()
    {
    }

    protected MailRuMainPageSetupException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuMainPageSetupException(string? message) : base(message)
    {
    }

    public MailRuMainPageSetupException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}