using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TableElement_Extension
{
    public static class Utils
    {
        public static T Wait<T>(this IWebDriver driver, Func<IWebDriver, T> condition)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            return wait.Until(condition);
        }

        public static void WaitForElement(this IWebDriver driver, By locator)
        {
            driver.Wait(x =>
            {
                try
                {
                    return x.FindElement(locator).Displayed;
                }
                catch (Exception)
                {
                    // ignored
                }
                return false;
            });
        }
    }
}
