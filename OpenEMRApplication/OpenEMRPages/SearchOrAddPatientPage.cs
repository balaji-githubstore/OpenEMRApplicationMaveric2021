using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRPages
{
    class SearchOrAddPatientPage
    {
        private IWebDriver driver;
        public SearchOrAddPatientPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
