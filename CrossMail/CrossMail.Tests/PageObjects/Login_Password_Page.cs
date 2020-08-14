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
    class Login_Password_Page
    {
        private IWebDriver _browserDriver;
        private WebDriverWait wait;
        public Login_Password_Page(IWebDriver _browserDriver)
        {
            this._browserDriver = _browserDriver;
            wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_browserDriver, this);
        }

        [FindsBy(How = How.Id, Using = "//input[@name='password']")]
        private IWebElement PasswordTextField;

        [FindsBy(How=How.Id,Using = "passwordNext")]
        private IWebElement Next_Button;

        public void EnterPassword(string password)
        {
            System.Threading.Thread.Sleep(3000);
            PasswordTextField.SendKeys(password);
        }
        public Google_Page goToGoogle_Page()
        {
            System.Threading.Thread.Sleep(1000);
            Next_Button.Click();
            System.Threading.Thread.Sleep(1000);
            wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(10));
            System.Threading.Thread.Sleep(1000);
            _browserDriver.Navigate().GoToUrl("https://www.google.com/");
            return new Google_Page(_browserDriver);
        }

    }
}
