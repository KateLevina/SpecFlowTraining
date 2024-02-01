using OpenQA.Selenium;
using SpecFlowSchool.Specs.Pages;

namespace SpecFlowSchool.Specs.StepDefinitions
{
    [Binding]
    public class ElementsCategoryStepDefinitions
    {
        private IWebDriver driver;
        HomePage homePage;
        ElementsCategoryPage elementsCategoryPage;

        public ElementsCategoryStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            homePage = new HomePage(driver);
        }

        [Given(@"DemoQA Home page is opened")]
        public void GivenHttpsDemoqa_ComIsOpened()
        {
          
        }

        [Given(@"Selected category is (.*)")]
        public void GivenSelectedCategoryIsElements(string categoryName)
        {
            elementsCategoryPage = homePage.selectCategory(categoryName);
        }

        [Given(@"Selected section is (.*)")]
        public void GivenSelectedSectionIsButtons(string sectionName)
        {
            elementsCategoryPage.SelectSection(sectionName);
        }

        [When(@"user interacts with (.*) button appropriate way")]
        public void WhenUserInteractsWithButtonNameButtonAppropriateWay(string buttonTitle)
        {
            elementsCategoryPage.InteractWithButtonAccordingToItsType(buttonTitle);
        }

        [Then(@"(.*) message is present in the form below\.")]
        public void ThenMessageIsAddedToTheListBelow_(string message)
        {
            bool expectedMessageIsPresent = elementsCategoryPage.CheckMessagePresence(message);
            expectedMessageIsPresent.Should().BeTrue();
        }
    }
}
