using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuLogInPageException : MailRuException
{
    public MailRuLogInPageException()
    {
    }

    protected MailRuLogInPageException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuLogInPageException(string? message) : base(message)
    {
    }

    public MailRuLogInPageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}