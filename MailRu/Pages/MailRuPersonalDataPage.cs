using System.Globalization;
using System.Net.NetworkInformation;
using MailRu.Exceptions;
using MailRu.Models;
using MailRu.Models.Builders;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MailRu.Pages;

public class MailRuPersonalDataPage
{
    private WebDriver Driver { get; }
    private TimeSpan PageLoadTime => TimeSpan.FromSeconds(20);
    private TimeSpan ElementFindTime => TimeSpan.FromSeconds(10);
    public Credentials Credentials { get; private set; }
    private CredentialsBuilder EditedCredentialsBuilder { get; }
    private string UniqueElementXPath => "//*[@data-test-id='photo-overlay']";
    private string AccountNameInputXPath => "//*[@data-test-id='firstname-field-input']";
    private string SaveButtonXPath => "//*[@data-test-id='save-button']";

    public MailRuPersonalDataPage(WebDriver driver, Credentials credentials)
    {
        Driver = driver;
        Credentials = credentials;
        EditedCredentialsBuilder = new CredentialsBuilder()
            .SetName(Credentials.Name)
            .SetSurname(Credentials.Surname)
            .SetNickname(Credentials.Nickname)
            .SetPassword(Credentials.Password)
            .SetSignInMethod(Credentials.SignInWith);
        LoadPage();
    }

    private void LoadPage()
    {
        var webDriverWait = new WebDriverWait(Driver, PageLoadTime);
        try
        {
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(UniqueElementXPath)));
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuPersonalDataPageSetupException();
        }
    }

    public MailRuPersonalDataPage SetAccountName(string accountName)
    {
        var webDriverWait = new WebDriverWait(Driver, ElementFindTime);
        try
        {
            var accountNameInput =
                webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(AccountNameInputXPath)));
            Driver.ExecuteScript($"return document.evaluate(\"{AccountNameInputXPath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.value = \"\";");
            accountNameInput.SendKeys(accountName);
            EditedCredentialsBuilder.SetName(accountName);
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuPersonalDataPageSetAccountNameException();
        }

        return this;
    }

    public MailRuPersonalDataPage SaveChanges()
    {
        var webDriverWait = new WebDriverWait(Driver, ElementFindTime);
        try
        {
            var saveChangesButton = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(SaveButtonXPath)));
            saveChangesButton.Click();
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuPersonalDataPageSaveChangesException();
        }
        Credentials = EditedCredentialsBuilder.Build();

        return this;
    }
}