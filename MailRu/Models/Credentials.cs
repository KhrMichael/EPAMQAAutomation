using MailRu.Pages;

namespace MailRu.Models;

public class Credentials
{ 
    public string Name { get; }
    public string Surname { get; }
    public string Nickname { get; }

    public MailRuSignInWith  SignInWith { get; }
    public string Email { get; }
    public string Password { get; }

    public Credentials(string name, string surname, string password, string email, string nickname = "default")
    {
        Name = name;
        Surname = surname;
        Password = password;
        Email = email;
        Nickname = nickname == "default" ? Name + ' ' + Surname : nickname;
    }

}