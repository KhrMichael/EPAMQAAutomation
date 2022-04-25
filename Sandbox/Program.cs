using MailRu.Models;using MailRu.Pages;
using OpenQA.Selenium.Chrome;

var chromeDriver = new ChromeDriver();
var mailRuMainPage = new MailRuMainPage(chromeDriver);
var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
var credentials = new Credentials("test", "account2","strongpassword", "account2.test@mail.ru");
var mailRuIncomingMailsPage = mailRuLogInPage
    .SetCredentials(credentials)
    .SendAccountName()
    .SubmitAccountName()
    .SendPassword()
    .SubmitPassword();

mailRuIncomingMailsPage.GetIncomingMessages();
