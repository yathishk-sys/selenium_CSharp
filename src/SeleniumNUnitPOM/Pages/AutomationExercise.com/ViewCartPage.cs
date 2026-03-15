using OpenQA.Selenium;
using SeleniumNUnitPOM.Reports;
namespace SeleniumNUnitPOM.Pages.AutomationExercise.com;

public class ViewCartPage : BasePage
{
    private readonly By _cartItem = By.XPath("//tr[@id='product-1']");
    private readonly By _cartItemWomenTop = By.XPath("//tr[@id='product-1']//a[text()='Blue Top']");

    private readonly By _checkOutButton = By.XPath("//a[@class='btn btn-default check_out']");

    public ViewCartPage(IWebDriver driver) : base(driver)
    {
        WaitForElement(_cartItem);
    }

    public void IsProductInCart()
    {
        try
        {
            WaitForElement(_cartItemWomenTop);
            
                ExtentReportManager.LogPass("Verified product is in cart successfully.");
                 
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to verify product in cart."+ex.StackTrace);
            throw new InvalidOperationException("Failed to verify product in cart.", ex);
        }
    }

    public void ClickCheckOutButton()
    {
        try
        {
            Utils.ClickElement(Driver, _checkOutButton);
            ExtentReportManager.LogPass("Clicked on Check Out button successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click Check Out button."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click Check Out button.", ex);
        }
    }   

}