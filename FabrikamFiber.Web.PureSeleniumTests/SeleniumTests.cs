﻿//using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using OpenQA.Selenium.Remote;

namespace FabrikamFiber.Web.PureSeleniumTests
{
    [TestClass]
    public class SeleniumTests
    {
        //private IWebDriver driver;
        private RemoteWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        public TestContext TestContext
        {
            get;
            set;
        }

        [TestInitialize]
        public void SetupTest()
        {
            //baseURL = this.TestContext.Properties["webAppUrl"].ToString();
            //baseURL = "http://localhost/FabrikamFiber";
            //baseURL = "http://dtcvdapp-01:9090";
            baseURL = "http://vm06-webapp1:8080";

            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {   
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        #region Firefox
        [TestMethod]
        [Priority(0)]
        [TestCategory("Firefox")]
        public void Selenium_CreateNewCustomerRecordFireFox()
        {
            this.driver = new FirefoxDriver();
            Selenium_CreateNewCustomerRecord();
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("Firefox")]
        public void Selenium_VerifyDashboardPageFireFox()
        {
            this.driver = new FirefoxDriver();
            Selenium_VerifyDashboardPage();
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("Firefox")]
        public void Selenium_VerifyTicketsPageFireFox()
        {
            this.driver = new FirefoxDriver();
            Selenium_VerifyTicketsPage();
        }

        #endregion

        #region Chrome
        [TestMethod]
        [Priority(0)]
        [TestCategory("Chrome")]
        public void Selenium_CreateNewCustomerRecordChrome()
        {
            this.driver = new ChromeDriver();
            Selenium_CreateNewCustomerRecord();
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("Chrome")]
        public void Selenium_VerifyDashboardPageChrome()
        {
            this.driver = new ChromeDriver();
            Selenium_VerifyDashboardPage();
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("Chrome")]
        public void Selenium_VerifyTicketsPageChrome()
        {
            this.driver = new ChromeDriver();
            Selenium_VerifyTicketsPage();
        }

        #endregion

        #region IE

        [TestMethod]
        [Priority(0)]
        [Ignore]
        [TestCategory("InternetExplorer")]
        public void Selenium_CreateNewCustomerRecordIE()
        {
            this.driver = new InternetExplorerDriver();
            Selenium_CreateNewCustomerRecord();
        }
        
        [TestMethod]
        [Priority(0)]
        [Ignore]
        [TestCategory("InternetExplorer")]
        public void Selenium_VerifyDashboardPageIE()
        {
            this.driver = new InternetExplorerDriver();
            Selenium_VerifyDashboardPage();
        }

        [TestMethod]
        [Priority(0)]
        [Ignore]
        [TestCategory("InternetExplorer")]
        public void Selenium_VerifyTicketsPageIE()
        {
            this.driver = new InternetExplorerDriver();
            Selenium_VerifyTicketsPage();
        }

        #endregion

        private void Selenium_CreateNewCustomerRecord()
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(baseURL);

            driver.FindElement(By.CssSelector("a[href*='/Customers']")).Click();
            //driver.FindElement(By.LinkText("Customers")).Click();

            driver.FindElement(By.CssSelector("a[href*='/Customers/Create']")).Click();
            //driver.FindElement(By.LinkText("Create New")).Click();

            driver.FindElement(By.Id("FirstName")).Clear();
            driver.FindElement(By.Id("FirstName")).SendKeys("Mary");

            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys("Poppins");

            driver.FindElement(By.Id("Address_Street")).Clear();
            driver.FindElement(By.Id("Address_Street")).SendKeys("1234 Disneyland");

            driver.FindElement(By.Id("Address_City")).Clear();
            driver.FindElement(By.Id("Address_City")).SendKeys("Disney");

            driver.FindElement(By.Id("Address_State")).Clear();
            driver.FindElement(By.Id("Address_State")).SendKeys("LA");

            driver.FindElement(By.Id("Address_Zip")).Clear();
            driver.FindElement(By.Id("Address_Zip")).SendKeys("12345");

            driver.FindElement(By.CssSelector("input.glossyBox")).Click();
        }

        private void Selenium_VerifyDashboardPage()
        {
            driver.Navigate().GoToUrl(baseURL);
            String pageTitle = driver.FindElement(By.CssSelector("#content h1")).Text.Trim();
            Assert.AreEqual(pageTitle, "Dashboard");
        }

        private void Selenium_VerifyTicketsPage()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.CssSelector("a[href*='/ServiceTickets']")).Click();
            String pageTitle = driver.FindElement(By.CssSelector("#content h1")).Text.Trim();
            Assert.AreEqual("Service Tickets", pageTitle);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

    }
}
