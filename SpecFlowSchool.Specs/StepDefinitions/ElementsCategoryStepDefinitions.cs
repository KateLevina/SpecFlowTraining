using OpenQA.Selenium;
using SpecFlowSchool.Specs.Pages;

namespace SpecFlowSchool.Specs.StepDefinitions
{
    [Binding]
    internal class ElementsCategoryStepDefinitions
    {
        private IWebDriver driver;
        HomePage homePage;

        //public ElementsCategoryStepDefinitions(IWebDriver driver)
        //{
        //    this.driver = driver;
        //    homePage = new HomePage(driver);
        //}

        public ElementsCategoryStepDefinitions(ElementsCategoryPage page)
        {
            Page = page;
        }

        private ElementsCategoryPage Page { get; set; }

        [Given(@"DemoQA Home page is opened")]
        public void GivenHttpsDemoqa_ComIsOpened()
        {
          
        }

        [Given(@"Selected category is (.*)")]
        public void GivenSelectedCategoryIsElements(string categoryName)
        {
            /*Page =*/
            homePage.SelectCategory(categoryName);
        }

        [Given(@"Selected section is (.*)")]
        public void GivenSelectedSectionIsButtons(string sectionName)
        {
            Page.SelectSection(sectionName);
        }

        [When(@"user interacts with (.*) button appropriate way")]
        public void WhenUserInteractsWithButtonNameButtonAppropriateWay(string buttonTitle)
        {
            Page.InteractWithButtonAccordingToItsType(buttonTitle);
        }

        [Then(@"(.*) message is present in the form below\.")]
        public void ThenMessageIsAddedToTheListBelow_(string message)
        {
            bool expectedMessageIsPresent = Page.CheckMessagePresence(message);
            expectedMessageIsPresent.Should().BeTrue();
        }
    }
}
