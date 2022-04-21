namespace MailRu.Models;

public class MessageInfo
{
    public Message Message { get; }
    public bool IsUnread { get; }
    public string Sender { get; }

    public MessageInfo(Message message, bool isUnread, string sender)
    {
        Message = message;
        IsUnread = isUnread;
        Sender = sender;
    }
}