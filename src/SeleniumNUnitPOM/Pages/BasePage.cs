using OpenQA.Selenium;
using SeleniumNUnitPOM.Utilities;

namespace SeleniumNUnitPOM.Pages;

public abstract class BasePage(IWebDriver driver)
{
    protected IWebDriver Driver { get; } = driver;

    protected IWebElement WaitForElement(By locator, int timeoutInSeconds = 10)
        => Driver.WaitForVisible(locator, timeoutInSeconds);
}
