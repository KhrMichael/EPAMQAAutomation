namespace MailRu.Models.Builders;

public class CredentialsBuilder
{
    private string name;
    private string surname;
    private string email;
    private string nickname;
    private string password;
    private MailRuSignInWith signInWith;

    public CredentialsBuilder()
    {
        name = string.Empty;
        surname = string.Empty;
        nickname = string.Empty;
        password = string.Empty;
    }

    public CredentialsBuilder SetName(string name)
    {
        this.name = name;

        return this;
    }

    public CredentialsBuilder SetSurname(string surname)
    {
        this.surname = surname;

        return this;
    }

    public CredentialsBuilder SetNickname(string nickname)
    {
        this.nickname = nickname;

        return this;
    }

    public CredentialsBuilder SetPassword(string password)
    {
        this.password = password;

        return this;
    }

    public CredentialsBuilder SetEmail(string email)
    {
        this.email = email;

        return this;
    }

    public CredentialsBuilder SetSignInMethod(MailRuSignInWith signInWith)
    {
        this.signInWith = signInWith;

        return this;
    }

    public Credentials Build()
    {
        return new Credentials(name, surname, password, email, nickname);
    }
}