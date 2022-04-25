using System.Security.AccessControl;
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
    private WebDriver driver;

    private Message TestMessage =>
        new Message("account2.test@mail.ru", "TestMessage", "This message was sent from account1.");

    private Message MessageWithNewAccountName => new Message("account1.test1@mail.ru", "New account name", "NewName");


    private Credentials Account1 => new Credentials("test1", "account1", "strongpassword", "account1.test1@mail.ru");
    private Credentials Account2 => new Credentials("test", "account2", "strongpassword", "account2.test@mail.ru");


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
    public void ShouldSendTestMessage()
    {
        var mailRuIncomingMailsPage = GetMailRuIncomingMailsPage(Account1);
        var message = TestMessage;

        mailRuIncomingMailsPage
            .OpenMessageConstructor()
            .WriteMessage(message)
            .SendMessage();
    }

    [TestMethod]
    public void ShouldSendMessageWithNewAccountName()
    {
        var mailRuIncomingMailsPage = GetMailRuIncomingMailsPage(Account2);
        var message = MessageWithNewAccountName;

        mailRuIncomingMailsPage
            .OpenMessageConstructor()
            .WriteMessage(message)
            .SendMessage();
    }

    [TestMethod]
    public void ShouldFindUnreadTestMessage()
    {
        var mailRuIncomingMailsPage = GetMailRuIncomingMailsPage(Account2);

        var incomingMessages = mailRuIncomingMailsPage.GetIncomingMessages();
        var isMessageReceived =
            incomingMessages.Exists(messageInfo => messageInfo.Message.Equals(TestMessage) && messageInfo.IsUnread);
        
        Assert.IsTrue(isMessageReceived);
    }

    [TestMethod]
    public void ShouldFindMessageWithNewAccountName()
    {
        var mailRuIncomingMailsPage = GetMailRuIncomingMailsPage(Account1);

        var incomingMessages = mailRuIncomingMailsPage.GetIncomingMessages();
        var isMessageReceived =
            incomingMessages.Exists(messageInfo =>
                messageInfo.Message.Equals(MessageWithNewAccountName) && messageInfo.IsUnread);
        
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