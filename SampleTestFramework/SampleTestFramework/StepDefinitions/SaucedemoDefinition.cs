using FluentAssertions;
using Newtonsoft.Json;
using SampleTestFramework.DriverSetup;
using SampleTestFramework.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SampleTestFramework.StepDefinitions
{
    [Binding]
    public class SaucedemoDefinition
    {
        DriverInitializer _driverInitializer;

        ScenarioContext _scenarioContext;
        LoginPage _loginPage;
        InventoryPage _inventoryPage;
        CartPage _cartPage;
        CheckoutPage _checkoutPage;
        CheckoutCompletePage _checkoutCompletePage;
        OverviewPage _overviewPage;

        Dictionary<string, string> _sauceDemoTestData;
        public SaucedemoDefinition(ScenarioContext _scenarioContext)
        {
            _driverInitializer = new DriverInitializer();

            _loginPage = new LoginPage(_driverInitializer);
            _inventoryPage = new InventoryPage(_driverInitializer);
            _cartPage = new CartPage(_driverInitializer);
            _checkoutPage = new CheckoutPage(_driverInitializer);
            _checkoutCompletePage = new CheckoutCompletePage(_driverInitializer);
            _overviewPage = new OverviewPage(_driverInitializer);

            this._scenarioContext = _scenarioContext;
            string jsonText = File.ReadAllText("C:\\Users\\athira_ap\\Source\\repos\\SampleTestFramework\\SampleTestFramework\\TestData\\SaucedemoTestData.json");
            _sauceDemoTestData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);
        }

        [Given(@"I am login to Saucedemo page")]
        public void GivenIAmLoginToSaucedemoPage()
        {
            _loginPage.NavigateToSaucedemoLoginPage();
        }

        [Given(@"I Enter the Demo credentials from login page")]
        public void GivenIEnterTheDemoCredentialsFromLoginPage()
        {
            _loginPage.EnterUserNameAndPassword(_sauceDemoTestData["UserNameForLogin"], _sauceDemoTestData["PasswordForLogin"]);
            _loginPage.ClickOnLoginButton();
        }

        [Given(@"I Select any item")]
        public void GivenISelectAnyItem()
        {
            _inventoryPage.SelectAnyItem(_sauceDemoTestData["ItemFromInventory"]);
        }


        [Given(@"Note the price from the inventroy page and add it to cart\.")]
        public void GivenNoteThePriceFromTheInventroyPageAndAddItToCart_()
        {
            _scenarioContext["ItemPrice"] =  _inventoryPage.GetInventoryItemPrice(); //ToDo
            _inventoryPage.ClickOnAddToCartButton();
        }

        [When(@"Navigate to cart page")]
        public void WhenNavigateToCartPage()
        {
            _cartPage.NavigateToCartPage();
        }

        [Then(@"verify same price as above noted displayed\.")]
        public void ThenVerifySamePriceAsAboveNotedDisplayed_()
        {
            _scenarioContext["ItemPrice"]
                .Should()
                .Be(_cartPage.GetItemPriceFromCartPage());
        }

        [When(@"Click on checkout")]
        public void WhenClickOnCheckout()
        {
            _cartPage.ClickOnCheckoutButtonFromCartPage();
        }

        [When(@"Enter the sample details")]
        public void WhenEnterTheSampleDetails()
        {
            _checkoutPage.EnterFirstNameAndLastNameAndPostalCode(_sauceDemoTestData["FirstName"], _sauceDemoTestData["LastName"], _sauceDemoTestData["PostalCode"]);
        }

        [When(@"Click continue")]
        public void WhenClickContinue()
        {
            _checkoutPage.ClickOnContinueButtonFromCheckoutPage();
        }

        [Then(@"Verify the Item and Price on chekout page\.")]
        public void ThenVerifyTheItemAndPriceOnChekoutPage_()
        {
            _scenarioContext["ItemPrice"]
               .Should()
               .Be(_overviewPage.GetInventoryItemPriceInOverviewPage());
        }

        [Then(@"Click finish\.")]
        public void ThenClickFinish_()
        {
            _overviewPage.ClickOnFinishButtonInOverviewPage();
        }

    }
}