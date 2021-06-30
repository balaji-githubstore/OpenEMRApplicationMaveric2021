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

        public static object[] InvalidCredentialData()
        {
            object[] temp1 = new object[4];
            temp1[0] = "Peter";
            temp1[1] = "Peter123";
            temp1[2] = "English (Indian)";
            temp1[3] = "Invalid username or password";

            object[] temp2 = new object[4];
            temp2[0] = "King";
            temp2[1] = "King123";
            temp2[2] = "Dutch";
            temp2[3] = "Invalid username or password";

            object[] main = new object[2];
            main[0] = temp1;
            main[1] = temp2;

            return main;
        }


        [Test]
        [TestCaseSource("InvalidCredentialData")]
        public void InvalidCredentialTest(string username, string password, string language, string expectedValue)
        {
            LoginPage.EnterUsername(driver, username);
            LoginPage.EnterPassword(driver, password);
            LoginPage.SelectLanguageByText(driver, language);
            LoginPage.ClickOnLogin(driver);

            string actualValue = LoginPage.GetErrorMessage(driver);
            Assert.AreEqual(expectedValue, actualValue);       
        }

    }
}