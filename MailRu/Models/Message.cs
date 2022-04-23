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

    protected bool Equals(Message other)
    {
        return Receiver == other.Receiver && Theme == other.Theme && Body == other.Body;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Message) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Receiver, Theme, Body);
    }
}