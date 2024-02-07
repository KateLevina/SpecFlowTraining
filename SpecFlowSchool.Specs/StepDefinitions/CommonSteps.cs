using SpecFlowSchool.Specs.Pages;

namespace SpecFlowSchool.Specs.StepDefinitions
{
    [Binding]
    internal class CommonSteps
    {
        private HomePage _homePage;

        public CommonSteps(HomePage homePage)
        {
            this._homePage = homePage;
        }

        [Given(@"DemoQA Home page is opened")]
        public void GivenHttpsDemoqa_ComIsOpened()
        {
            _homePage.NavigateTo(HomePage.DefaultLink);
            _homePage.CloseConsentPopup();
            _homePage.HideAds();
        }

        [Given(@"Selected category is (.*)")]
        public void GivenSelectedCategoryIsElements(string categoryName)
        {
            _homePage.SelectCategory(categoryName);         
        }
    }
}
