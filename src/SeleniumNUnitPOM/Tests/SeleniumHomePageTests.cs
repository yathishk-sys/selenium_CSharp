using SeleniumNUnitPOM.Pages;

namespace SeleniumNUnitPOM.Tests;

[TestFixture]
public class SeleniumHomePageTests : TestBase
{
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
    }
}
