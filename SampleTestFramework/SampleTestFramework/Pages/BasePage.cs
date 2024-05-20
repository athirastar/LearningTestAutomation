using OpenQA.Selenium;
using SampleTestFramework.DriverSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver _browserDriver;

        public BasePage(DriverInitializer _driverInitializer)
        {
            _browserDriver = _driverInitializer.driver;
        }
    }
}
