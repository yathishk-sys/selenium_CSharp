using OpenQA.Selenium;
using SeleniumNUnitPOM.Pages.AutomationExercise.com;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Tests.AutomationExercise.com;

[TestFixture]
public class E2E_ProductPurchase : BaseTest
{
    [Test]
    public void TestProductPurchaseFlow()
    {
        try
        {
            // Navigate to home page
            var homePage = new HomePage(Driver);
            homePage.ClickLoginLink();

            var loginPage = new LoginPage(Driver);
            loginPage.Login("yathish0557@gmail.com", "Test@1234");
            
            homePage.clickWinterDressViewProductLink();

            ProductPage productPage = new ProductPage(Driver);
            productPage.ClickAddToCart();
            productPage.ClickViewCart();

            ViewCartPage viewCartPage = new ViewCartPage(Driver);
            viewCartPage.ClickCheckOutButton();

            CheckoutPage checkoutPage = new CheckoutPage(Driver);
            checkoutPage.ClickPlaceOrderButton();


            // Assert.That(homePage.Title, Does.Contain("Automation Exercise"));

            // // Click on product
            // var productPage = new ProductPage(Driver);
            // productPage.ClickAddToCart();
            // productPage.ClickViewCart();

            // // Verify product is in cart
            // var viewCartPage = new ViewCartPage(Driver);
            // Assert.IsTrue(viewCartPage.IsProductInCart(), "Product was not found in the cart.");
            // ExtentReportManager.LogPass("Verified product is in cart successfully.");

            // // Proceed to checkout
            // viewCartPage.ClickCheckOutButton();
            // var checkoutPage = new CheckoutPage(Driver);
            // checkoutPage.ClickPlaceOrderButton();
        }
        catch (Exception ex)
        {
            ExtentReportManager.LogFail("Test failed with exception: " + ex.Message + ex.StackTrace);
            throw;
        }
    }
}