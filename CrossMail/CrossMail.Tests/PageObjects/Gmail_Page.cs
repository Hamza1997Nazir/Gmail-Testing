using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace CrossMail.Tests.PageObjects
{
    class Gmail_Page
    {
        private IWebDriver _browserDriver;
        private WebDriverWait wait;
        public Gmail_Page(IWebDriver _browserDriver)
        {
            this._browserDriver = _browserDriver;
            wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_browserDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class ='T-I T-I-KE L3']")]  // email compose button 
        private IWebElement Compose_Button;

        [FindsBy(How = How.XPath, Using = "//textarea[@name ='to']")]     // 'To' Email address text field
        private IWebElement ToEmailAddress;

        [FindsBy(How = How.XPath, Using = "//input[@name ='subjectbox']")] // Subject box of email
        private IWebElement EmailSubject;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='More options']")] // 'three dots' for more options
        private IWebElement ThreeDots;

        [FindsBy(How = How.XPath, Using = "//*[text() ='Label']")]      //The label option 
        private IWebElement LabelOption;

        [FindsBy(How = How.XPath, Using = "//div[@class='J-LC']")] // for chekcing the Social Label 
        private IWebElement SocialCheckBox;

        [FindsBy(How = How.XPath, Using = "//div[@class ='Am Al editable LW-avf tS-tW']")] // The Body of email
        private IWebElement EmailBody;

        public void WritingAndSendingEmail(string to, string subject, string body)
        {
            System.Threading.Thread.Sleep(1000);
            Compose_Button.Click();

            System.Threading.Thread.Sleep(1000);
            ToEmailAddress.SendKeys(to);

            System.Threading.Thread.Sleep(1000);
            EmailSubject.SendKeys(subject);


            System.Threading.Thread.Sleep(1000);
            ThreeDots.Click();

            System.Threading.Thread.Sleep(1000);
            LabelOption.Click();

            System.Threading.Thread.Sleep(1000);
            SocialCheckBox.Click();

            System.Threading.Thread.Sleep(1000);
            EmailBody.SendKeys(body + Keys.Control + Keys.Enter);
        }

    }
}
