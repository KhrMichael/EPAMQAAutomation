using MailRu.Exceptions;
using MailRu.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailRu.Pages;

public class MailRuIncomingMailsPage
{
   private WebDriver Driver { get; }

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

   public MailRuIncomingMailsPage(WebDriver driver)
   {
      Driver = driver;
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
}