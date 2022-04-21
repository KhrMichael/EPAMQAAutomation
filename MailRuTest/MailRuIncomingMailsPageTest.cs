using MailRu.Models.Builders;
using MailRu.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailRuTest;

[TestClass]
public sealed class MailRuIncomingMailsPageTest
{
    public WebDriver driver;

    
    [TestInitialize]
    public void Initialize()
    {
        Logger.LogMessage($"MailRuIncomingMailsPageTest TestInitialize");
        driver = new ChromeDriver();
    }

    [TestCleanup]
    public void Cleanup()
    {
        Logger.LogMessage("MailRuIncomingMailsPageTest TestCleanup");
        driver.Close();
        driver.Quit();
    }

    [TestMethod]
    public void ShouldSendMessage()
    {
        var mailRuMainPage = new MailRuMainPage(driver);
        var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
        mailRuLogInPage.AccountName = "account1.test1";
        mailRuLogInPage.Passowrd = "strongpassword";
        var mailRuIncomingMailsPage = mailRuLogInPage
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();
        var message = new MessageBuilder()
            .SetReceiver("account2.test@mail.ru")
            .SetTheme("TestMessage")
            .SetBody("This message was sent from account1.")
            .Build();

        mailRuIncomingMailsPage
            .OpenMessageConstructor()
            .WriteMessage(message)
            .SendMessage();
    }

    [TestMethod]
    public void ShouldReturnAllIncomingMessages()
    {
        var mailRuMainPage = new MailRuMainPage(driver);
        var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
        mailRuLogInPage.AccountName = "account2.test";
        mailRuLogInPage.Passowrd = "strongpassword";
        var mailRuIncomingMailsPage = mailRuLogInPage
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();

        var incomingMessages = mailRuIncomingMailsPage.GetIncomingMessages();
    }
}