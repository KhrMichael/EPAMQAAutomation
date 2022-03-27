using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuLogInPageSetupException : MailRuLogInPageException
{
    public MailRuLogInPageSetupException()
    {
    }

    protected MailRuLogInPageSetupException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuLogInPageSetupException(string? message) : base(message)
    {
    }

    public MailRuLogInPageSetupException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}