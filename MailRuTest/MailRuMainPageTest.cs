using MailRu.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailRuTest;

[TestClass]
public class MailRuMainPageTest
{
    private WebDriver Driver { get; set; }
    private string Title => "Mail.ru: почта, поиск в интернете, новости, игры";
    
    [TestInitialize]
    public void Initialize()
    {
        Driver = new ChromeDriver();
    }
    
    [TestMethod]
    public void ShouldOpenMailRuMainPage()
    {
        new MailRuMainPage(Driver);
        
        Assert.AreEqual(Title, Driver.Title);
    }

    [TestMethod]
    public void ShouldOpenMailRuLogInPageByClickingOnLogInButton()
    {
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
}