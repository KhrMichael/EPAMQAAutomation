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
    private string Title => "Mail.ru: почта, поиск в интернете, новости, игры";

    public MailRuMainPage(WebDriver driver)
    {
        Driver = driver;
        var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        try
        {
            webDriverWait.Until(driver => driver.Title.Equals(Title));
        }
        catch(WebDriverTimeoutException)
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