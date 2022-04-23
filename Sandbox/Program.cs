using MailRu.Pages;
using OpenQA.Selenium.Chrome;

var chromeDriver = new ChromeDriver();
var mailRuMainPage = new MailRuMainPage(chromeDriver);
var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
mailRuLogInPage.AccountName = "account2.test";
mailRuLogInPage.Passowrd = "strongpassword";
var mailRuIncomingMailsPage = mailRuLogInPage
    .SendAccountName()
    .SubmitAccountName()
    .SendPassword()
    .SubmitPassword();

mailRuIncomingMailsPage.GetIncomingMessages();
