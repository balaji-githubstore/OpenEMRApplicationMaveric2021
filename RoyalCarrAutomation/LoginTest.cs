using AutomationWrapper.Base;
using NUnit.Framework;

namespace RoyalCarrAutomation
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
