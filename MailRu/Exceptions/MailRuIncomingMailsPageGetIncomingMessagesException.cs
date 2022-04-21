using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuIncomingMailsPageGetIncomingMessagesException : MailRuIncomingMailPageException
{
    public MailRuIncomingMailsPageGetIncomingMessagesException()
    {
    }

    protected MailRuIncomingMailsPageGetIncomingMessagesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuIncomingMailsPageGetIncomingMessagesException(string? message) : base(message)
    {
    }

    public MailRuIncomingMailsPageGetIncomingMessagesException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}