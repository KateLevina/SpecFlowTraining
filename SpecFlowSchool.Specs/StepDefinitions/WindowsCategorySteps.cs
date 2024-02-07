using SpecFlowSchool.Specs.Pages;

namespace SpecFlowSchool.Specs.StepDefinitions
{
    [Binding]
    internal class WindowsCategorySteps
    {
        private const string sampleTextOnOpenedPage = "This is a sample page";
        private WindowsCategoryPage _windowsCategoryPage;

        public WindowsCategorySteps(WindowsCategoryPage windowsCategoryPage)
        {
            this._windowsCategoryPage = windowsCategoryPage;
        }

        [When(@"(.*) button is pressed and switched to new handle")]
        public void WhenButtonIsPressed(string buttonName)
        {
            _windowsCategoryPage.InteractWithButtonAccordingToItsType(buttonName);
        }

        [Then(@"Sample text is present on new page")]
        public void ThenThisIsASamplePageTestIsPresentOnPage()
        {
            _windowsCategoryPage.CheckMessagePresence(sampleTextOnOpenedPage);
        }
    }
}
