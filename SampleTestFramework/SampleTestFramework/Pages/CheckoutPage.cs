using OpenQA.Selenium;
using SampleTestFramework.DriverSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleTestFramework.Pages
{
    public class CheckoutPage
    {
        IWebDriver _browserDriver;
        public CheckoutPage(DriverInitializer initializer)
        {
            _browserDriver = initializer.driver;
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


        public void EnterFirstNameAndLastNameAndPostalCode()
        {
            Thread.Sleep(5000);
            FirstNameFieldInCheckoutPage.SendKeys("abcd"); //ToDo
            LastNameFieldInCheckoutPage.SendKeys("secredd"); //ToDo
            PostalCodeFieldInCheckoutPage.SendKeys("33");
        }

        public void ClickOnContinueButtonFromCheckoutPage()
        {
            ContinueButtonInCheckoutPage.Click();
        }
    }
}
