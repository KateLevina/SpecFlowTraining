using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowSchool.Specs.Pages
{
    internal class ElementsCategoryPage : BaseCategoryPage
    {
        private const string btnSumbitId = "submit";
        private const string tbUserNameId = "userName";
        private const string tbUserEmailId = "userEmail";
        private const string tbCurrentAddressId = "currentAddress";
        private const string tbPermanentAddressId = "permanentAddress";
        private const string tbOutputUserNameId = "name";
        private const string tbOutputUserEmailId = "email";
        private const string tbOutputCurrentAddressId = "currentAddress";
        private const string tbOutputPermanentAddressId = "permanentAddress";
        private string outputValueById(string id) => $"//p[@id='{id}']/ancestor::div[@id='output']";

        public ElementsCategoryPage(PageContext context) : base(context) { }

        internal void ClickSubmit()
        {
            // Hiding footer is a workaround.
            // There is a bug that Sumbit button is not accessible with some window size.
            HideFooter();
            var btnSubmit = GetElementsById(btnSumbitId).FirstOrDefault(); 
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
            Assert.Multiple(() =>
            {
                Assert.IsTrue(GetTextByXPath(outputValueById(tbOutputUserNameId)).Contains(textBoxValuesFromFeatureFile.Rows[0][0]));
                Assert.IsTrue(GetTextByXPath(outputValueById(tbOutputUserEmailId)).Contains(textBoxValuesFromFeatureFile.Rows[0][1]));
                Assert.IsTrue(GetTextByXPath(outputValueById(tbOutputCurrentAddressId)).Contains(textBoxValuesFromFeatureFile.Rows[0][2]));
                Assert.IsTrue(GetTextByXPath(outputValueById(tbOutputPermanentAddressId)).Contains(textBoxValuesFromFeatureFile.Rows[0][3]));
            });
        }
    }
}