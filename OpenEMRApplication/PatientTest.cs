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
           
        }

        [Test]
        public void DeletePatientTest()
        {
         
        }
    }
}
