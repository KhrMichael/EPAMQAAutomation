using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

var chromeDriver = new ChromeDriver();
chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
chromeDriver.Url = "https://www.bbc.com/";

//click on the first news on the main page
var newsButton = chromeDriver.FindElement(By.CssSelector("#page > section.module.module--promo > div > ul > li.media-list__item.media-list__item--1 > div > a"));
newsButton.Click();

//click on the africa news button
var africaNews = chromeDriver.FindElement(By.XPath("//*[@id=\"orb-modules\"]/header/div[2]/div[2]/div[1]/nav/ul/li[1]/a"));
africaNews.Click();

//click on the search button
var searchButton = chromeDriver.FindElement(By.XPath("//*[@id='orbit-search-button']"));
searchButton.Click();

//fill the search input and click on the search button
var searchInput = chromeDriver.FindElement(By.XPath("//*[@id='search-input']"));
searchInput.SendKeys("belarus");
//var searchInputButton = chromeDriver.FindElement(By.XPath("//*[@id='main-content']/div[1]/form/div/div/div/button"));
var searchInputButton = chromeDriver.FindElement(By.XPath("//*[@id='search-input']/following-sibling::button"));
searchInputButton.Click();

//click on the first belarus news
var belarusFirstNews = chromeDriver.FindElement(By.XPath("//*[@id='main-content']/div/div[@class='ssrcss-1v7bxtk-StyledContainer enjd40x0']/div/div/ul/li[1]"));
belarusFirstNews.Click();

chromeDriver.Close();
chromeDriver.Quit();