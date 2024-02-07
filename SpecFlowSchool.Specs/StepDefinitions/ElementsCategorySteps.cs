using SpecFlowSchool.Specs.Pages;

namespace SpecFlowSchool.Specs.StepDefinitions
{
    [Binding]
    internal class ElementsCategorySteps
    {
        private ElementsCategoryPage _elementsCategoryPage;
        private Table _textBoxValuesFromFeatureFile;

        public ElementsCategorySteps(ElementsCategoryPage elementsCategoryPage)
        {
            this._elementsCategoryPage = elementsCategoryPage;
        }

        [Given(@"Selected section is (.*)")]
        public void GivenSelectedSectionIsButtons(string sectionName)
        {
            _elementsCategoryPage.SelectSection(sectionName);
        }

        [When(@"user presses (.*) button appropriate way")]
        public void WhenUserInteractsWithButtonNameButtonAppropriateWay(string buttonTitle)
        {
            _elementsCategoryPage.InteractWithButtonAccordingToItsType(buttonTitle);
        }

        [Then(@"(.*) message is present in the form below")]
        public void ThenMessageIsAddedToTheListBelow_(string message)
        {
            bool expectedMessageIsPresent = _elementsCategoryPage.CheckMessagePresence(message);
            expectedMessageIsPresent.Should().BeTrue();
        }

        [When(@"Submit button pressed")]
        public void WhenSubmitButtonPressed()
        {
            _elementsCategoryPage.ClickSubmit();
        }

        [When(@"Valid values are entered in Text Box section fields")]
        public void WhenValidValuesAreEnteredInTextBoxSectionFields(Table table)
        {
            _textBoxValuesFromFeatureFile = table;
            _elementsCategoryPage.FillTextBoxSectionValues(table);
        }

        [Then(@"Values displayed in table below are the same as values which were entered to the fields")]
        public void ThenValuesDisplayedInTableBelowAreTheSameAsValuesWhichWereEnteredToTheFields()
        {
           _elementsCategoryPage.CheckOutputValues(_textBoxValuesFromFeatureFile);
        }
    }
}
