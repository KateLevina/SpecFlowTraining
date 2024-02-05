using OpenQA.Selenium;

namespace SpecFlowSchool.Specs.Pages
{
    internal partial class HomePage : PageBase
    {
        public const string DefaultLink = "https://demoqa.com";
        private const string googleAdsItemId = "fixedban";
        private const string btnConsentUseData = $"//button[contains(@class, 'fc-cta-consent')]";
        private string clickableDivForCategory(string categoryName) => $"//h5[text()='{categoryName}']//ancestor::div[contains(@class, 'card mt-4 top-card')]";

        public HomePage(PageContext context) : base(context) { }

        public void CloseConsentPopup()
        {
            try
            {
                ClickByXPath(btnConsentUseData, 2);
            }
            catch
            {
                // no need to process exception, it means that popup for consent did not appeared this time
            }
        }

        public void HideAds()
        {
            try
            {
                ExecuteScript("arguments[0].style.visibility='hidden'", GetElementsById(googleAdsItemId).FirstOrDefault());
            }
            catch
            {
                // no need to process exception, it means that googe ads was just not visible at this time
            }
        }
           
        public void SelectCategory(string categoryName)
        {            
            IWebElement categoryElement = GetElement(By.XPath(clickableDivForCategory(categoryName)));
            categoryElement.Click();
        }
    }
}
