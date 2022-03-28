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
    [DataRow("account1.test1", "strongpassword")]
    [DataRow("account2.test", "strongpassword")]
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
        
        Assert.IsNotNull(mailRuIncomingMailPage);
    }

    [TestCleanup]
    public void TestCleanup()
    {
       Driver.Close(); 
       Driver.Quit();
    }
}