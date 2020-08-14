using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private IWebDriver _browserDriver;
        private WebDriverWait wait;
        public Login_Email_Page(IWebDriver _browserDriver)
        {
            this._browserDriver = _browserDriver;
            wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(10));
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

        public Login_Password_Page goToLoginPassword_Page()
        {
            Next_Button.Click();
            return new Login_Password_Page(_browserDriver);
        }
       
    }
}
