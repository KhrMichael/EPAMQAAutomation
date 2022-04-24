using MailRu.Exceptions;
using MailRu.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using MailRu.Models;
using OpenQA.Selenium.DevTools.V85.WebAuthn;

namespace MailRuTest;

[TestClass]
public class MailRuLogInPageTest
{
    private WebDriver Driver { get; set; }

    [TestInitialize]
    public void Initialize()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TestMethod]
    [DataRow("account1.test1", "strongpassword")]
    [DataRow("account2.test", "strongpassword")]
    public void ShouldLogInWithValidCredentials(string accountName, string password)
    {
        var mailRuLogInPage = new MailRuMainPage(Driver).LogInButtonClick();
        var credentials = new Credentials(accountName, password);

        var mailRuIncomingMailPage = mailRuLogInPage
            .SetCredentials(credentials)
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();

        Assert.IsNotNull(mailRuIncomingMailPage);
    }

    [TestMethod]
    [ExpectedException(typeof(MailRuLogInIncorrectAccountNameException))]
    [DataRow("", "")]
    [DataRow("&&&&&", "")]
    [DataRow("", "&&&&&&")]
    [DataRow("&&&&&", "&&&&&&")]
    public void ShouldNotLogInWithInvalidCredentials(string accountName, string password)
    {
        var mailRuLogInPage = new MailRuMainPage(Driver).LogInButtonClick();
        var credentials = new Credentials(accountName, password);

        var mailRuIncomingMailPage = mailRuLogInPage
            .SetCredentials(credentials)
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        Driver.Close();
        Driver.Quit();
    }
}