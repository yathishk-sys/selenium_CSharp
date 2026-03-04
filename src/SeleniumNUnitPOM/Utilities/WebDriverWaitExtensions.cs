using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNUnitPOM.Utilities;

public static class WebDriverWaitExtensions
{
    public static IWebElement WaitForVisible(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(d =>
        {
            var element = d.FindElement(locator);
            return element.Displayed ? element : null;
        }) ?? throw new WebDriverTimeoutException($"Element not visible: {locator}");
    }
}
