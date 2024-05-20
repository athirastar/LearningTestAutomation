using OpenQA.Selenium;
using SampleTestFramework.DriverSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestFramework.Pages
{
    internal class CartPage : BasePage
    {
        
        public CartPage(DriverInitializer initializer) : base(initializer)
        {
            
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
            CheckoutButton.Click();
       }
    }
}