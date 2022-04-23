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

    public Message TestMessage { get; set; }


    [TestInitialize]
    public void Initialize()
    {
        Logger.LogMessage($"MailRuIncomingMailsPagTest TestInitialize");
        driver = new ChromeDriver();
        TestMessage = new MessageBuilder()
                 .SetReceiver("account2.test@mail.ru")
                 .SetTheme("TestMessage")
                 .SetBody("This message was sent from account1.")
                 .Build();
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
        mailRuLogInPage.AccountName = "account1.test1@mail.ru";
        mailRuLogInPage.Passowrd = "strongpassword";
        var mailRuIncomingMailsPage = mailRuLogInPage
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();
        var message = TestMessage;

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
        mailRuLogInPage.AccountName = "account2.test@mail.ru";
        mailRuLogInPage.Passowrd = "strongpassword";
        var mailRuIncomingMailsPage = mailRuLogInPage
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();

        var incomingMessages = mailRuIncomingMailsPage.GetIncomingMessages();
        var isMessageReceived =
            incomingMessages.Exists(messageInfo => messageInfo.Message.Equals(TestMessage) && messageInfo.IsUnread);
        
        Assert.IsTrue(isMessageReceived);
    }
}