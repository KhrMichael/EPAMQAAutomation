using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages.MailRu;

namespace MailRuTest;

[TestClass]
public class MailRuLogInPageTest
{
    private WebDriver Driver { get; set; }
    private string MailRuMainPageURI => "https://mail.ru/";

    [TestInitialize]
    public void Initialize()
    {
        Driver = new ChromeDriver();
        Driver.Url = MailRuMainPageURI;
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TestMethod]
    [DataRow("test.account1", "strongpassword")]
    [DataRow("test.account2", "strongpassword")]
    public void ShouldLogInWithValidCredentials(string accountName, string password)
    {
        var mailRuLogInPage = new MailRuMainPage(Driver).LogInButtonClick();
        mailRuLogInPage.Passowrd = password;
        mailRuLogInPage.AccountName = accountName;

        var mailRuIncomingMailPage = mailRuLogInPage
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();
        
        Assert.IsTrue(Driver.Title.Contains("Входящие - Почта Mail.ru"));
    }

    [TestCleanup]
    public void TestCleanup()
    {
       Driver.Close(); 
       Driver.Quit();
    }
}