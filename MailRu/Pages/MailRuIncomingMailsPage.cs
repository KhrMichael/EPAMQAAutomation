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
    private Credentials Credentials { get; }
    private TimeSpan LoadPageTime = TimeSpan.FromSeconds(20);
    private TimeSpan FindeElementTime => TimeSpan.FromSeconds(10);

    private string UniqueElementXPath => "(//a[contains(@class, 'compose-button')])";
    private string WriteMessageButtonXPath => "(//a[contains(@class, 'compose-button')])";
    private string ReceiverInputXPath => "(//*[contains(@class, 'head_container')]//input)";
    private string SubjectInputXPath => "(//*[contains(@class, 'subject__container')]//input)";
    private string MessageBodyXPath => "(//*[contains(@class, 'cke_editable')]/div[not(@*)])";
    private string SendMessageButtonXPath => "(//*[contains(@class, 'compose-app__buttons')]/span[1])";

    private string IncomingMessageGroupsXPath =>
        "(//*[contains(@class, 'llc_first')] | //*[contains(@class, 'llc_first')]/following-sibling::*[contains(@class, 'llc')])";

    private string IncomingMessageGroupSenderXPath => "//span[contains(@title, '@')]";
    private string IncomingMessageGroupSubjectXPath => "//*[contains(@class, 'llc__subject')]";
    private string IncomingMessageBodyXPath => "(//*[contains(@id, 'BODY')])";
    private string IncomingMessageGroupReadStatusXPath => "//*[contains(@class, 'll-rs')]";
    private string IncomingMessageXPath => "(//*[contains(@class, 'thread__letter')])";

    public MailRuIncomingMailsPage(WebDriver driver, Credentials credentials)
    {
        Driver = driver;
        Credentials = credentials;
        LoadPage();
    }

    private void LoadPage()
    {
        var webDriverWait = new WebDriverWait(Driver, LoadPageTime);
        try
        {
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(UniqueElementXPath)));
        }
        catch (WebDriverTimeoutException)
        {
            throw new MailRuIncomingMailPageSetupException();
        }
    }

    public MailRuIncomingMailsPage OpenMessageConstructor()
    {
        var webDriverWait = new WebDriverWait(Driver, FindeElementTime);
        var actions = new Actions(Driver);
        try
        {
            var writeMessageButton =
                webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(WriteMessageButtonXPath)));
            actions.MoveToElement(writeMessageButton).Perform();
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
        var actions = new Actions(Driver);
        try
        {
            var receiverInput = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(ReceiverInputXPath)));
            var themeInput = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(SubjectInputXPath)));
            var messageBody =
                webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(MessageBodyXPath)));

            receiverInput.SendKeys(message.Receiver);
            themeInput.SendKeys(message.Theme);
            if (messageBody.Count >= 1)
            {
                messageBody[0].SendKeys(message.Body);
                for (int i = 1; i < messageBody.Count; i++)
                {
                    Driver.ExecuteScript(
                        $"return document.evaluate(\"{MessageBodyXPath + $"[{i + 1}]"}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.remove();");
                }
            }
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
        var actions = new Actions(Driver);
        try
        {
            var sendButton = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(SendMessageButtonXPath)));
            actions.MoveToElement(sendButton).Perform();
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
        var actions = new Actions(Driver);
        try
        {
            var messageGroups = webDriverWait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(IncomingMessageGroupsXPath)));
            var senderEmailRegex = new Regex(@"\w*[.]*\w*[@]mail.ru"); //sender email pattern
            for (int groupNumber = 0; groupNumber < messageGroups.Count; groupNumber++)
            {
                //actions.MoveToElement(messageGroups[groupNumber]);
                var groupRoot = $"{IncomingMessageGroupsXPath}[{groupNumber + 1}]";
                var isUnread = webDriverWait
                    .Until(ExpectedConditions.ElementExists(By.XPath(groupRoot + IncomingMessageGroupReadStatusXPath)))
                    .GetAttribute("class").Contains("ll-rs_is-active");
                var groupSenderTitle =
                    webDriverWait
                        .Until(ExpectedConditions.ElementExists(By.XPath(groupRoot + IncomingMessageGroupSenderXPath)))
                        .GetAttribute("title");
                var groupSender = senderEmailRegex.Match(groupSenderTitle).Value;
                var groupTheme = webDriverWait
                    .Until(ExpectedConditions.ElementExists(By.XPath(groupRoot + IncomingMessageGroupSubjectXPath)))
                    .Text;

                messageGroups[groupNumber].Click();

                var messages =
                    webDriverWait.Until(
                        ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(IncomingMessageXPath)));
                var messageBodies = GetMessageBodies(messages);
                foreach (var messageBody in messageBodies)
                {
                    var message = new Message(Credentials.Email, groupTheme, messageBody);
                    messageInfos.Add(new MessageInfo(message, isUnread, groupSender));
                }

                Driver.Navigate().Back();
                //refresh messageGroups in order to match the content of the page
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
        var actions = new Actions(Driver);
        foreach (var message in messages)
        {
            actions.MoveToElement(message).Perform();
            message.Click();
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
            var messagePartsXPath = $"{IncomingMessageBodyXPath}[{messageNumber + 1}]/div/div[not(@*)]";
            var bodyParts =
                webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(messagePartsXPath)));
            foreach (var bodyPart in bodyParts)
            {
                messageBodyText += bodyPart.Text;
            }

            messageBodies.Add(messageBodyText);
        }

        return new ReadOnlyCollection<string>(messageBodies);
    }
}