using OpenQA.Selenium;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Pages.qaPractice;

public class PracticePage : BasePage
{
    private readonly By _textInputButton = By.XPath("//a[normalize-space()='Text input']");
    private readonly By _checkboxLink = By.XPath("//a[normalize-space()='Checkbox']");
    private readonly By _SelectMeorNotcheckBox = By.XPath("//input[@name='checkbox']");
    private readonly By _submitInCheckbox = By.XPath("//input[@id='submit-id-submit']");
    private readonly By _textInCheckbox = By.XPath("//p[normalize-space()='Selected checkboxes:']");
    private readonly By _selectLink = By.XPath("//a[normalize-space()='Select']");
    private readonly By _windowsLink = By.XPath("//a[normalize-space()='New tab']");

    public PracticePage(IWebDriver driver) : base(driver)
    {
        WaitForElement(_textInputButton);
    }

    public void clickCheckboxLink()
    {
        try
        {
            Utils.ClickElement(Driver, _checkboxLink);
            ExtentReportManager.LogPass("Clicked on Checkbox link successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click on Checkbox link."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click on Checkbox link.", ex);
        }       
    }

    public void selectCheckBox(bool shouldSelect)
    {
        try
        {
            Utils.SetCheckboxState(Driver, _SelectMeorNotcheckBox, shouldSelect);
            ExtentReportManager.LogPass("Selected the checkbox successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to select the checkbox."+ex.StackTrace);
            throw new InvalidOperationException("Failed to select the checkbox.", ex);
        }       
    }

    public void clickSubmitInCheckbox()
    {
        try
        {
            Utils.ClickElement(Driver, _submitInCheckbox);
            ExtentReportManager.LogPass("Clicked on Submit button in Checkbox section successfully.");
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to click on Submit button in Checkbox section."+ex.StackTrace);
            throw new InvalidOperationException("Failed to click on Submit button in Checkbox section.", ex);
        }       
    }

    public void verifySelectedCheckboxText()
    {
        try
        {
            string expectedText = "Selected checkboxes:";
            string actualText = Utils.GetElementText(Driver, _textInCheckbox);
            if (actualText.Equals(expectedText))
            {
                ExtentReportManager.LogPass("Selected checkbox text is displayed correctly.");
            }
            else
            {
                ExtentReportManager.LogFail($"Selected checkbox text is incorrect. Expected: '{expectedText}', Actual: '{actualText}'");
                throw new InvalidOperationException($"Selected checkbox text is incorrect. Expected: '{expectedText}', Actual: '{actualText}'");
            }
        }
        catch (WebDriverException ex)
        {
            ExtentReportManager.LogFail("Failed to verify selected checkbox text."+ex.StackTrace);
            throw new InvalidOperationException("Failed to verify selected checkbox text.", ex);
        }       
    }


}