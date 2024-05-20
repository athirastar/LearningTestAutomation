using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SampleTestFramework.DriverSetup;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleTestFramework.Pages
{
    public class LoginPage : BasePage
    {
        WebDriverWait _wait;
        public LoginPage(DriverInitializer initializer) : base(initializer)
        {
            _wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(5));
        }

        #region

        /// <summary>
        /// 
        /// </summary>
        private string _usernameFieldLocator = "//input[@id='user-name']";

        private IWebElement UserNameField => _browserDriver.FindElement(By.XPath(_usernameFieldLocator));

        /// <summary>
        /// 
        /// </summary>
        private string _passwordFieldLocator = "//input[@id='password']";

        private IWebElement PasswordField => _browserDriver.FindElement(By.XPath(_passwordFieldLocator));

        /// <summary>
        /// 
        /// </summary>
        private string _loginButtonLocator = "//input[@id='login-button']";

        private IWebElement LoginButton => _browserDriver.FindElement(By.XPath(_loginButtonLocator));

        #endregion

        public void NavigateToSaucedemoLoginPage()
        {
            _browserDriver.Navigate().GoToUrl("https://www.saucedemo.com/"); //ToDo
            _browserDriver.Manage().Window.Maximize();
        }

        public void EnterUserNameAndPassword(string userName, string passWord)
        {
           _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_usernameFieldLocator)));
            UserNameField.SendKeys(userName);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_passwordFieldLocator)));
            PasswordField.SendKeys(passWord);
        }

        public void ClickOnLoginButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton));
            LoginButton.Click();
        }
    }
}