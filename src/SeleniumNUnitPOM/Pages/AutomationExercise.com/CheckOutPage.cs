using OpenQA.Selenium;
using SeleniumNUnitPOM.Reports;
namespace SeleniumNUnitPOM.Pages.AutomationExercise.com;

public class CheckoutPage : BasePage
{
    private readonly By _reviewOrder = By.XPath("//h2[normalize-space()='Review Your Order']");
    private readonly By _placeOrderButton    = By.XPath("//a[@class='btn btn-default check_out']");

    public CheckoutPage(IWebDriver driver) : base(driver)
    {
        WaitForElement(_reviewOrder);
    }

    public void ClickPlaceOrderButton()
    {
        try
        {
            Utils.ClickElement(Driver, _placeOrderButton);
            ExtentReportManager.LogPass("Clicked on Place Order button successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click Place Order button."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click Place Order button.", ex);
        }
    }
}