using MailRu.Exceptions;
using OpenQA.Selenium;

namespace Pages.MailRu;

public class MailRuIncomingMailPage
{
   private WebDriver Driver { get; }
   private string Title => "Входящие - Почта Mail.ru";

   public MailRuIncomingMailPage(WebDriver driver)
   {
      Driver = driver;

      if (!Driver.Title.Equals(Title))
      {
         throw new MailRuIncomingMailPageSetupException();
      }
   }
}