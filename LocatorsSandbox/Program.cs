// See https://aka.ms/new-console-template for more information

using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.DOM;
using OpenQA.Selenium.Support.UI;

var chromeDriver = new ChromeDriver();
chromeDriver.Url = "https://www.bbc.com/";

//click on first news on main page
var newsButton = chromeDriver.FindElement(By.CssSelector("#page > section.module.module--promo > div > ul > li.media-list__item.media-list__item--1 > div > a"));
newsButton.Click();

//click on africa news button
chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
var africaNews = chromeDriver.FindElement(By.XPath("//*[@id=\"orb-modules\"]/header/div[2]/div[2]/div[1]/nav/ul/li[1]/a"));
africaNews.Click();

//click on search button
chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
var searchButton = chromeDriver.FindElement(By.XPath("//*[@id='orbit-search-button']"));
searchButton.Click();

//fill search input and click on search button
chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
var searchInput = chromeDriver.FindElement(By.XPath("//*[@id='search-input']"));
searchInput.SendKeys("belarus");
//var searchInputButton = chromeDriver.FindElement(By.XPath("//*[@id='main-content']/div[1]/form/div/div/div/button"));
var searchInputButton = chromeDriver.FindElement(By.XPath("//*[@id='search-input']/following-sibling::button"));
searchInputButton.Click();

//click on first belarus news
chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
var belarusFirstNews = chromeDriver.FindElement(By.XPath("//*[@id='main-content']/div/div[@class='ssrcss-1v7bxtk-StyledContainer enjd40x0']/div/div/ul/li[1]"));
belarusFirstNews.Click();


chromeDriver.Close();
chromeDriver.Quit();