using MailRu.Exceptions;
using OpenQA.Selenium;

namespace Pages.MailRu;

public class MailRuLogInPage
{
   private string PopupFrameShowXPath => 
      "//div[@class='ag_js-popup-frame ag-popup__frame ag-popup__frame_onoverlay ag-popup__frame_show']";
   private WebDriver Driver { get; }
      
   public string Title => "Mail.ru: почта, поиск в интернете, новости, игры";

   public MailRuLogInPage(WebDriver driver)
   {
      Driver = driver;

      if (!Driver.Title.Equals(Title) || driver.FindElement(By.XPath(PopupFrameShowXPath)) is null)
      {
         throw new MailRuLogInPageSetupException();
      }
   }
}