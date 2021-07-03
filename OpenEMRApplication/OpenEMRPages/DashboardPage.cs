using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRPages
{  
    //all menu handling
    class DashboardPage
    {
        private By flowBoardLocator = By.XPath("//div[contains(text(),'Flow')]");

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
    }
}
