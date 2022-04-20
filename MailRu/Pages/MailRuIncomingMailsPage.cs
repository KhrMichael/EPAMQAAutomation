using MailRu.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Pages.MailRu;

public class MailRuIncomingMailsPage
{
   private WebDriver Driver { get; }

   private TimeSpan LoadPageTime = TimeSpan.FromSeconds(10);
   private string UniqueElementXPath =>
      "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[1]/div[1]/div/div/div/div[1]/div/div/a";

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
}