namespace MailRu.Models;

public class Message
{
    public string Receiver { get; }
    public string Theme { get; }
    public string Body { get; }

    public Message(string receiver, string theme, string body)
    {
        Receiver = receiver;
        Theme = theme;
        Body = body;
    }
}