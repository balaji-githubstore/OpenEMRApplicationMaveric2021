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
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "AddPatientData")]
        public void AddPatientTest(string username,string password,string language,string firstName,String lastName,string dob,string gender,string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.ClickOnLogin();

            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//div[text()='Patient/Client']"))).Perform();
            driver.FindElement(By.XPath("//div[text()='Patients']")).Click();

            driver.SwitchTo().Frame("fin");
            driver.FindElement(By.Id("create_patient_btn1")).Click();
            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='pat']")));

            driver.FindElement(By.Id("form_fname")).SendKeys(firstName);
            driver.FindElement(By.Id("form_lname")).SendKeys(lastName);
            //2021-07-03
            driver.FindElement(By.Id("form_DOB")).SendKeys(dob);

            SelectElement selectGender = new SelectElement(driver.FindElement(By.Id("form_sex")));
            selectGender.SelectByText(gender);

            driver.FindElement(By.Id("create")).Click();
            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='modalframe']")));
            driver.FindElement(By.CssSelector("input[value='Confirm Create New Patient']")).Click();
            driver.SwitchTo().DefaultContent();

            //explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.AlertIsPresent()).Accept();




            if (driver.FindElements(By.XPath("//div[@class='closeDlgIframe']")).Count>0)
            {
                driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();
            }

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





