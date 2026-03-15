using OpenQA.Selenium;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Pages.AutomationExercise.com;

public class ProductPage : BasePage
{
    private readonly By _productName = By.XPath("//h2[normalize-space()='Winter Top']");
    private readonly By _addToCartButton = By.XPath("//button[normalize-space()='Add to cart']");
    private readonly By _viewCartButton = By.XPath("//a[normalize-space()='View Cart']");

    public ProductPage(IWebDriver driver) : base(driver)
    {
        WaitForElement(_productName);
    }

    // public string ProductName => WaitForElement(_productName).Text;

    public void ClickAddToCart()
    {
        try
        {
            Utils.ScrollToElement(Driver, _addToCartButton);
            Utils.ClickElement(Driver, _addToCartButton);
            ExtentReportManager.LogPass("Clicked on Add to Cart button successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click Add to Cart button."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click Add to Cart button.", ex);
        }
    }

    public void ClickViewCart()
    {
        try
        {
            Utils.WaitForElementPresence(Driver, _viewCartButton);
            Utils.ClickElement(Driver, _viewCartButton);
            ExtentReportManager.LogPass("Clicked on View Cart button successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click View Cart button."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click View Cart button.", ex);
        }
    }
}