using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitPOM.Drivers;

public static class DriverFactory
{
    public static IWebDriver CreateChromeDriver(bool headless = false)
    {
        var options = new ChromeOptions();

        if (headless)
        {
            options.AddArgument("--headless=new");
        }

        options.AddArgument("--window-size=1920,1080");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--no-sandbox");

        var driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        return driver;
    }
}
