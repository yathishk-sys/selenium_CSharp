using NUnit.Framework.Interfaces;
using SeleniumNUnitPOM.Pages;
using SeleniumNUnitPOM.Reports;
using SeleniumNUnitPOM.Utilities;

namespace SeleniumNUnitPOM.Tests;

[TestFixture]
public class SeleniumHomePageTests : TestBase
{
    [SetUp]
    public void TestSetUp()
    {
        ExtentReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
    }

    [Test]
    public void HomePage_ShouldLoad_WithExpectedTitleAndDownloadsLink()
    {
        var homePage = new SeleniumHomePage(Driver);

        homePage.NavigateTo();

        Assert.Multiple(() =>
        {
            Assert.That(homePage.Title, Does.Contain("Selenium"));
            Assert.That(homePage.IsDownloadsLinkVisible(), Is.True);
        });

        homePage.ClickDownloadsLink();

        var downloadsPage = new DownloadsPage(Driver);
        Assert.That(downloadsPage.Title, Does.Contain("Downloads"));
        downloadsPage.ClickOtherLanguageLink();
    }

    [TearDown]
    public void TestTearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshotPath = Utils.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
            ExtentReportManager.AttachScreenshot(screenshotPath);
        }
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            ExtentReportManager.LogPass("Test Passed Successfully");
        else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            ExtentReportManager.LogFail($"Test Failed: {TestContext.CurrentContext.Result.Message}");
        // ExtentReportManager.EndTest();
        ExtentReportManager.FlushReport();
    }
}
