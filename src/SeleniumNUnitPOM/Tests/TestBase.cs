using OpenQA.Selenium;
using SeleniumNUnitPOM.Drivers;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Tests;

public abstract class TestBase
{
    protected IWebDriver Driver = null!;

    [SetUp]
    public void SetUp()
    {
        ExtentReportManager.InitializeReport();
        var headless = Environment.GetEnvironmentVariable("HEADLESS")?.Equals("true", StringComparison.OrdinalIgnoreCase) == true;
        Driver = DriverFactory.CreateChromeDriver(headless);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
        ExtentReportManager.FlushReport();
    }
}
