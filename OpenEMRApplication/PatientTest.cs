using NUnit.Framework;
using OpenEMRApplication.OpenEMRBase;
using OpenEMRApplication.OpenEMRPages;
using OpenEMRApplication.OpenEMRUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace OpenEMRApplication
{
    class PatientTest : WebDriverWrapper
    {
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "AddPatientData")]
        public void AddPatientTest(string username,string password,string language,string firstName,String lastName,string dob,string gender,string expectedValue)
        {
            LoginPage.EnterUsername(driver, username);
            LoginPage.EnterPassword(driver, password);
            LoginPage.SelectLanguageByText(driver, language);
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
