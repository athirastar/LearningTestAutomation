using OpenQA.Selenium;
using SampleTestFramework.DriverSetup;
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
        public InventoryPage(DriverInitializer initializer) : base(initializer)
        {
            
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
        private string _addToCartButtonLocator = "(//button[@class='btn btn_primary btn_small btn_inventory '])[1]";

        private IWebElement AddToCartButton => _browserDriver.FindElement(By.XPath(_addToCartButtonLocator));

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetInventoryItemPrice() => InventoryItemPrice.Text;


        public void ClickOnAddToCartButton() //ToDo
        {
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