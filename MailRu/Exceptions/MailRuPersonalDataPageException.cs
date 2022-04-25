using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuPersonalDataPageException : MailRuException
{
    public MailRuPersonalDataPageException()
    {
    }

    protected MailRuPersonalDataPageException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuPersonalDataPageException(string? message) : base(message)
    {
    }

    public MailRuPersonalDataPageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}