using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.Page;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Pages.qaPractice;
public class HomePage : BasePage
{
    private readonly By _TextInputButton = By.XPath("//a[normalize-space()='Text input']");
    private readonly By _winterDressViewProductLink = By.XPath("//a[normalize-space()='View Product'][1]");
    // private readonly By _singleUIElement = By.XPath("//span[normalize-space()='Single UI Elements']");

    public HomePage(IWebDriver driver) : base(driver)
    {
        navigateTo();
        WaitForElement(_TextInputButton);
    }

    public void navigateTo()
    {
        Driver.Navigate().GoToUrl("https://www.qa-practice.com/");
        ExtentReportManager.LogInfo("Navigated to QA Practice homepage.");
    }

    public void clickTextInputButton()
    {
        try
        {
            Utils.ClickElement(Driver, _TextInputButton);
            ExtentReportManager.LogPass("Clicked on Text Input button successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click on Text Input button."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click on Text Input button.", ex);
        }       
    }
    
}