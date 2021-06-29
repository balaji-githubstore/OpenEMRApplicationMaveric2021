using NUnit.Framework;
using OpenEMRApplication.OpenEMRBase;
using OpenEMRApplication.OpenEMRPages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication
{
    class PatientTest : WebDriverWrapper
    {
        [Test]
        public void AddPatientTest()
        {
            LoginPage.EnterUsername(driver, "admin");
            LoginPage.EnterPassword(driver, "pass");
            LoginPage.SelectLanguageByText(driver, "English (Indian)");
            LoginPage.ClickOnLogin(driver);
        }

        [Test]
        public void DeletePatientTest()
        {
            LoginPage.EnterUsername(driver, "admin");
            LoginPage.EnterPassword(driver, "pass");
            LoginPage.SelectLanguageByText(driver, "English (Indian)");
            LoginPage.ClickOnLogin(driver);
        }
    }
}
