using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuPersonalDataPageSetupException : MailRuPersonalDataPageException
{
    public MailRuPersonalDataPageSetupException()
    {
    }

    protected MailRuPersonalDataPageSetupException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuPersonalDataPageSetupException(string? message) : base(message)
    {
    }

    public MailRuPersonalDataPageSetupException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}