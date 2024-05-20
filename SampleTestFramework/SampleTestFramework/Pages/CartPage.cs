using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SampleTestFramework.DriverSetup;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestFramework.Pages
{
    internal class CartPage : BasePage
    {
        WebDriverWait _wait;
        public CartPage(DriverInitializer initializer) : base(initializer)
        {
            _wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// 
        /// </summary>
        private string _itemPriceFromCartPageLocator = "//div[@data-test ='inventory-item-price']";

        private IWebElement ItemPriceFromCartPage => _browserDriver.FindElement(By.XPath(_itemPriceFromCartPageLocator));

        private string _checkoutButtonLocator = "//button[@id='checkout']";

        private IWebElement CheckoutButton => _browserDriver.FindElement(By.XPath(_checkoutButtonLocator));

        public void NavigateToCartPage()
        {
            _browserDriver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
        }

       public string GetItemPriceFromCartPage() => ItemPriceFromCartPage.Text;

       public void ClickOnCheckoutButtonFromCartPage()
       {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CheckoutButton));
            CheckoutButton.Click();
       }
    }
}