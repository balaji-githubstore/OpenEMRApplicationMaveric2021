using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenEMRApplication.OpenEMRUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AutomationWrapper.Base
{
    public class WebDriverWrapper
    {
        protected IWebDriver driver;

        public static string projectPath;
        public static ExtentReports extent;
        public static ExtentTest test;
        public static string screenShotPath;

        [OneTimeSetUp]
        public void Start()
        {
            if(extent==null)
            {
                projectPath = Assembly.GetCallingAssembly().CodeBase;
                projectPath = projectPath.Substring(0, projectPath.LastIndexOf("bin"));
                projectPath = new Uri(projectPath).LocalPath;

                extent = new ExtentReports();

                string reportPath = projectPath + @"Reports\";

                ExtentHtmlReporter reporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
        }

        [OneTimeTearDown]
        public void End()
        {
            extent.Flush();
        }

        [SetUp]
        public void StartBrowser()
        {
            string browser = JsonUtils.GetValue(projectPath+@"TestData\data.json", "browser");

            browser = TestContext.Parameters.Get("browser", browser);

            switch (browser.ToLower())
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
            driver.Url = JsonUtils.GetValue(projectPath + @"TestData\data.json", "url");


            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void EndBrowser()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;

            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                TakeScreenShot(testName);


                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Failed - Snapshot below:");
                test.AddScreenCaptureFromPath(screenShotPath, title: testName);
            }
            else if (status == TestStatus.Passed)
            {
                TakeScreenShot(testName);

                test.Log(Status.Pass, "Passed - Snapshot below:");
                test.AddScreenCaptureFromPath(screenShotPath, title: testName);
            }
            else if (status == TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Skipped - " + testName);
            }
            driver.Quit();
        }

        public void TakeScreenShot(string testName)
        {
            if (driver != null)
            {
                string name = DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
                screenShotPath = projectPath + @"\Reports\screenshot_" + testName + "_" + name + ".png";

                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot ss = ts.GetScreenshot();
                ss.SaveAsFile(screenShotPath);
            }
        }

    }
}
