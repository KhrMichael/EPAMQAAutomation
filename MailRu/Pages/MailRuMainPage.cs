using MailRu.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailRu.Pages;

public class MailRuMainPage
{
    private WebDriver Driver { get; }
    private string URI => "https://mail.ru/";
    private string LogInButtonXPath => "//*[contains(@class, 'ph-login')]";
    private string UniqueElementXPath => "//*[@id='mailbox']";
    private TimeSpan LoadPageTime => TimeSpan.FromSeconds(20);

    public MailRuMainPage(WebDriver driver)
    {
        Driver = driver;
        driver.Url = URI;
        LoadPage();
    }

    private void LoadPage()
    {
        var webDriverWait = new WebDriverWait(Driver, LoadPageTime);
        try
        {
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(UniqueElementXPath)));
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuMainPageSetupException();
        }
    }

    public MailRuLogInPage LogInButtonClick()
    {
        var webDriverWait = new WebDriverWait(Driver, LoadPageTime);
        var logInButton = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(LogInButtonXPath)));
        logInButton.Click();

        return new MailRuLogInPage(Driver);
    }
}