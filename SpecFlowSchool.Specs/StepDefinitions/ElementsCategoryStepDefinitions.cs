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
        }

        [Given(@"https://demoqa\.com/ is opened")]
        public void GivenHttpsDemoqa_ComIsOpened()
        {
            homePage = new HomePage(driver);
        }

        [Given(@"Selected category is Elements")]
        public void GivenSelectedCategoryIsElements()
        {
            elementsCategoryPage = homePage.selectCategory("Elements");
        }

        [Given(@"Selected section is Buttons")]
        public void GivenSelectedSectionIsButtons()
        {
            elementsCategoryPage.SelectSection("Buttons");
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
