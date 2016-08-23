using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FabrikamFiber.Web.SeleniumTest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    [DeploymentItem("chromedriver.exe")]
    public class CodedUITestFabrikamFiber
    {
        private String baseURL;
        private RemoteWebDriver driver;

        public CodedUITestFabrikamFiber()
        {
        }

        [TestMethod]
        public void ChromeCreateCustomer()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.

            driver = new ChromeDriver();
            baseURL = "http://vm06-webapp1:8080";
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            driver.FindElement(By.LinkText("Customers")).Click();

            driver.FindElement(By.LinkText("Create New")).Click();

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

            driver.Quit();

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            
        }

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
