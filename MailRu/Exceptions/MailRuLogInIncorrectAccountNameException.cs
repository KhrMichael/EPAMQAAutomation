using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuLogInIncorrectAccountNameException : MailRuLogInPageException
{
    public MailRuLogInIncorrectAccountNameException()
    {
    }

    protected MailRuLogInIncorrectAccountNameException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuLogInIncorrectAccountNameException(string? message) : base(message)
    {
    }

    public MailRuLogInIncorrectAccountNameException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}