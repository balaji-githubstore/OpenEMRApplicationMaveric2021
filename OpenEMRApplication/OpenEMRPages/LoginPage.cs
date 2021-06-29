using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRPages
{
    class LoginPage
    {
        private static By usernameLocator = By.Id("authUser");
        private static By passwordLocator = By.Id("clearPass");
        private static By languageLocator = By.Name("languageChoice");
        private static By loginLocator = By.CssSelector("[type='submit']");
        private static By errorLocator=By.XPath("//div[contains(text(),'Invalid')]");


        public static void EnterUsername(IWebDriver driver,string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
        }

        public static void EnterPassword(IWebDriver driver,string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }

        public static void SelectLanguageByText(IWebDriver driver,string language)
        {
            SelectElement select = new SelectElement(driver.FindElement(languageLocator));
            select.SelectByText(language);
        }

        public static void ClickOnLogin(IWebDriver driver)
        {
            driver.FindElement(loginLocator).Click();
        }

        public static string GetErrorMessage(IWebDriver driver)
        {
            return driver.FindElement(errorLocator).Text.Trim();
        }
    }
}
