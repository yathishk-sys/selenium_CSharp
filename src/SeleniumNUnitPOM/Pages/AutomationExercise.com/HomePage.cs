using OpenQA.Selenium;
using SeleniumNUnitPOM.Reports;
using SeleniumNUnitPOM.Utilities;

namespace SeleniumNUnitPOM.Pages.AutomationExercise.com;

public class HomePage : BasePage
{
    private readonly By _loginLink = By.XPath("//a[normalize-space()='Signup / Login']");
    private readonly By _categoryText = By.XPath("//h2[normalize-space()='Category']");
    
    private readonly By _winterDressViewProductLink = By.XPath("(//p[text()='Winter Top']/following::a[text()='View Product'])[1]");

    public HomePage(IWebDriver driver) : base(driver)
    {
        NavigateTo();
        WaitForElement(_categoryText);
    }

    public void NavigateTo()
    {
        Driver.Navigate().GoToUrl("https://automationexercise.com/");
    }

    public string Title => Driver.Title;

    public void ClickLoginLink()
    {
        try
        {            
            Utils.ClickElement(Driver, _loginLink);
            ExtentReportManager.LogPass("Clicked on Login link successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click Login link."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click Login link.", ex);
        }
    }

    public void clickWinterDressViewProductLink()
    {
        try
        {    
            Utils.ScrollToElement(Driver, _winterDressViewProductLink);         
            Utils.ClickElement(Driver, _winterDressViewProductLink);
            ExtentReportManager.LogPass("Clicked on Winter Dress View Product link successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click Winter Dress View Product link."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click Winter Dress View Product link.", ex);
        }
    }



}