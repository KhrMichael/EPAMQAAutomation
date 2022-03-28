using MailRu.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Pages.MailRu;

public class MailRuIncomingMailPage
{
   private WebDriver Driver { get; }
   private string Title => "Входящие - Почта Mail.ru";

   public MailRuIncomingMailPage(WebDriver driver)
   {
      Driver = driver;
      var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

      try
      {
         webDriverWait.Until(driver => driver.Title.Contains(Title));
      }
      catch(WebDriverTimeoutException)
      {
         throw new MailRuIncomingMailPageSetupException();
      }
   }
}