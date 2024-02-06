using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace SpecFlowSchool.Specs.Pages
{
    internal class ElementsCategoryPage : BaseCategoryPage
    {
        private string buttonByTitle(string buttonTitle) => $"//button[text()='{buttonTitle}']";
        private const string tbUserNameId = "userName";
        private const string tbUserEmailId = "userEmail";
        private const string tbCurrentAddressId = "currentAddress";
        private const string tbPermanentAddressId = "permanentAddress";
        private const string tbOutputUserNameId = "name";
        private const string tbOutputUserEmailId = "email";
        private const string tbOutputCurrentAddressId = "currentAddress";
        private const string tbOutputPermanentAddressId = "permanentAddress";
        private string outputValueById(string id) => $"//*[@id='{id}']/ancestor::*[@id='output']";
        //private string outputValueById(string id) => $"//*[@id='{id}']";

        public ElementsCategoryPage(PageContext context) : base(context) { }

        public void InteractWithButtonAccordingToItsType(string btnTitle)
        {
            Actions actions = new Actions(Context.Driver);
            var btn = GetElement(By.XPath(buttonByTitle(btnTitle)));
            
            switch (btnTitle)
            {
                case "Click Me":
                    btn.Click();
                    break;
                case "Double Click Me":
                    actions.DoubleClick(btn).Perform();
                    break;
                case "Right Click Me":
                    actions.ContextClick(btn).Perform();
                    break;
                default:
                    throw new NotImplementedException($"'{btnTitle}' type of button is not supported");
            }
        }

        public bool CheckMessagePresence(string message)
        {
            var expectedLabel = GetElement(By.XPath($"//p[text()='{message}']"));
            return expectedLabel != null;
        }

        internal void ClickSubmit()
        {
            //p((WebElement)GetElementsById("submit").First()).
            ClickById("submit");
        }

        internal void FillTextBoxSectionValues(Table table)
        {
            GetElementsById(tbUserNameId).First().SendKeys(table.Rows[0][0]);
            GetElementsById(tbUserEmailId).First().SendKeys(table.Rows[0][1]);
            GetElementsById(tbCurrentAddressId).First().SendKeys(table.Rows[0][2]);
            GetElementsById(tbPermanentAddressId).First().SendKeys(table.Rows[0][3]);
        }

        internal void CheckOutputValues(Table textBoxValuesFromFeatureFile)
        {
            GetElement(By.XPath(outputValueById(tbOutputUserNameId))).Text.
                Should().Contain(textBoxValuesFromFeatureFile.Rows[0][0]);
            GetElement(By.XPath(outputValueById(tbOutputUserEmailId))).Text.
                Should().Contain(textBoxValuesFromFeatureFile.Rows[0][1]);
            GetElement(By.XPath(outputValueById(tbOutputCurrentAddressId))).Text.
                Should().Contain(textBoxValuesFromFeatureFile.Rows[0][2]);
            GetElement(By.XPath(outputValueById(tbOutputPermanentAddressId))).Text.
                Should().Contain(textBoxValuesFromFeatureFile.Rows[0][3]);
        }
    }
}