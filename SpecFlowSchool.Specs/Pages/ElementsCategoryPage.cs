using OpenQA.Selenium;

namespace SpecFlowSchool.Specs.Pages
{
    internal class ElementsCategoryPage : BaseCategoryPage
    {

        private const string tbUserNameId = "userName";
        private const string tbUserEmailId = "userEmail";
        private const string tbCurrentAddressId = "currentAddress";
        private const string tbPermanentAddressId = "permanentAddress";
        private const string tbOutputUserNameId = "name";
        private const string tbOutputUserEmailId = "email";
        private const string tbOutputCurrentAddressId = "currentAddress";
        private const string tbOutputPermanentAddressId = "permanentAddress";
        private string outputValueById(string id) => $"//*[@id='{id}']/ancestor::*[@id='output']";

        public ElementsCategoryPage(PageContext context) : base(context) { }

        internal void ClickSubmit()
        {
            HideFooter();
            var btnSubmit = GetElementsById("submit").FirstOrDefault(); 
            GetBuilder().MoveToElement(btnSubmit).Click().Perform();
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