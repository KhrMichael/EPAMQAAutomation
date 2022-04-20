using MailRu.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Page;
using OpenQA.Selenium.Support.UI;

namespace Pages.MailRu;

public class MailRuLogInPage
{
    private WebDriver Driver { get; }
    private double LoadPageTime => 10;
    private double FindElementTime => 5;
    private string UniqueElementXPath => "//*[@id='login-content']";
    private string LoginFrameXPath => "/html/body/div[3]/div/iframe";
    private string NameInputXPath => "//input[@name='username']";
    private string SubmitAccountNameButtonXPath => "//*[@data-test-id='next-button']";
    private string PasswordInputXPath => "//*[@name='password']";
    private string PasswordSubmitButtonXPath => "//*[@data-test-id='submit-button']";

    private string InvalidAccountNameErrorXPath => 
        "//*[@data-test-id='required' or @data-test-id='accountNotRegistered']";

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
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(FindElementTime));
        var accountName = webDriverWait.Until(driver => driver.FindElement(By.XPath(NameInputXPath)));
        accountName.SendKeys(AccountName);

        return this;
    }

    public MailRuLogInPage SubmitAccountName()
    {
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(FindElementTime));
        var submitButton
            = webDriverWait.Until(driver => driver.FindElement(By.XPath(SubmitAccountNameButtonXPath)));
        submitButton.Click();
        CheckCorrectAccountName();

        return this;
    }

    private void CheckCorrectAccountName()
    {
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(FindElementTime));
        try
        {
            webDriverWait.Until(driver => driver.FindElement(By.XPath(InvalidAccountNameErrorXPath)));
            throw new MailRuLogInIncorrectAccountNameException();
        }
        catch (WebDriverTimeoutException)
        {
        }
    }

    public MailRuLogInPage SendPassword()
    {
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(FindElementTime));
        try
        {
            var passwordInput = webDriverWait.Until(driver => driver.FindElement(By.XPath(PasswordInputXPath)));
            passwordInput.SendKeys(Passowrd);
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuLogInPasswordInputNotFoundException();
        }

        return this;
    }

    public MailRuIncomingMailPage SubmitPassword()
    {
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(FindElementTime));
        try
        {
            var submitButton =
                webDriverWait.Until(driver => driver.FindElement(By.XPath(PasswordSubmitButtonXPath)));
            submitButton.Click();
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuLogInSubmitPasswordButtonNotFoundException();
        }

        return new MailRuIncomingMailPage(Driver);
    }
}