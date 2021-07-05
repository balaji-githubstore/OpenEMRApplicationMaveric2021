using NUnit.Framework;
using OpenEMRApplication.OpenEMRBase;
using OpenEMRApplication.OpenEMRPages;
using OpenEMRApplication.OpenEMRUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OpenEMRApplication
{
    class PatientTest : WebDriverWrapper
    {
        //data will be taken from TestCaseSourceUtils hardcoded data in C# file
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "AddPatientData")]
        public void AddPatientTest(string username,string password,string language,string firstName,String lastName,string dob,string gender,string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.ClickOnLogin();

            //DashboardPage
            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.MouseHoverOnPatientClients();

            //DashboardPage
            dashboard.ClickOnPatients();

            //PatientFinderPage
            driver.SwitchTo().Frame("fin");
            //PatientFinderPage
            driver.FindElement(By.Id("create_patient_btn1")).Click();
            //PatientFinderPage
            driver.SwitchTo().DefaultContent();

            //SearchOrAddPatientPage
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='pat']")));
            //SearchOrAddPatientPage
            driver.FindElement(By.Id("form_fname")).SendKeys(firstName);
            //SearchOrAddPatientPage
            driver.FindElement(By.Id("form_lname")).SendKeys(lastName);
            //SearchOrAddPatientPage
            driver.FindElement(By.Id("form_DOB")).SendKeys(dob);
            //SearchOrAddPatientPage
            SelectElement selectGender = new SelectElement(driver.FindElement(By.Id("form_sex")));
            selectGender.SelectByText(gender);
            //SearchOrAddPatientPage
            driver.FindElement(By.Id("create")).Click();
            //SearchOrAddPatientPage
            driver.SwitchTo().DefaultContent();

            //SearchOrAddPatientPage
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='modalframe']")));
            //SearchOrAddPatientPage
            driver.FindElement(By.CssSelector("input[value='Confirm Create New Patient']")).Click();
            //SearchOrAddPatientPage
            driver.SwitchTo().DefaultContent();

            //ignore nosuchalertexception
            //polling time --> 1s
            // timeout - 50s

            //SearchOrAddPatientPage
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));
            wait.Message = "No alert present for 50s with 1s polling time - add patient alert";

            string alertText= wait.Until(x => x.SwitchTo().Alert()).Text;
            Console.WriteLine(alertText);

            wait.Until(x => x.SwitchTo().Alert()).Accept();

            //SearchOrAddPatientPage
            if (driver.FindElements(By.XPath("//div[@class='closeDlgIframe']")).Count>0)
            {
                driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();
            }

            //PatientDashboardPage
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='pat']")));
            string actualValue= driver.FindElement(By.XPath("//h2[contains(normalize-space(),'Record Dashboard')]")).Text;
            driver.SwitchTo().DefaultContent();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void DeletePatientTest()
        {
            
        }
    }
}





