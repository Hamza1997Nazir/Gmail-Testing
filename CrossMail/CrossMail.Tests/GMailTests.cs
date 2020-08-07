using com.sun.tools.javac.util;
using java.awt;
using java.awt.@event;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System;
using Xunit;

namespace CrossMail.Test
{
    public class GMailTests: IDisposable
    {
        IWebDriver _browserDriver;
        IConfiguration _config;

        public GMailTests()
        {
            _browserDriver = new ChromeDriver("./");
            _config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            //-------------------------------------Steps for logging into Google----------------------------------------------------


            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Navigate().GoToUrl("https://stackoverflow.com/");    //going to stack overflow

            _browserDriver.FindElement(By.XPath("//*[text() ='Log in']")).Click();  // pressing log in button
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.XPath("//button[@data-provider ='google']")).Click();    // pressing log in with google    
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.Id("identifierId")).SendKeys("tt5515154@gmail.com");   //entering email
            System.Threading.Thread.Sleep(2000);

            _browserDriver.FindElement(By.Id("identifierNext")).Click();    //pressing Next
            System.Threading.Thread.Sleep(2000);

            _browserDriver.FindElement(By.XPath("//input[@name='password']")).SendKeys("testtester4040");   //entering password
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.Id("passwordNext")).Click();  //pressing next
            System.Threading.Thread.Sleep(1000);

            _browserDriver.Navigate().GoToUrl("https://www.google.com/");   //going to google after login
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.XPath("//*[text() ='Gmail']")).Click();  // pressing Gmail button 
            System.Threading.Thread.Sleep(1000);

        }

        public void Dispose()
        {
            _browserDriver.Quit();
        }

        [Fact]
        public void Should_Send_Email()
        {
            //-----------------------------------------Now we have logged into Google------------------------------------------------------------------


            _browserDriver.FindElement(By.XPath("//div[@class ='T-I T-I-KE L3']")).Click();  // pressing Compose button 
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.XPath("//textarea[@name ='to']")).SendKeys("tt5515154@gmail.com");  // Reaching the 'to' address 
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.XPath("//input[@name ='subjectbox']")).SendKeys("An Automated Message");  // Subject
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.XPath("//*[@aria-label='More options']")).Click();  // Clicking three dots - More Options
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.XPath("//*[text() ='Label']")).Click(); // clicking the Label option
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.XPath("//div[@class='J-LC']")).Click(); // 'Social' checkbox checked
            System.Threading.Thread.Sleep(1000);

            _browserDriver.FindElement(By.XPath("//div[@class ='Am Al editable LW-avf tS-tW']")).SendKeys("Finally!!!\n I have done it!\n Regards,\n Hamza" + Keys.Control + Keys.Enter);  // Body
            System.Threading.Thread.Sleep(1000);

            //-------------------------------------------------------Email Sent in with Social Label---------------------------------------------------------

        }

        [Fact]
        public void VerifyEmail()
        {

            _browserDriver.FindElement(By.XPath("//*[text() = 'Social']")).Click(); // Opening Social Tab
            System.Threading.Thread.Sleep(1000);


        }

    }
}
