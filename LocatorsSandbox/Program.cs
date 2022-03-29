using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

var chromeDriver = new ChromeDriver();
chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
chromeDriver.Url = "https://www.bbc.com/";

//click on the first news on the main page
var newsButton =
    chromeDriver.FindElement(By.XPath(
        "//*[@id='orb-header']//*[@class='orb-nav-newsdotcom']"));
newsButton.Click();

//click on the africa news button
var africaNews =
    chromeDriver.FindElement(By.XPath(
        "//*[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//*[@href='/news/world']"));
africaNews.Click();

//click on the search button
var searchButton = chromeDriver.FindElement(By.XPath("//*[@id='orbit-search-button']"));
searchButton.Click();

//fill the search input and click on the search button
var searchInput = chromeDriver.FindElement(By.XPath("//*[@id='search-input']"));
searchInput.SendKeys("belarus");
var searchInputButton = chromeDriver.FindElement(By.XPath("//*[@id='search-input']/following-sibling::button"));
searchInputButton.Click();

//click on the first belarus news
var belarusFirstNews =
    chromeDriver.FindElement(By.XPath(
        "//*[@class='ssrcss-1020bd1-Stack e1y4nx260']/li[1]"));
belarusFirstNews.Click();

chromeDriver.Close();
chromeDriver.Quit();