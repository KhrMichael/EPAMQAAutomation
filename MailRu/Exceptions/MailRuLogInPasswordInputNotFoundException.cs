using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuLogInPasswordInputNotFoundException : MailRuLogInPageException
{
    public MailRuLogInPasswordInputNotFoundException()
    {
    }

    protected MailRuLogInPasswordInputNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuLogInPasswordInputNotFoundException(string? message) : base(message)
    {
    }

    public MailRuLogInPasswordInputNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}