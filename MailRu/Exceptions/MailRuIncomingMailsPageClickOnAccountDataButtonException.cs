using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuIncomingMailsPageClickOnAccountDataButtonException : MailRuIncomingMailPageException
{
    public MailRuIncomingMailsPageClickOnAccountDataButtonException()
    {
    }

    protected MailRuIncomingMailsPageClickOnAccountDataButtonException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuIncomingMailsPageClickOnAccountDataButtonException(string? message) : base(message)
    {
    }

    public MailRuIncomingMailsPageClickOnAccountDataButtonException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}