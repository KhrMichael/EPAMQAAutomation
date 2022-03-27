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
    
    [TestInitialize]
    public void Initialize()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }
    
    [TestMethod]
    public void ShouldOpenMailRuMainPage()
    {
        Driver.Url = MailRuURI;

        Assert.AreEqual("Mail.ru: почта, поиск в интернете, новости, игры", Driver.Title);
    }

    [TestCleanup]
    public void Cleanup()
    {
       Driver.Close();
       Driver.Quit();
    }
}