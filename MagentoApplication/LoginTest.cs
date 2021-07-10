using AutomationWrapper.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace MagentoApplication
{
    public class LoginTest : WebDriverWrapper
    {
        [Test]
        public void ValidCredentialTest()
        {
            System.Console.WriteLine(driver.Title);
        }
    }
}
