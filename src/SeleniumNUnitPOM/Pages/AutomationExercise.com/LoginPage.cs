using OpenQA.Selenium;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Pages.AutomationExercise.com;

public class LoginPage : BasePage
{
    private readonly By _emailInput = By.XPath("//input[@data-qa='login-email']");
    private readonly By _passwordInput = By.XPath("//input[@placeholder='Password']");
    private readonly By _loginButton = By.XPath("//button[normalize-space()='Login']");

    public LoginPage(IWebDriver driver) : base(driver)
    {
        WaitForElement(_emailInput);
    }   

    public void NavigateTo()
    {
        Driver.Navigate().GoToUrl("https://automationexercise.com/login");
    }

    public void Login(string email, string password)
    {
        EnterEmail(email);
        EnterPassword(password);
        ClickLoginButton();
    }

    public void EnterEmail(string email)
    {
        try
        {
            WaitForElement(_emailInput).Clear();
            WaitForElement(_emailInput).SendKeys(email);
            ExtentReportManager.LogPass("Email entered successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to enter email."+ex.StackTrace);
            throw new InvalidOperationException("Failed to enter email.", ex);
        }       
    }

    public void EnterPassword(string password)
    {
        try
        {
            WaitForElement(_passwordInput).Clear();
            WaitForElement(_passwordInput).SendKeys(password);
            ExtentReportManager.LogPass("Password entered successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to enter password."+ex.StackTrace);
            throw new InvalidOperationException("Failed to enter password.", ex);
        }       
    }

    public void ClickLoginButton()
    {
        try
        {
            Utils.ClickElement(Driver, _loginButton);
            ExtentReportManager.LogPass("Clicked on Login button successfully.");  
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click Login button."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click Login button.", ex);
        } 
    }
}