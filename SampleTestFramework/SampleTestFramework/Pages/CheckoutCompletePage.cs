using OpenQA.Selenium;
using SampleTestFramework.DriverSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestFramework.Pages
{
    public class CheckoutCompletePage : BasePage 
    {
        // IWebDriver _browserDriver;
        public CheckoutCompletePage(DriverInitializer initializer) : base(initializer)
        {
           // _browserDriver = initializer.driver;
        }
    }
}
