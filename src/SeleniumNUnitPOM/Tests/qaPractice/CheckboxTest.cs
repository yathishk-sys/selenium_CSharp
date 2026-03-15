using OpenQA.Selenium;
using SeleniumNUnitPOM.Pages.qaPractice;
using SeleniumNUnitPOM.Reports;

namespace SeleniumNUnitPOM.Tests.qaPractice;

public class CheckboxTest : BaseTest
{
    private HomePage qaPracticeHomePage;

    [SetUp]
    public void SetUp()
    {
        qaPracticeHomePage = new HomePage(Driver);
              
        ExtentReportManager.CreateTest("Checkbox Test");
        // qaPracticeHomePage.Open();
        
    }

    [Test]
    public void TestCheckboxes()
    {
        // Check the first checkbox
        qaPracticeHomePage.clickTextInputButton();
        PracticePage practicePage = new PracticePage(Driver);
        practicePage.clickCheckboxLink();
        practicePage.selectCheckBox(true);
        practicePage.clickSubmitInCheckbox();
        practicePage.verifySelectedCheckboxText();                
    }

    [TearDown]
    public void TearDown()
    {
        ExtentReportManager.FlushReport();
    }
}