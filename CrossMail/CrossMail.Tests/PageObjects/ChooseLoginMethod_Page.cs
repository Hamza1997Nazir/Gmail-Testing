using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CrossMail.Tests.PageObjects
{
    class ChooseLoginMethod_Page
    {
        private IWebDriver _browserDriver;
        private WebDriverWait wait;
        public ChooseLoginMethod_Page(IWebDriver _browserDriver)
        {
            this._browserDriver = _browserDriver;
            wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_browserDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@data-provider ='google']")]
        private IWebElement googleLogin_Button;

        public Login_Email_Page goToLoginEmail_Page()
        {
            googleLogin_Button.Click();
            return new Login_Email_Page(_browserDriver);
        }
    }
}
