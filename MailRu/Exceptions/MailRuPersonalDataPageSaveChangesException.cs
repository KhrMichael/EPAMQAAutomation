using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuPersonalDataPageSaveChangesException : MailRuPersonalDataPageException
{
    public MailRuPersonalDataPageSaveChangesException()
    {
    }

    protected MailRuPersonalDataPageSaveChangesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuPersonalDataPageSaveChangesException(string? message) : base(message)
    {
    }

    public MailRuPersonalDataPageSaveChangesException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}