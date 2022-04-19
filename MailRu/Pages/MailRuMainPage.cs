using System.Diagnostics;
using System.Text.RegularExpressions;
using MailRu.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages.MailRu;

public class MailRuMainPage
{
    private WebDriver Driver { get; }
    private string LogInButtonXPath => "//*[@class='ph-login svelte-1hiqrvn']";
    private string UniqueElementXPath => "//*[@id='mailbox']";
    private double LoadPageTime => 10;

    public MailRuMainPage(WebDriver driver)
    {
        Driver = driver;
        LoadPage();
    }

    private void LoadPage()
    {
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(LoadPageTime));
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