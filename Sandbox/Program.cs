using System;
using MailRu.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

var chromeDriver = new ChromeDriver();
var mailRuMainPage = new MailRuMainPage(chromeDriver);
var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
mailRuLogInPage.AccountName = "account2.test";
mailRuLogInPage.Passowrd = "strongpassword";
var mailRuIncomingMailsPage = mailRuLogInPage
    .SendAccountName()
    .SubmitAccountName()
    .SendPassword()
    .SubmitPassword();


var webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
var webElement = webDriverWait.Until(driver =>
    driver.FindElement(By.XPath(
        "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div/div[1]/div/div")));
var incomingMessageGroups =
    webDriverWait.Until(driver =>
        webElement.FindElements(By.XPath("a")));
for(int i = 0; i < incomingMessageGroups.Count; i++)
{
    webDriverWait.Timeout = TimeSpan.FromSeconds(10);
    //webElement = webDriverWait.Until(driver =>
    //    driver.FindElement(By.XPath(
    //        "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div/div[1]/div/div")));
    webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(
        "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div/div[1]/div/div/a")));
    incomingMessageGroups = chromeDriver.FindElements(By.XPath(
        "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div/div[1]/div/div/a"));
    incomingMessageGroups[i].Click();
    var backButton = webDriverWait.Until(driver =>
        driver.FindElement(
            By.XPath("//*[@id='app-canvas']/div/div[1]/div[1]/div/div[1]/span/div[1]/div/div/div/span/div")));
    var messageList = webDriverWait.Until(driver =>
        driver.FindElement(
            By.XPath("//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div")));
    Console.WriteLine(messageList);
    backButton.Click();
}

Console.WriteLine(incomingMessageGroups.Count);