using NUnit.Framework;
using OpenEMRApplication.OpenEMRBase;
using OpenEMRApplication.OpenEMRPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenEMRApplication
{
    public class LoginTest : WebDriverWrapper
    {
        [Test]
        [TestCase("admin","pass", "English (Indian)", "Flow Board")]
        [TestCase("accountant", "accountant", "English (Indian)", "Flow Board")]
        [TestCase("physician", "physician", "Danish", "Flow Board")]
        public void ValidCredentialTest(string username,string password,string language,string expectedValue)
        {
            LoginPage.EnterUsername(driver, username);
            LoginPage.EnterPassword(driver, password);
            LoginPage.SelectLanguageByText(driver, language);
            LoginPage.ClickOnLogin(driver);

            string actualValue = DashboardPage.GetFlowBoardText(driver);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void InvalidCredential()
        {
            LoginPage.EnterUsername(driver, "admin123");
            LoginPage.EnterPassword(driver, "pass");
            LoginPage.SelectLanguageByText(driver, "English (Indian)");
            LoginPage.ClickOnLogin(driver);

            string actualValue = LoginPage.GetErrorMessage(driver);
            Assert.AreEqual("Invalid username or password", actualValue);       
        }

    }
}