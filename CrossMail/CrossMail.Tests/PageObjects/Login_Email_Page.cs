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
    class Login_Email_Page
    {
        IWebDriver _browserDriver;
        public Login_Email_Page(IWebDriver _browserDriver)
        {
            this._browserDriver = _browserDriver;
            PageFactory.InitElements(_browserDriver, this);
        }

        [FindsBy(How = How.Id, Using = "identifierId")]
        private IWebElement EmailTextBox;

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement Next_Button;

        public void enterEmailAddress(string email)
        {
            EmailTextBox.SendKeys(email);
        }

        public void goToLoginPassword_Page()
        {
            Next_Button.Click();
            return new Google_Page(_browserDriver);
        }
       
    }
}
