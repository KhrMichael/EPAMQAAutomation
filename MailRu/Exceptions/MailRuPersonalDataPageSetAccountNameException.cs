using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuPersonalDataPageSetAccountNameException : MailRuPersonalDataPageException
{
    public MailRuPersonalDataPageSetAccountNameException()
    {
    }

    protected MailRuPersonalDataPageSetAccountNameException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuPersonalDataPageSetAccountNameException(string? message) : base(message)
    {
    }

    public MailRuPersonalDataPageSetAccountNameException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}