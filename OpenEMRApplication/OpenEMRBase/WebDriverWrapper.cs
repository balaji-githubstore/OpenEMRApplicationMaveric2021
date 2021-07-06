using NUnit.Framework;
using OpenEMRApplication.OpenEMRUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
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
            string browser= JsonUtils.GetValue(@"D:\B-Mine\Company\Company\Maveric 2021\OpenEMRApplication\OpenEMRApplication\TestData\data.json", "browser");

            browser = TestContext.Parameters.Get("browser", browser);

            switch(browser.ToLower())
            {
                case "ie":
                case "internetexplorer":
                    driver = new InternetExplorerDriver();
                    break;
                case "ff":
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
           
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
