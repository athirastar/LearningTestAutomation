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
    public class CheckoutPage : BasePage
    {
        WebDriverWait _wait;
        public CheckoutPage(DriverInitializer initializer) : base(initializer)
        {
            _wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// 
        /// </summary>
        private string _firstNameFieldInCheckoutPageLocator = "//input[@id='first-name']";

        private IWebElement FirstNameFieldInCheckoutPage => _browserDriver.FindElement(By.XPath(_firstNameFieldInCheckoutPageLocator));

        private string _lastNameFieldInCheckoutPageLocator = "//input[@id='last-name']";

        private IWebElement LastNameFieldInCheckoutPage => _browserDriver.FindElement(By.XPath(_lastNameFieldInCheckoutPageLocator));

        private string _postalCodeFieldInCheckoutPageLocator = "//input[@id='postal-code']";
        private IWebElement PostalCodeFieldInCheckoutPage => _browserDriver.FindElement(By.XPath(_postalCodeFieldInCheckoutPageLocator));

        private string _continueButtonInCheckoutPageLocator = "//input[@id='continue']";
        private IWebElement ContinueButtonInCheckoutPage => _browserDriver.FindElement(By.XPath(_continueButtonInCheckoutPageLocator));


        public void EnterFirstNameAndLastNameAndPostalCode(string firstName, string lastName, string postalCode)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_firstNameFieldInCheckoutPageLocator)));
            FirstNameFieldInCheckoutPage.SendKeys(firstName);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_lastNameFieldInCheckoutPageLocator)));
            LastNameFieldInCheckoutPage.SendKeys(lastName);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_postalCodeFieldInCheckoutPageLocator)));
            PostalCodeFieldInCheckoutPage.SendKeys(postalCode);
        }

        public void ClickOnContinueButtonFromCheckoutPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(ContinueButtonInCheckoutPage));
            ContinueButtonInCheckoutPage.Click();
        }
    }
}
