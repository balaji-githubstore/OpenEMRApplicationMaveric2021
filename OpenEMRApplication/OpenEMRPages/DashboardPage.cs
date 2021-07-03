using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRPages
{  
    //all menu handling
    class DashboardPage
    {
        private By flowBoardLocator = By.XPath("//div[contains(text(),'Flow')]");
        private By patientClientLocator = By.XPath("//div[text()='Patient/Client']");
        private By patientLocator = By.XPath("//div[text()='Patients']");

        private IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetFlowBoardText()
        {
            return driver.FindElement(flowBoardLocator).Text;
        }
        public void ClickOnFlowBoard()
        {
            driver.FindElement(flowBoardLocator).Click();
        }
        public void MouseHoverOnPatientClients()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(patientClientLocator)).Perform();
        }

        public void ClickOnPatients()
        {
            driver.FindElement(patientLocator).Click();
        }
    }
}
