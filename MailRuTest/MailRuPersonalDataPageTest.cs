using MailRu.Models;
using MailRu.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailRuTest;

[TestClass]
public class MailRuPersonalDataPageTest
{
    private WebDriver Driver { get; set; }
    private Credentials Account1 => new Credentials("test1", "account1", "strongpassword", "account1.test1@mail.ru");
    private Credentials Account2 => new Credentials("test", "account2", "strongpassword", "account2.test@mail.ru");

    [TestInitialize]
    public void TestInitialize()
    {
        Driver = new ChromeDriver();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        Driver.Close();
        Driver.Quit();
    }

    [TestMethod]
    [DataRow("NewName")]
    public void ShouldChangeAccountName(string newAccountName)
    {
        var mailRuPersonalDataPage = GetMailRuPersonalDataPage(Account1);

        mailRuPersonalDataPage
            .SetAccountName(newAccountName)
            .SaveChanges();
        
        Assert.AreEqual(newAccountName, mailRuPersonalDataPage.Credentials.Name);
    }

    private MailRuPersonalDataPage GetMailRuPersonalDataPage(Credentials credentials)
    {
        var mailRuMainPage = new MailRuMainPage(Driver);
        var mailRuLogInPage = mailRuMainPage.LogInButtonClick();
        var mailRuIncomingMailsPage = mailRuLogInPage
            .SetCredentials(credentials)
            .SendAccountName()
            .SubmitAccountName()
            .SendPassword()
            .SubmitPassword();
        var mailRuPersonalDataPage = mailRuIncomingMailsPage
            .ClickOnProfileButton()
            .ClickOnAccountDataButton();

        return mailRuPersonalDataPage;
    }

}