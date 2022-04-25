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
    [DataRow("account1.test1@mail.ru", "strongpassword")]
    [DataRow("account2.test@mail.ru", "strongpassword")]
    public void ShouldLogInWithValidCredentials(string email, string password)
    {
        var mailRuLogInPage = new MailRuMainPage(Driver).LogInButtonClick();
        var credentials = new Credentials(string.Empty, string.Empty,  password, email);

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
    public void ShouldNotLogInWithInvalidCredentials(string email, string password)
    {
        var mailRuLogInPage = new MailRuMainPage(Driver).LogInButtonClick();
        var credentials = new Credentials(string.Empty, string.Empty, password, email );

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