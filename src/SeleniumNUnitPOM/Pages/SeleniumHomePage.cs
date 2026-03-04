using OpenQA.Selenium;

namespace SeleniumNUnitPOM.Pages;

public class SeleniumHomePage(IWebDriver driver) : BasePage(driver)
{
    private readonly By _downloadsLink = By.CssSelector("a[href='/downloads']");

    public const string Url = "https://www.selenium.dev/";

    public void NavigateTo()
    {
        Driver.Navigate().GoToUrl(Url);
    }

    public string Title => Driver.Title;

    public bool IsDownloadsLinkVisible()
    {
        return WaitForElement(_downloadsLink).Displayed;
    }
}
