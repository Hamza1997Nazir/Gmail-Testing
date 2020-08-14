using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossMail.Tests.PageObjects
{
    class StackOverFlow_Page
    {
        IWebDriver _browserDriver;

        public StackOverFlow_Page(IWebDriver _browserDriver)
        {
            this._browserDriver = _browserDriver;
            PageFactory.InitElements(_browserDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[text() ='Log in']")]  // login button on stackover flow
        private IWebElement Login_Button;

        public void goToStackOverFlow_Page()
        {
            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Navigate().GoToUrl("https://stackoverflow.com/");    //going to stack overflow
            System.Threading.Thread.Sleep(1000);
        }

        public ChooseLoginMethod_Page goToLoginEmail_Page_FromStackOverFlow_Page()
        {
            Login_Button.Click();
            System.Threading.Thread.Sleep(1000);
            return new ChooseLoginMethod_Page(_browserDriver);
        }
    }
}
