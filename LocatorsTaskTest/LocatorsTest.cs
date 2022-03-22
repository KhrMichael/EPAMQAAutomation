using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LocatorsTaskTest;

[TestClass]
public class LocatorsTest
{
    private WebDriver driver;
    
    [TestInitialize]
    public void Initialize()
    {
        driver = new ChromeDriver();
    }

    [TestMethod]
    public void ShouldOpenBbcNewsPage()
    {
        driver.Url = "https://www.bbc.com/sport";
        var newsButtonXPath = By.XPath("//*[@id=\"orb-nav-links\"]/ul/li[2]");
        var newsButton = driver.FindElement(newsButtonXPath);
        newsButton.Click();
        
        Assert.AreEqual("Home - BBC News", driver.Title);
    }

    [TestCleanup]
    public void EndTest()
    {
        driver.Quit();
    }
}