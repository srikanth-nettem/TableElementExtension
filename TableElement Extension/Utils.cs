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

        public static void WaitForPageLoad(IWebDriver driver)
        {
            driver.Wait(x =>
            {
                try
                {
                    return x.FindElement(By.TagName("table")).Displayed;
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
