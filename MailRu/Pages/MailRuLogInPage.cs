using MailRu.Exceptions;
using OpenQA.Selenium;

namespace Pages.MailRu;

public class MailRuLogInPage
{
   private WebDriver Driver { get; }
   private string LogInTitle => "Authorization";
   private string MainPageTitle => "Mail.ru: почта, поиск в интернете, новости, игры";

   private string InputAccountNameCssSelector =>
      "#root > div > div > div > div.wrapper-0-2-5 > div > div > form > div:nth-child(2) > div:nth-child(2) >" +
      " div.login-row.username > div > div > div > div > div > div.base-0-2-58.first-0-2-64 > div > input";

   private string InputAccountNameXPath =>
      "//input[@name='username']";

   private string SubmitAccountNameButtonCssSelector =>
      "#root > div > div > div > div.wrapper-0-2-5 > div > div > form > div:nth-child(2) > div:nth-child(2) >" +
      " div:nth-child(3) > div > div > div.submit-button-wrap > button";

   private string InputPasswordCssSelector =>
      "#root > div > div > div > div.wrapper-0-2-5 > div > div > form > " +
      "div:nth-child(2) > div > div.login-row.password";

   private string SubmitPasswordButtonCssSelector =>
      "#root > div > div > div > div.wrapper-0-2-5 > div > div > form > " +
      "div:nth-child(2) > div > div:nth-child(3) > div > div > div.submit-button-wrap > div > button";

   public string AccountName { get; set; }
   public string Passowrd { get; set; }
   public MailRuSignInWith SignInWith { get; set; }



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

   public MailRuLogInPage(WebDriver driver, string accountName, string passowrd) : this(driver)
   {
      Driver = driver;
      AccountName = accountName;
      Passowrd = passowrd;
   }

   public MailRuLogInPage(WebDriver driver, string accountName, string passowrd, MailRuSignInWith signInWith) :
      this(driver, accountName, passowrd)
   {
      SignInWith = signInWith;
   }

   public MailRuLogInPage SendAccountName()
   {
      var input = Driver.FindElement(By.CssSelector(InputAccountNameCssSelector));
      input.SendKeys(AccountName);

      return this;
   }

   public MailRuLogInPage SubmitAccountName()
   {
      var submitButton = Driver.FindElement(By.CssSelector(SubmitAccountNameButtonCssSelector));
      submitButton.Click();

      return this;
   }

   public MailRuLogInPage SendPassword()
   {
      IWebElement input;
      try
      {
         input = Driver.FindElement(By.CssSelector(InputPasswordCssSelector));
         input.SendKeys(Passowrd);
      }
      catch (NoSuchElementException)
      {
         throw new MailRuLogInPasswordInputNotFoundException();
      }

      return this;
   }

   public MailRuIncomingMailPage SubmitPassword()
   {
      IWebElement button;
      try
      {
         button = Driver.FindElement(By.CssSelector(SubmitPasswordButtonCssSelector));
         button.Click();
      }
      catch (NoSuchElementException)
      {
         throw new MailRuLogInSubmitPasswordButtonNotFoundException();
      }

      return new MailRuIncomingMailPage(Driver);
   }
} 