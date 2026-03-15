using OpenQA.Selenium;
using SeleniumNUnitPOM.Drivers;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Tests;

public abstract class BaseTest
{
    protected IWebDriver Driver = null!;

    [OneTimeSetUp]
    public void SetUp()
    {
        ExtentReportManager.InitializeReport();
        var headless = Environment.GetEnvironmentVariable("HEADLESS")?.Equals("true", StringComparison.OrdinalIgnoreCase) == false;
        Driver = DriverFactory.CreateChromeDriver(headless);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
        ExtentReportManager.FlushReport();
    }
}
