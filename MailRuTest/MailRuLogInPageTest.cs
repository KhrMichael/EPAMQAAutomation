using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailRuTest;

[TestClass]
public class MailRuLogInPageTest
{
    private WebDriver Driver { get; set; }
    
    [ClassInitialize]
    public void Initialize()
    {
        Driver = new ChromeDriver();
    }

    [TestCleanup]
    public void TestCleanup()
    {
       Driver.Close(); 
    }

    [ClassCleanup]
    public void ClassCleanup()
    {
       Driver.Quit();
    }
}