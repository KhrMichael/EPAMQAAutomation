using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LocatorsTaskTest;

[TestClass]
public class LocatorsTest
{
    private WebDriver driver;

    [TestInitialize]
    public void Initialize()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [TestMethod]
    public void ShouldOpenBbcNewsPage()
    {
        driver.Url = "https://www.bbc.com/sport";
        var newsButtonXPath = By.XPath("//*[@id=\"orb-nav-links\"]/ul/li[2]");
        var newsButton = driver.FindElement(newsButtonXPath);
        
        newsButton.Click();

        new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.Title.Equals("Home - BBC News"));

        Assert.AreEqual("Home - BBC News", driver.Title);
    }

    [TestMethod]
    public void ShouldOpenBbcSearchPage()
    {
        driver.Url = "https://www.bbc.com";
        var searchButton = driver.FindElement(By.Id("orbit-search-button"));

        searchButton.Click();
        
        Assert.AreEqual("BBC - Search", driver.Title);
    }

    [TestCleanup]
    public void EndTest()
    {
        driver.Quit();
    }
}