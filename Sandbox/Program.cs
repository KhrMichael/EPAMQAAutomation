using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;using OpenQA.Selenium.Support.UI;
using Pages.MailRu;

var chromeDriver = new ChromeDriver();
chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
chromeDriver.Url = "https://mail.ru/";

var mailRuMainPage = new MailRuMainPage(chromeDriver);

var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
mailRuLogInPage.AccountName = "account1.test1";
mailRuLogInPage.Passowrd = "strongpassword";

var webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(15));

var mailRuIncomingMailPage = mailRuLogInPage
    .SendAccountName()
    .SubmitAccountName()
    .SendPassword()
    .SubmitPassword();