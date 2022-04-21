using MailRu.Exceptions;
using MailRu.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailRu.Pages;

public class MailRuIncomingMailsPage
{
   private WebDriver Driver { get; }
   private string AccountName { get; }
   private TimeSpan LoadPageTime = TimeSpan.FromSeconds(10);
   private TimeSpan FindeElementTime => TimeSpan.FromSeconds(5);
   private string UniqueElementXPath =>
      "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[1]/div[1]/div/div/div/div[1]/div/div/a";
   private string WriteMessageButtonXPath =>
      "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[1]/div[1]/div/div/div/div[1]/div/div/a";
   private string ReceiverInputXPath =>
      "/html/body/div[1]/div/div[2]/div/div[1]/div[2]/div[3]/div[2]/div/div/div[1]/div/div[2]/div/div/label/div/div/input";
   private string ThemeInputXPath =>
      "/html/body/div[1]/div/div[2]/div/div[1]/div[2]/div[3]/div[3]/div[1]/div[2]/div/input";
   private string MessageBodyXPath =>
      "/html/body/div[1]/div/div[2]/div/div[1]/div[2]/div[3]/div[5]/div/div/div[2]/div[1]/div[1]";
   private string SendMessageButtonXPath => "/html/body/div[1]/div/div[2]/div/div[2]/div[1]/span[1]";
   private string IncomingMessageGroupListXPath =>
      "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div/div[1]/div/div";

   private string IncomingMessageGroupXPath => "a";
   private string IncomingMessageGroupSenderXPath => "div[4]/div/div/span";
   private string IncomingMessageGroupThemeXPath => "div[4]/div/div[3]/span[1]/div/span";
   private string IncomingMessageGroupBodyXPath => "div[4]/div/div[3]/span[2]/div/span";
   private string IncomingMessageIsUnreadBoxXPath => "div[2]/span";
   private string IncomingMessageSenderXPath => "div/a/div[4]/div/div/span";
   private string IncomingMessageThemeXPath => "div/a/div[4]/div/div[3]/span[1]/div/span";
   private string IncomingMessageBodyXPath => "div/a/div[4]/div/div[3]/span[2]/div/span";
   private string IncomingMessageListXPath =>
      "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div";

   private string IncomingMessageXPath => "div[contains(@class, 'thread__letter')]";

   public MailRuIncomingMailsPage(WebDriver driver, string accountName)
   {
      Driver = driver;
      AccountName = accountName;
      LoadPage();
   }

   private void LoadPage()
   {
      var webDriverWait = new WebDriverWait(Driver, LoadPageTime);

      try
      {
         webDriverWait.Until(driver => driver.FindElement(By.XPath(UniqueElementXPath)));
      }
      catch(WebDriverTimeoutException)
      {
         throw new MailRuIncomingMailPageSetupException();
      }
   }

   public MailRuIncomingMailsPage OpenMessageConstructor()
   {
      var webDriverWait = new WebDriverWait(Driver, FindeElementTime);
      try
      {
         var writeMessageButton = webDriverWait.Until(driver => driver.FindElement(By.XPath(WriteMessageButtonXPath)));
         writeMessageButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
         throw new MailRuIncomingMailsPageOpenMessageConstructorException();
      }
      
      return this;
   }

   public MailRuIncomingMailsPage WriteMessage(Message message)
   {
      var webDriverWait = new WebDriverWait(Driver, FindeElementTime);
      try
      {
         var receiverInput = webDriverWait.Until(driver => driver.FindElement(By.XPath(ReceiverInputXPath)));
         var themeInput = webDriverWait.Until(driver => driver.FindElement(By.XPath(ThemeInputXPath)));
         var messageBody = webDriverWait.Until(driver => driver.FindElement(By.XPath(MessageBodyXPath)));
         
         receiverInput.SendKeys(message.Receiver);
         themeInput.SendKeys(message.Theme);
         messageBody.SendKeys(message.Body);
      }
      catch (WebDriverTimeoutException)
      {
         throw new MailRuIncomingMailsPageWriteMessageException();
      }
      
      return this;
   }

   public void SendMessage()
   {
      var webDriverWait = new WebDriverWait(Driver, FindeElementTime);

      try
      {
         var sendButton = webDriverWait.Until(driver => driver.FindElement(By.XPath(SendMessageButtonXPath)));
         sendButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
         throw new MailRuIncomingMailsPageSendMessageException();
      }
   }

   public List<MessageInfo> GetIncomingMessages()
   {
      var messageInfos = new List<MessageInfo>();
      var webDriverWait = new WebDriverWait(Driver, LoadPageTime);
      try
      {
         var incomingMessageGroupList = 
            webDriverWait.Until(driver => driver.FindElement(By.XPath(IncomingMessageGroupListXPath)));
         var incomingMessageGroups =
            webDriverWait.Until(driver => incomingMessageGroupList.FindElements(By.XPath(IncomingMessageGroupXPath)));  
         foreach (var messageGroup in incomingMessageGroups)
         {
            var isUnread = messageGroup.FindElement(By.XPath(IncomingMessageIsUnreadBoxXPath)).GetAttribute("class")
               .Contains("ll-rs_is-active");
            var firstMessageSender = webDriverWait.Until(driver => messageGroup.FindElement(By.XPath(IncomingMessageGroupSenderXPath)));
            var firstMessageTheme = webDriverWait.Until(driver => messageGroup.FindElement(By.XPath(IncomingMessageGroupThemeXPath)));
            var firstMessageBody = webDriverWait.Until(driver => messageGroup.FindElement(By.XPath(IncomingMessageGroupBodyXPath)));
            var message = new Message(AccountName, firstMessageTheme.Text, firstMessageBody.Text);
            messageInfos.Add(new MessageInfo(message, isUnread, firstMessageSender.Text));
            
            messageGroup.Click();
            var incomingMessageList = 
               webDriverWait.Until(driver => driver.FindElement(By.XPath(IncomingMessageListXPath)));
            var incomingMessages =
               webDriverWait.Until(driver => driver.FindElements(By.XPath(IncomingMessageXPath)));   
            var messages = new List<IWebElement>(incomingMessages);
            messages.RemoveAt(0);
            foreach (var incomingMessage in messages)
            {
               var messageSender = webDriverWait.Until(driver => incomingMessage.FindElement(By.XPath(IncomingMessageSenderXPath)));
               var messageTheme = webDriverWait.Until(driver => incomingMessage.FindElement(By.XPath(IncomingMessageThemeXPath)));
               var messageBody = webDriverWait.Until(driver => incomingMessage.FindElement(By.XPath(IncomingMessageBodyXPath)));
               message = new Message(AccountName, messageTheme.Text, messageBody.Text);
               messageInfos.Add(new MessageInfo(message, isUnread, messageSender.Text));
            }
            Driver.Navigate().Back();
         }
      }
      catch (WebDriverTimeoutException)
      {
         throw new MailRuIncomingMailsPageGetIncomingMessagesException();
      }
      
      return messageInfos;
   }
}