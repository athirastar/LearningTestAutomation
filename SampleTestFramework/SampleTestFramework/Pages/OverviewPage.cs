using OpenQA.Selenium;
using SampleTestFramework.DriverSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestFramework.Pages
{
    internal class OverviewPage : BasePage
    {
        //IWebDriver _browserDriver;
        public OverviewPage(DriverInitializer initializer) : base(initializer)
        {
            //_browserDriver = initializer.driver;
        }


        /// <summary>
        /// 
        /// </summary>
        private string _itemNameFieldInOverviewPageLocator = "//div[@data-test='inventory-item-name']";

        private IWebElement ItemNameFieldInOverviewPage => _browserDriver.FindElement(By.XPath(_itemNameFieldInOverviewPageLocator));

        /// <summary>
        /// 
        /// </summary>
        private string _finishButtonInOverviewPageLocator = "//button[@id='finish']";

        private IWebElement FinishButtonInOverviewPage => _browserDriver.FindElement(By.XPath(_finishButtonInOverviewPageLocator));

        /// <summary>
        /// 
        /// </summary>
        private string _priceFieldInOverviewPageLocator = "//div[@data-test='inventory-item-price']"; //ToDo

        private IWebElement PriceFieldInOverviewPage => _browserDriver.FindElement(By.XPath(_priceFieldInOverviewPageLocator));

        public string GetInventoryItemPriceInOverviewPage() => PriceFieldInOverviewPage.Text;

        public string GetInventoryItemNameInOverviewPage() => ItemNameFieldInOverviewPage.Text;

        public void ClickOnFinishButtonInOverviewPage()
        {
            FinishButtonInOverviewPage.Click();
        }

    }
}
