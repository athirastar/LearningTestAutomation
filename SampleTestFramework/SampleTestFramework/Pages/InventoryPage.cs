using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SampleTestFramework.DriverSetup;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestFramework.Pages
{
    public class InventoryPage : BasePage
    {
        WebDriverWait _wait;
        public InventoryPage(DriverInitializer initializer) : base(initializer)
        {
            _wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// 
        /// </summary>
        private string _itemsListLocator = "//div[@data-test ='inventory-item-name']";

        private ReadOnlyCollection<IWebElement> ItemsList => _browserDriver.FindElements(By.XPath(_itemsListLocator));


        /// <summary>
        /// 
        /// </summary>
        private string _inventoryItemPriceLocator = "//div[@data-test ='inventory-item-price']";

        private IWebElement InventoryItemPrice => _browserDriver.FindElement(By.XPath(_inventoryItemPriceLocator));


        /// <summary>
        /// 
        /// </summary>
        private string _addToCartButtonLocator = "//button[@id='add-to-cart']";

        private IWebElement AddToCartButton => _browserDriver.FindElement(By.XPath(_addToCartButtonLocator));

        /// <summary>
        /// Get inventory item price.
        /// </summary>
        /// <returns>price</returns>
        public string GetInventoryItemPrice() => InventoryItemPrice.Text;


        public void ClickOnAddToCartButton() //ToDo
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(AddToCartButton));
            AddToCartButton.Click();
        }

        public void SelectAnyItem(string itemName)  //ToDo
        {
            foreach(IWebElement item in ItemsList)
            {
                if (item.Text.Contains(itemName))
                {
                    item.Click();
                    break;
                }
            }
        }
    }
}