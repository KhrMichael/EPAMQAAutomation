using MailRu.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Page;
using OpenQA.Selenium.Support.UI;

namespace Pages.MailRu;

public class MailRuLogInPage
{
   private WebDriver Driver { get; }
   private double LoadPageTime => 10;
   private string UniqueElementXPath => "//*[@id='login-content']";
   private string LoginFrameXPath => "/html/body/div[3]/div/iframe";
   private string InputAccountNameCssSelector =>
      "#root > div > div > div > div.wrapper-0-2-5 > div > div > form > div:nth-child(2) > div:nth-child(2) >" +
      " div.login-row.username > div > div > div > div > div > div.base-0-2-58.first-0-2-64 > div > input";
   private string InputAccountNameXPath =>
      "//input[@name='username']";
   private string SubmitAccountNameButtonCssSelector =>
      "#root > div > div > div > div.wrapper-0-2-5 > div > div > form > div:nth-child(2) > div:nth-child(2) >" +
      " div:nth-child(3) > div > div > div.submit-button-wrap > button";
   private string InputPasswordXPath =>
      "//*[@id='root']/div/div/div/div[2]/div/div/form/div[2]/div/div[2]/div/div/div/div/div/input";
   private string InputPasswordName => "password";
   private string SubmitPasswordButtonCssSelector =>
      "#root > div > div > div > div.wrapper-0-2-5 > div > div > form > " +
      "div:nth-child(2) > div > div:nth-child(3) > div > div > div.submit-button-wrap > div > button";
   private string LogInAccountNameErrorDivXPath =>
      "//*[@id='root']/div/div/div/div[2]/div/div/form/div[2]/div[2]/div[1]/div/div/div/div[2]/small";

   public string AccountName { get; set; }
   public string Passowrd { get; set; }
   public MailRuSignInWith SignInWith { get; set; }



   public MailRuLogInPage(WebDriver driver)
   {
      Driver = driver;
      LoadPage();
   }

   private void LoadPage()
   {
      var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(LoadPageTime));
      try
      {
         var loginFrame = webDriverWait.Until(driver => driver.FindElement(By.XPath(LoginFrameXPath)));
         webDriverWait.Until(driver => driver.SwitchTo().Frame(loginFrame));
         webDriverWait.Until(driver => driver.FindElement(By.XPath(UniqueElementXPath)));
      }
      catch (WebDriverTimeoutException)
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
      Driver.SwitchTo().ActiveElement();
      var input = Driver.FindElement(By.CssSelector(InputAccountNameCssSelector));
      input.SendKeys(AccountName);

      return this;
   }

   public MailRuLogInPage SubmitAccountName()
   {
      var submitButton = Driver.FindElement(By.CssSelector(SubmitAccountNameButtonCssSelector));
      submitButton.Click();

      try
      {
         new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(driver =>
            driver.FindElement(By.XPath(LogInAccountNameErrorDivXPath)));
         throw new MailRuLogInIncorrectAccountNameException();
      }
      catch (WebDriverTimeoutException)
      { }

      return this;
   }

   public MailRuLogInPage SendPassword()
   {
      IWebElement input;
      try
      {
         Driver.SwitchTo().ActiveElement();
         input = Driver.FindElement(By.Name(InputPasswordName));
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