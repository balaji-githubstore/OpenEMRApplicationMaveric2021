using AventStack.ExtentReports;
using NUnit.Framework;
using OpenEMRApplication.OpenEMRBase;
using OpenEMRApplication.OpenEMRPages;
using OpenEMRApplication.OpenEMRUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenEMRApplication
{
    public class LoginTest : WebDriverWrapper
    {
        [Test]
        //[TestCase("admin","pass", "English (Indian)", "Flow Board")]
        //[TestCase("accountant", "accountant", "English (Indian)", "Flow Board")]
        //[TestCase("physician", "physician", "Danish", "Flow Board")]
        //data will be taken from json
        [TestCaseSource(typeof(TestCaseSourceUtils), "ValidCredentialData")]
        public void ValidCredentialTest(string username,string password,string language,string expectedValue)
        {
            var login = new LoginPage(driver);
            login.EnterUsername( username);
            test.Log(Status.Info, "Username entered successfully as "+username);
            login.EnterPassword( password);
            login.SelectLanguageByText( language);
            login.ClickOnLogin();
            var dashboard = new DashboardPage(driver);
            var actualValue = dashboard.GetFlowBoardText();

            test.Log(Status.Info, "actual value " + actualValue);

            Assert.AreEqual(expectedValue, actualValue);

        }
        

        [Test]
        //data will be taken from excel
        [TestCaseSource(typeof(TestCaseSourceUtils),"InvalidCredentialData")]
        public void InvalidCredentialTest(string username, string password, string language, string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText( language);
            login.ClickOnLogin();

            string actualValue = login.GetErrorMessage();
            Assert.AreEqual(expectedValue, actualValue);       
        }

    }
}