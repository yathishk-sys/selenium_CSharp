using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumNUnitPOM.Utilities;

/// <summary>
/// Utility class containing common actions performed on webpages.
/// </summary>
public static class Utils
{
    /// <summary>
    /// Clicks on an element.
    /// </summary>
    public static void ClickElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        element.Click();
    }

    /// <summary>
    /// Sends text to an input field.
    /// </summary>
    public static void SendKeys(IWebDriver driver, By locator, string text, int timeoutInSeconds = 10)
    {
        // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        // var element = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator)).FirstOrDefault();
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        if (element == null)
            throw new NoSuchElementException($"Element not found: {locator}");
        element.Clear();
        element.SendKeys(text);
    }

    /// <summary>
    /// Clears text from an input field.
    /// </summary>
    public static void ClearText(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        element.Clear();
    }

    /// <summary>
    /// Gets the text content of an element.
    /// </summary>
    public static string GetText(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        return element.Text;
    }

    /// <summary>
    /// Gets the value of an element's attribute.
    /// </summary>
    public static string? GetAttribute(IWebDriver driver, By locator, string attributeName, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        return element.GetAttribute(attributeName);
    }

    /// <summary>
    /// Checks if an element is displayed on the page.
    /// </summary>
    public static bool IsElementDisplayed(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        try
        {
            var element = driver.WaitForVisible(locator, timeoutInSeconds);
            return element.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if an element is enabled.
    /// </summary>
    public static bool IsElementEnabled(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator)).FirstOrDefault();
            return element?.Enabled ?? false;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Waits for an element to be present in the DOM.
    /// </summary>
    public static IWebElement WaitForElementPresence(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator)).FirstOrDefault() ?? throw new NoSuchElementException($"Element not found: {locator}");
    }

    /// <summary>
    /// Waits for an element to be invisible.
    /// </summary>
    public static bool WaitForElementInvisibility(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Selects an option from a dropdown by visible text.
    /// </summary>
    public static void SelectDropdownByText(IWebDriver driver, By locator, string text, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        var selectElement = new SelectElement(element);
        selectElement.SelectByText(text);
    }

    /// <summary>
    /// Selects an option from a dropdown by value.
    /// </summary>
    public static void SelectDropdownByValue(IWebDriver driver, By locator, string value, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        var selectElement = new SelectElement(element);
        selectElement.SelectByValue(value);
    }

    /// <summary>
    /// Selects an option from a dropdown by index.
    /// </summary>
    public static void SelectDropdownByIndex(IWebDriver driver, By locator, int index, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        var selectElement = new SelectElement(element);
        selectElement.SelectByIndex(index);
    }

    /// <summary>
    /// Hovers over an element.
    /// </summary>
    public static void HoverOverElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        var actions = new Actions(driver);
        actions.MoveToElement(element).Perform();
    }

    /// <summary>
    /// Right-clicks on an element.
    /// </summary>
    public static void RightClickElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        var actions = new Actions(driver);
        actions.ContextClick(element).Perform();
    }

    /// <summary>
    /// Double-clicks on an element.
    /// </summary>
    public static void DoubleClickElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        var actions = new Actions(driver);
        actions.DoubleClick(element).Perform();
    }

    /// <summary>
    /// Switches to a frame by index.
    /// </summary>
    public static void SwitchToFrameByIndex(IWebDriver driver, int index)
    {
        driver.SwitchTo().Frame(index);
    }

    /// <summary>
    /// Switches to a frame by name or ID.
    /// </summary>
    public static void SwitchToFrameByNameOrId(IWebDriver driver, string nameOrId)
    {
        driver.SwitchTo().Frame(nameOrId);
    }

    /// <summary>
    /// Switches to a frame by element.
    /// </summary>
    public static void SwitchToFrameByElement(IWebDriver driver, IWebElement frameElement)
    {
        driver.SwitchTo().Frame(frameElement);
    }

    /// <summary>
    /// Switches back to the parent frame.
    /// </summary>
    public static void SwitchToParentFrame(IWebDriver driver)
    {
        driver.SwitchTo().ParentFrame();
    }

    /// <summary>
    /// Switches to the default content (main page).
    /// </summary>
    public static void SwitchToDefaultContent(IWebDriver driver)
    {
        driver.SwitchTo().DefaultContent();
    }

    /// <summary>
    /// Gets the current page URL.
    /// </summary>
    public static string GetCurrentUrl(IWebDriver driver)
    {
        return driver.Url;
    }

    /// <summary>
    /// Gets the current page title.
    /// </summary>
    public static string GetPageTitle(IWebDriver driver)
    {
        return driver.Title;
    }

    /// <summary>
    /// Refreshes the current page.
    /// </summary>
    public static void RefreshPage(IWebDriver driver)
    {
        driver.Navigate().Refresh();
    }

    /// <summary>
    /// Navigates to a specific URL.
    /// </summary>
    public static void NavigateToUrl(IWebDriver driver, string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    /// <summary>
    /// Executes JavaScript code.
    /// </summary>
    public static object? ExecuteJavaScript(IWebDriver driver, string script, params object[] args)
    {
        var jsExecutor = (IJavaScriptExecutor)driver;
        return jsExecutor.ExecuteScript(script, args);
    }

    /// <summary>
    /// Scrolls to an element.
    /// </summary>
    public static void ScrollToElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        ExecuteJavaScript(driver, "arguments[0].scrollIntoView(true);", element);
    }

    /// <summary>
    /// Scrolls to the top of the page.
    /// </summary>
    public static void ScrollToTop(IWebDriver driver)
    {
        ExecuteJavaScript(driver, "window.scrollTo(0, 0);");
    }

    /// <summary>
    /// Scrolls to the bottom of the page.
    /// </summary>
    public static void ScrollToBottom(IWebDriver driver)
    {
        ExecuteJavaScript(driver, "window.scrollTo(0, document.body.scrollHeight);");
    }

    /// <summary>
    /// Accepts an alert dialog.
    /// </summary>
    public static void AcceptAlert(IWebDriver driver, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.AlertIsPresent());
        driver.SwitchTo().Alert().Accept();
    }

    /// <summary>
    /// Dismisses an alert dialog.
    /// </summary>
    public static void DismissAlert(IWebDriver driver, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.AlertIsPresent());
        driver.SwitchTo().Alert().Dismiss();
    }

    /// <summary>
    /// Gets the alert dialog text.
    /// </summary>
    public static string GetAlertText(IWebDriver driver, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.AlertIsPresent());
        return driver.SwitchTo().Alert().Text;
    }

    /// <summary>
    /// Sends text to an alert dialog.
    /// </summary>
    public static void SendKeysToAlert(IWebDriver driver, string text, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.AlertIsPresent());
        driver.SwitchTo().Alert().SendKeys(text);
    }

    /// <summary>
    /// Gets all elements matching a locator.
    /// </summary>
    public static IList<IWebElement> GetAllElements(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
    }

    /// <summary>
    /// Checks if an element exists on the page.
    /// </summary>
    public static bool IsElementPresent(IWebDriver driver, By locator)
    {
        try
        {
            driver.FindElement(locator);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    /// <summary>
    /// Gets the number of elements matching a locator.
    /// </summary>
    public static int GetElementCount(IWebDriver driver, By locator)
    {
        return driver.FindElements(locator).Count;
    }

    /// <summary>
    /// Moves to an element and clicks it (useful for elements that need to be visible first).
    /// </summary>
    public static void MoveToAndClick(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var element = driver.WaitForVisible(locator, timeoutInSeconds);
        var actions = new Actions(driver);
        actions.MoveToElement(element).Click().Perform();
    }

    /// <summary>
    /// Drags and drops an element to another location.
    /// </summary>
    public static void DragAndDrop(IWebDriver driver, By sourceLocator, By targetLocator, int timeoutInSeconds = 10)
    {
        var sourceElement = driver.WaitForVisible(sourceLocator, timeoutInSeconds);
        var targetElement = driver.WaitForVisible(targetLocator, timeoutInSeconds);
        var actions = new Actions(driver);
        actions.DragAndDrop(sourceElement, targetElement).Perform();
    }

    /// <summary>
    /// Waits for a specific number of elements to be present.
    /// </summary>
    public static bool WaitForNumberOfElements(IWebDriver driver, By locator, int expectedCount, int timeoutInSeconds = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(d => d.FindElements(locator).Count == expectedCount);
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Takes a screenshot of the current page and saves it to the TestReports/Screenshots directory.
    /// </summary>
    /// <param name="driver">The WebDriver instance.</param>
    /// <param name="name">The screenshot name (without extension).</param>
    /// <returns>The full path to the saved screenshot file.</returns>
    internal static string TakeScreenshot(IWebDriver driver, string name)
    {
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        var screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestReports", "Screenshots");
        
        if (!Directory.Exists(screenshotDirectory))
            Directory.CreateDirectory(screenshotDirectory);
        
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
        var filename = $"{name}_{timestamp}.png";
        var filepath = Path.Combine(screenshotDirectory, filename);
        
        screenshot.SaveAsFile(filepath);
        
        return filepath;
    }
}
