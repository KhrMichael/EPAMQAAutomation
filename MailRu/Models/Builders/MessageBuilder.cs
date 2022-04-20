namespace MailRu.Models.Builders;

public class MessageBuilder
{
    private string receiver;
    private string theme;
    private string body;

    public MessageBuilder()
    {
        receiver = string.Empty;
        theme = string.Empty;
        body = string.Empty;
    }

    public MessageBuilder SetReceiver(string receiver)
    {
        this.receiver = receiver;

        return this;
    }

    public MessageBuilder SetTheme(string theme)
    {
        this.theme = theme;

        return this;
    }

    public MessageBuilder SetBody(string body)
    {
        this.body = body;

        return this;
    }

    public Message Build()
    {
        return new Message(receiver, theme, body);
    }
}