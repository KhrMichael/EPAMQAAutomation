using MailRu.Exceptions;
using MailRu.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;

namespace MailRu.Pages;

public class MailRuIncomingMailsPage
{
    private WebDriver Driver { get; }
    private string AccountName { get; }
    private TimeSpan LoadPageTime = TimeSpan.FromSeconds(20);
    private TimeSpan FindeElementTime => TimeSpan.FromSeconds(10);
    private string UniqueElementXPath =>
       "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[1]/div[1]/div/div/div/div[1]/div/div/a";
    private string WriteMessageButtonXPath =>
       "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[1]/div[1]/div/div/div/div[1]/div/div/a";
    private string ReceiverInputXPath =>
       "/html/body/div[1]/div/div[2]/div/div[1]/div[2]/div[3]/div[2]/div/div/div[1]/div/div[2]/div/div/label/div/div/input";
    private string ThemeInputXPath =>
       "/html/body/div[1]/div/div[2]/div/div[1]/div[2]/div[3]/div[3]/div[1]/div[2]/div/input";
    private string MessageBodyXPath =>
       "/html/body/div[1]/div/div[2]/div/div[1]/div[2]/div[3]/div[5]/div/div/div[2]/div[1]/div[1]";
    private string SendMessageButtonXPath => "/html/body/div[1]/div/div[2]/div/div[2]/div[1]/span[1]";
    private string IncomingMessageGroupsXPath =>
       "//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div/div[1]/div/div/a";
    private string IncomingMessageGroupSenderXPath => "/div[4]/div/div/span";
    private string IncomingMessageGroupThemeXPath => "//*[contains(@class, 'llc__subject')]";
    private string IncomingMessageBodyXPath => "(//*[contains(@id, 'BODY')])";
    private string IncomingMessageGroupIsUnreadXPath => "/div[2]/span";
    private string IncomingMessagesXPath =>
       "(//*[@id='app-canvas']/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div/div[contains(@class, 'thread__letter')])";

    private string IncomingMessageXPath => "/div[contains(@class, 'thread__letter')]";

    public MailRuIncomingMailsPage(WebDriver driver, string accountName)
    {
        Driver = driver;
        AccountName = accountName;
        LoadPage();
    }

    private void LoadPage()
    {
        var webDriverWait = new WebDriverWait(Driver, LoadPageTime);

        try
        {
            webDriverWait.Until(driver => driver.FindElement(By.XPath(UniqueElementXPath)));
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuIncomingMailPageSetupException();
        }
    }

    public MailRuIncomingMailsPage OpenMessageConstructor()
    {
        var webDriverWait = new WebDriverWait(Driver, FindeElementTime);
        try
        {
            var writeMessageButton = webDriverWait.Until(driver => driver.FindElement(By.XPath(WriteMessageButtonXPath)));
            writeMessageButton.Click();
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuIncomingMailsPageOpenMessageConstructorException();
        }

        return this;
    }

    public MailRuIncomingMailsPage WriteMessage(Message message)
    {
        var webDriverWait = new WebDriverWait(Driver, FindeElementTime);
        try
        {
            var receiverInput = webDriverWait.Until(driver => driver.FindElement(By.XPath(ReceiverInputXPath)));
            var themeInput = webDriverWait.Until(driver => driver.FindElement(By.XPath(ThemeInputXPath)));
            var messageBody = webDriverWait.Until(driver => driver.FindElement(By.XPath(MessageBodyXPath)));

            receiverInput.SendKeys(message.Receiver);
            themeInput.SendKeys(message.Theme);
            messageBody.SendKeys(message.Body);
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuIncomingMailsPageWriteMessageException();
        }

        return this;
    }

    public void SendMessage()
    {
        var webDriverWait = new WebDriverWait(Driver, FindeElementTime);

        try
        {
            var sendButton = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(SendMessageButtonXPath)));
            sendButton.Click();
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuIncomingMailsPageSendMessageException();
        }
    }

    public List<MessageInfo> GetIncomingMessages()
    {
        var messageInfos = new List<MessageInfo>();
        var webDriverWait = new WebDriverWait(Driver, LoadPageTime);
        try
        {
            var messageGroups = webDriverWait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(IncomingMessageGroupsXPath)));
            for (int groupNumber = 0; groupNumber < messageGroups.Count; groupNumber++)
            {
                var groupRoot = $"{IncomingMessageGroupsXPath}[{groupNumber + 1}]";
                var isUnread =
                    webDriverWait
                        .Until(
                            ExpectedConditions.ElementExists(By.XPath(groupRoot + IncomingMessageGroupIsUnreadXPath)))
                        .GetAttribute("class").Contains("ll-rs_is-active");
                var regex = new Regex(@"\w*[.]*\w*[@]mail.ru");//sender email pattern
                var groupSenderTitle =
                    webDriverWait
                        .Until(ExpectedConditions.ElementExists(By.XPath(groupRoot + IncomingMessageGroupSenderXPath)))
                        .GetAttribute("title");
                var groupSender = regex.Match(groupSenderTitle).Value;
                var groupTheme =
                    webDriverWait
                        .Until(ExpectedConditions.ElementExists(By.XPath(groupRoot + IncomingMessageGroupThemeXPath)))
                        .Text;

                messageGroups[groupNumber].Click();

                var messages =
                    webDriverWait.Until(
                        ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(IncomingMessagesXPath)));
                var messageBodies = GetMessageBodies(messages);
                foreach (var messageBody in messageBodies)
                {
                    var message = new Message(AccountName, groupTheme, messageBody);
                    messageInfos.Add(new MessageInfo(message, isUnread, groupSender));
                }

                Driver.Navigate().Back();
                messageGroups = webDriverWait.Until(
                    ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(IncomingMessageGroupsXPath)));
            }
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuIncomingMailsPageGetIncomingMessagesException();
        }

        return messageInfos;
    }

    private void OpenAllMessages(ReadOnlyCollection<IWebElement> messages)
    {
        var webDriverWait = new WebDriverWait(Driver, FindeElementTime);
        var actions = new Actions(Driver);
        foreach (var message in messages)
        {
            actions.MoveToElement(message).Click().Perform();
        }
    }

    private ReadOnlyCollection<string> GetMessageBodies(ReadOnlyCollection<IWebElement> messages)
    {
        var messageBodies = new List<string>();
        var webDriverWait = new WebDriverWait(Driver, FindeElementTime);
        OpenAllMessages(messages);
        for (int messageNumber = 0; messageNumber < messages.Count; messageNumber++)
        {
            string messageBodyText = string.Empty;
            var messageBody = $"{IncomingMessageBodyXPath}[{messageNumber + 1}]/div/div[not(@*)]";
            var bodyParts =
                webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(messageBody)));
            foreach (var bodyPart in bodyParts)
            {
                messageBodyText += bodyPart.Text;
            }
            messageBodies.Add(messageBodyText);
        }

        return new ReadOnlyCollection<string>(messageBodies);
    }
}