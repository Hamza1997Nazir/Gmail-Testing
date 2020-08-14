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
    class Google_Page
    {
        private IWebDriver _browserDriver;
        private WebDriverWait wait;
        public Google_Page(IWebDriver _browserDriver)
        {
            this._browserDriver = _browserDriver;
            wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_browserDriver, this);
        }

        [FindsBy(How = How.XPath, Using =("//*[text() ='Gmail']"))]
        private IWebElement Gmail_Button;

        public Gmail_Page goToGmail_Page()
        {
            System.Threading.Thread.Sleep(1000);
            Gmail_Button.Click();
            return new Gmail_Page(_browserDriver);
        }

    }
}
