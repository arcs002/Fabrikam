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
using System.IO;

namespace FabrikamFiber.Web.PureSeleniumTests
{
    [TestClass]
    public class SeleniumTests
    {
        private RemoteWebDriver driver;
        private string baseURL = "http://vm06-webapp:8080";
        private string browser = string.Empty;
        private bool acceptNextAlert = true;

        public TestContext TestContext
        {
            get;
            set;
        }

        [TestInitialize]
        public void SetupTest()
        {
            // https://blogs.msdn.microsoft.com/devops/2016/01/27/getting-started-with-selenium-testing-in-a-continuous-integration-pipeline-with-visual-studio/
            // https://almvm.azurewebsites.net/labs/vsts/selenium/
            // https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2017

            //Set the browswer from a build
            //browser = this.TestContext.Properties["browser"] != null ? this.TestContext.Properties["browser"].ToString() : "chrome";
            //switch (browser)
            //{
            //    case "firefox":
            //        driver = new FirefoxDriver();
            //        break;
            //    case "chrome":
            //        driver = new ChromeDriver();
            //        break;
            //    case "ie":
            //        driver = new InternetExplorerDriver();
            //        break;
            //    default:
            //        driver = new ChromeDriver();
            //        break;
            //}

            if (this.TestContext.Properties["Url"] != null) //Set URL from a build
            {
                this.baseURL = this.TestContext.Properties["Url"].ToString();
            }
            else
            {
                this.baseURL = "http://vm06-webapp:8080/"; //default URL just to get started with
            }
        }

        [TestCleanup]
        public void CleanupTest()
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
        }

        #region Firefox
        [TestMethod]
        [Priority(0)]
        [TestCategory("Firefox")]
        public void Selenium_CreateNewCustomerRecordFireFox()
        {
            //instalar o driver geckodriver e adicionar no path da maquina
            //https://github.com/mozilla/geckodriver/releases

            this.driver = new FirefoxDriver();
            Selenium_CreateNewCustomerRecord();
            TakeScreenshot(nameof(Selenium_CreateNewCustomerRecordFireFox));
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("Firefox")]
        public void Selenium_VerifyDashboardPageFireFox()
        {
            this.driver = new FirefoxDriver();
            Selenium_VerifyDashboardPage();
            TakeScreenshot(nameof(Selenium_VerifyDashboardPageFireFox));
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("Firefox")]
        public void Selenium_VerifyTicketsPageFireFox()
        {
            this.driver = new FirefoxDriver();
            Selenium_VerifyTicketsPage();
            TakeScreenshot(nameof(Selenium_VerifyTicketsPageFireFox));
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
            TakeScreenshot(nameof(Selenium_CreateNewCustomerRecordChrome));
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("Chrome")]
        public void Selenium_VerifyDashboardPageChrome()
        {
            this.driver = new ChromeDriver();
            Selenium_VerifyDashboardPage();
            TakeScreenshot(nameof(Selenium_VerifyDashboardPageChrome));
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("Chrome")]
        public void Selenium_VerifyTicketsPageChrome()
        {
            this.driver = new ChromeDriver();
            Selenium_VerifyTicketsPage();
            TakeScreenshot(nameof(Selenium_VerifyTicketsPageChrome));
        }

        #endregion

        #region IE

        [TestMethod]
        [Priority(0)]
        [TestCategory("InternetExplorer")]
        [Ignore]
        public void Selenium_CreateNewCustomerRecordIE()
        {
            this.driver = new InternetExplorerDriver();
            Selenium_CreateNewCustomerRecord();
            TakeScreenshot(nameof(Selenium_CreateNewCustomerRecordIE));
        }
        
        [TestMethod]
        [Priority(0)]
        [TestCategory("InternetExplorer")]
        [Ignore]
        public void Selenium_VerifyDashboardPageIE()
        {
            this.driver = new InternetExplorerDriver();
            Selenium_VerifyDashboardPage();
            TakeScreenshot(nameof(Selenium_VerifyDashboardPageIE));
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("InternetExplorer")]
        [Ignore]
        public void Selenium_VerifyTicketsPageIE()
        {
            this.driver = new InternetExplorerDriver();
            Selenium_VerifyTicketsPage();
            TakeScreenshot(nameof(Selenium_VerifyTicketsPageIE));
        }

        #endregion

        public void TakeScreenshot(string fileName)
        {
            //if ((this.TestContext.CurrentTestOutcome == UnitTestOutcome.Error) || (this.TestContext.CurrentTestOutcome == UnitTestOutcome.Failed))
            //{
                ITakesScreenshot ssdriver = this.driver as ITakesScreenshot;
                Screenshot screenshot = ssdriver.GetScreenshot();

                string path = Directory.GetCurrentDirectory() + "\\" + fileName + ".png";

                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);

                this.TestContext.AddResultFile(path);
            //}
        }

        private void Selenium_CreateNewCustomerRecord()
        {

            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
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