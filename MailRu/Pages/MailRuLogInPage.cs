using MailRu.Exceptions;
using MailRu.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailRu.Pages;

public class MailRuLogInPage
{
    private WebDriver Driver { get; }
    private Credentials Credentials { get; set; }
    private TimeSpan LoadPageTime => TimeSpan.FromSeconds(10);
    private TimeSpan FindElementTime => TimeSpan.FromSeconds(5);
    private string UniqueElementXPath => "//*[@id='login-content']";
    private string LoginFrameXPath => "/html/body/div[3]/div/iframe";
    private string NameInputXPath => "//input[@name='username']";
    private string SubmitAccountNameButtonXPath => "//*[@data-test-id='next-button']";
    private string PasswordInputXPath => "//*[@name='password']";
    private string PasswordSubmitButtonXPath => "//*[@data-test-id='submit-button']";
    private string InvalidAccountNameErrorXPath =>
        "//*[@data-test-id='required' or @data-test-id='accountNotRegistered']";

    public MailRuSignInWith SignInWith { get; set; }


    public MailRuLogInPage(WebDriver driver)
    {
        Driver = driver;
        LoadPage();
    }

    private void LoadPage()
    {
        var webDriverWait = new WebDriverWait(Driver, LoadPageTime);
        try
        {
            var loginFrame = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(LoginFrameXPath)));
            Driver.SwitchTo().Frame(loginFrame);
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(UniqueElementXPath)));
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuLogInPageSetupException();
        }
    }

    public MailRuLogInPage(WebDriver driver, Credentials credentials) : this(driver)
    {
        Credentials = credentials;
    }

    public MailRuLogInPage(WebDriver driver, Credentials credentials, MailRuSignInWith signInWith) :
        this(driver, credentials)
    {
        SignInWith = signInWith;
    }

    public MailRuLogInPage SendAccountName()
    {
        var webDriverWait = new WebDriverWait(Driver, FindElementTime);
        var accountName = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(NameInputXPath)));
        accountName.SendKeys(Credentials.Email);

        return this;
    }

    public MailRuLogInPage SetCredentials(Credentials credentials)
    {
        Credentials = credentials;
        return this;
    }

    public MailRuLogInPage SubmitAccountName()
    {
        var webDriverWait = new WebDriverWait(Driver, FindElementTime);
        var submitButton
            = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(SubmitAccountNameButtonXPath)));
        submitButton.Click();
        CheckCorrectAccountName();

        return this;
    }

    private void CheckCorrectAccountName()
    {
        var webDriverWait = new WebDriverWait(Driver, FindElementTime);
        try
        {
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(InvalidAccountNameErrorXPath)));
            throw new MailRuLogInIncorrectAccountNameException();
        }
        catch (WebDriverTimeoutException)
        { }
        catch (NoSuchElementException)
        { }
    }

    public MailRuLogInPage SendPassword()
    {
        var webDriverWait = new WebDriverWait(Driver, FindElementTime);
        try
        {
            var passwordInput = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(PasswordInputXPath)));
            passwordInput.SendKeys(Credentials.Password);
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuLogInPasswordInputNotFoundException();
        }

        return this;
    }

    public MailRuIncomingMailsPage SubmitPassword()
    {
        var webDriverWait = new WebDriverWait(Driver, FindElementTime);
        try
        {
            var submitButton =
                webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(PasswordSubmitButtonXPath)));
            submitButton.Click();
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuLogInSubmitPasswordButtonNotFoundException();
        }

        return new MailRuIncomingMailsPage(Driver, Credentials);
    }
}