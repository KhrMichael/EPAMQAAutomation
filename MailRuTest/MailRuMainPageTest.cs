using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages.MailRu;

namespace MailRuTest;

[TestClass]
public class MailRuMainPageTest
{
    private WebDriver Driver { get; set; }
    private string MailRuURI => "https://mail.ru/";
    private string Title => "Mail.ru: почта, поиск в интернете, новости, игры";
    
    [ClassInitialize]
    public void Initialize()
    {
        Driver = new ChromeDriver();
    }
    
    [TestMethod]
    public void ShouldOpenMailRuMainPage()
    {
        Driver.Url = MailRuURI;

        Assert.AreEqual(Title, Driver.Title);
    }

    [TestMethod]
    public void ShouldOpenMailRuLogInPageByClickingOnLogInButton()
    {
        Driver.Url = MailRuURI;
        var mailRuMainPage = new MailRuMainPage(Driver);

        var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
        
        Assert.IsNotNull(mailRuMainPage);
    }

    [TestCleanup]
    public void TestCleanup()
    {
       Driver.Close();
       Driver.Quit();
    }

    [ClassCleanup]
    public void ClassCleanup()
    {
       Driver.Quit();
    }
}