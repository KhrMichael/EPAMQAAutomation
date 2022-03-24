// See https://aka.ms/new-console-template for more information

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

var chromeDriver = new ChromeDriver();
chromeDriver.Url = "https://www.bbc.com/sport";

var newsButtonLocator = By.XPath("//*[@id=\"orb-nav-links\"]/ul/li[2]");
var newsButton = chromeDriver.FindElement(newsButtonLocator);
newsButton.Click();
chromeDriver.Quit();