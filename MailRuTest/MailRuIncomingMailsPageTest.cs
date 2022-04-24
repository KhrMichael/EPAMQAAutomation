using MailRu.Models;
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

    public Message TestMessage =>
        new Message("account2.test@mail.ru", "TestMessage", "This message was sent from account1.");

    public Credentials Account1 => new Credentials("account1.test1@mail.ru", "strongpassword");
    public Credentials Account2 => new Credentials("account2.test@mail.ru", "strongpassword");


    [TestInitialize]
    public void Initialize()
    {
        driver = new ChromeDriver();
    }

    [TestCleanup]
    public void Cleanup()
    {
        driver.Close();
        driver.Quit();
    }

    [TestMethod]
    public void ShouldSendMessage()
    {
        var mailRuIncomingMailsPage = GetMailRuIncomingMailsPage(Account1);
        var message = TestMessage;

        mailRuIncomingMailsPage
            .OpenMessageConstructor()
            .WriteMessage(message)
            .SendMessage();
    }

    [TestMethod]
    public void ShouldFindSpecificUnreadMessage()
    {
        var mailRuIncomingMailsPage = GetMailRuIncomingMailsPage(Account2);

        var incomingMessages = mailRuIncomingMailsPage.GetIncomingMessages();
        var isMessageReceived =
            incomingMessages.Exists(messageInfo => messageInfo.Message.Equals(TestMessage) && messageInfo.IsUnread);
        
        Assert.IsTrue(isMessageReceived);
    }

    private MailRuIncomingMailsPage GetMailRuIncomingMailsPage(Credentials credentials)
    {
        var mailRuMainPage = new MailRuMainPage(driver);
        var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
        return mailRuLogInPage
            .SetCredentials(credentials)
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();
    }
}