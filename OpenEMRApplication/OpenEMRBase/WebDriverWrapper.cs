using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRBase
{
    public class WebDriverWrapper
    {
        protected IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://demo.openemr.io/b/openemr/index.php";
        }

        [TearDown]
        public void End()
        {
            //screenshot
            driver.Quit();
        }
       
    }
}
