using OpenQA.Selenium;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Pages;

public class DownloadsPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By otherLanguageLink = By.XPath("//a[normalize-space()='other languages exist']");

    public string Title => Driver.Title;

    public void ClickOtherLanguageLink()
    {
        try
        {
            WaitForElement(otherLanguageLink).Click();
            ExtentReportManager.LogPass("Clicked on Other Languages link successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click Other Languages link."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click Other Languages link.", ex);
        }
    }
}