using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Core.Extensions
{
    public static class DriverExtension
    {
        public static IWebElement GetElement(this IWebDriver driver, By locator, int timeoutInSeconds=20)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return element;
            }
            catch (WebDriverTimeoutException)
            {

                throw new WebDriverTimeoutException(
                 $"Element with locator '{locator}' not visible within '{timeoutInSeconds}' seconds.");
            }
            
        }
    }
}
