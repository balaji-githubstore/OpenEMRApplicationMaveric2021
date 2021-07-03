using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRPages
{
    class LoginPage
    {
        private By usernameLocator = By.Id("authUser");
        private By passwordLocator = By.Id("clearPass");
        private By languageLocator = By.Name("languageChoice");
        private By loginLocator = By.CssSelector("[type='submit']");
        private By errorLocator=By.XPath("//div[contains(text(),'Invalid')]");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
       
        public void EnterUsername(string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }

        public void SelectLanguageByText(string language)
        {
            SelectElement select = new SelectElement(driver.FindElement(languageLocator));
            select.SelectByText(language);
        }

        public void ClickOnLogin()
        {
            driver.FindElement(loginLocator).Click();
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(errorLocator).Text.Trim();
        }
    }
}
