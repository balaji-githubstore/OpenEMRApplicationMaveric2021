using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRPages
{
    class PatientDashboardPage
    {
        private IWebDriver driver;
        public PatientDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
