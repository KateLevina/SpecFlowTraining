using OpenQA.Selenium;

namespace SpecFlowSchool.Specs.Pages
{
    internal partial class HomePage : PageBase
    {
        private const string btnConsentUseData = $"//button[contains(@class, 'fc-cta-consent')]";
        private string clickableDivForCategory(string categoryName) => $"//h5[text()='{categoryName}']//ancestor::div[contains(@class, 'card mt-4 top-card')]";

        public HomePage(PageContext context) : base(context) { }

        public void CloseConsentPopup()
        {
            try
            {
                var consentButton =  GetElement(By.XPath(btnConsentUseData));
                consentButton.Click();
            }
            catch (NoSuchElementException)
            {
                // No need to process this exception.
                // It means that popup with Consent button didn't appear so no need to close it.
            }
        }

        public void SelectCategory(string categoryName)
        {            
            IWebElement categoryElement = GetElement(By.XPath(clickableDivForCategory(categoryName)));
            categoryElement.Click();
        }
    }
}
