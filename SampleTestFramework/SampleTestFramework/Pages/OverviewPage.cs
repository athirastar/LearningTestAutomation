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
    internal class OverviewPage : BasePage
    {
        WebDriverWait _wait;
        //IWebDriver _browserDriver;
        public OverviewPage(DriverInitializer initializer) : base(initializer)
        {
            //_browserDriver = initializer.driver;
            _wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(5));
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
            _wait.Until(ExpectedConditions.ElementToBeClickable(FinishButtonInOverviewPage));
            FinishButtonInOverviewPage.Click();
        }

    }
}
