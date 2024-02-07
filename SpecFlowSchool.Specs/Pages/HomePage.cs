using OpenQA.Selenium;

namespace SpecFlowSchool.Specs.Pages
{
    internal partial class HomePage : PageBase
    {
        public const string DefaultLink = "https://demoqa.com";
        private const string btnConsentUseData = $"//button[contains(@class, 'fc-cta-consent')]";
        private string clickableDivForCategory(string categoryName) => $"//h5[text()='{categoryName}']//ancestor::div[contains(@class, 'card mt-4 top-card')]";

        public HomePage(PageContext context) : base(context) { }

        public void CloseConsentPopup()
        {
            try
            {
                var consentButton = WaitForVisibility(By.XPath(btnConsentUseData), 2);
                //if (consentButton != null)
                //{
                consentButton.Click();
                //}
            }
            catch
            {
                
            }
        }

      
           
        public void SelectCategory(string categoryName)
        {            
            IWebElement categoryElement = GetElement(By.XPath(clickableDivForCategory(categoryName)));
            categoryElement.Click();
        }
    }
}
