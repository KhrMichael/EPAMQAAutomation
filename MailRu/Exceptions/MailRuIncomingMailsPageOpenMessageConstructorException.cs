using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuIncomingMailsPageOpenMessageConstructorException : MailRuIncomingMailPageException
{
    public MailRuIncomingMailsPageOpenMessageConstructorException()
    {
    }

    protected MailRuIncomingMailsPageOpenMessageConstructorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuIncomingMailsPageOpenMessageConstructorException(string? message) : base(message)
    {
    }

    public MailRuIncomingMailsPageOpenMessageConstructorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}