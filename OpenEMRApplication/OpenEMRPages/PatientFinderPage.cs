using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRPages
{
    class PatientFinderPage
    {
        private string finFrameLocator = "fin";

        private IWebDriver driver;
        public PatientFinderPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToFinFrame()
        {
            driver.SwitchTo().Frame(finFrameLocator);
        }
    }
}
