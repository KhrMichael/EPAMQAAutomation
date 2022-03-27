using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuLogInSubmitPasswordButtonNotFoundException : MailRuLogInPageException
{
    public MailRuLogInSubmitPasswordButtonNotFoundException()
    {
    }

    protected MailRuLogInSubmitPasswordButtonNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuLogInSubmitPasswordButtonNotFoundException(string? message) : base(message)
    {
    }

    public MailRuLogInSubmitPasswordButtonNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}