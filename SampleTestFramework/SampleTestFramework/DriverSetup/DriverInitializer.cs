
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SampleTestFramework.DriverSetup
{
    public class DriverInitializer
    {
        public IWebDriver driver { get; set; }
        public DriverInitializer()
        {
            // Web driver manager
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }
    }
}