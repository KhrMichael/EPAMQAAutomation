using MailRu.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailRu.Pages;

public class MailRuMainPage
{
    private WebDriver Driver { get; }
    private string URI => "https://mail.ru/";
    private string LogInButtonXPath => "//*[@class='ph-login svelte-1hiqrvn']";
    private string UniqueElementXPath => "//*[@id='mailbox']";
    private TimeSpan LoadPageTime => TimeSpan.FromSeconds(10);

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
            webDriverWait.Until(driver => driver.FindElement(By.XPath(UniqueElementXPath)));
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuMainPageSetupException();
        }
    }

    public MailRuLogInPage LogInButtonClick()
    {
        var logInButton = Driver.FindElement(By.XPath(LogInButtonXPath));
        logInButton.Click();

        return new MailRuLogInPage(Driver);
    }
}