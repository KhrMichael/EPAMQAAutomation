using System;
using MailRu.Models.Builders;
using MailRu.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace MailRuTest;

[TestClass]
public class MailRuIncomingMailsPageTest
{
   [TestMethod]
   public void ShouldSendMessage()
   {
      var chromeDriver = new ChromeDriver();
      chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      var mailRuMainPage = new MailRuMainPage(chromeDriver);
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
}