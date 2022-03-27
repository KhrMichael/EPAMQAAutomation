using System.Diagnostics;
using System.Text.RegularExpressions;
using MailRu.Exceptions;
using OpenQA.Selenium;

namespace Pages.MailRu;

public class MailRuMainPage
{
    private WebDriver Driver { get; }
    private string LogInXPathButtonLocator => "//*[@id='ph-whiteline']/div/div[2]/button";
        
    public string Title => "Mail.ru: почта, поиск в интернете, новости, игры";

    public MailRuMainPage(WebDriver driver)
    {
        Driver = driver;
        
        if (!Driver.Title.Equals(Title)) 
        {
            throw new MailRuMainPageSetupException();
        }
    }

    public MailRuLogInPage LogInButtonClick()
    {
        var logInButton = Driver.FindElement(By.XPath(LogInXPathButtonLocator));
        logInButton.Click();

        return new MailRuLogInPage(Driver);
    }
}