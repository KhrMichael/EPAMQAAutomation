using MailRu.Exceptions;
using OpenQA.Selenium;

namespace Pages.MailRu;

public class MailRuLogInPage
{
   private string PopupFrameShowXPath => 
      "//div[@class='ag_js-popup-frame ag-popup__frame ag-popup__frame_onoverlay ag-popup__frame_show']";
   private WebDriver Driver { get; }
      
   public string LogInTitle => "Authorization";
   public string MainPageTitle => "Mail.ru: почта, поиск в интернете, новости, игры";

   public MailRuLogInPage(WebDriver driver)
   {
      Driver = driver;

      var titleElements = Driver.FindElements(By.TagName("title"));
      var titles = titleElements.Select(title => title.Text);

      if (titles.Contains(LogInTitle) && titles.Contains(MainPageTitle))
      {
         throw new MailRuLogInPageSetupException();
      }
   }
}