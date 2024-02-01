using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowSchool.Specs.Pages
{
    using SpecFlowSchool.Specs.Constants;
    internal partial class HomePage : PageBase
    {
        private const string defaultLink = "https://demoqa.com";
        private IWebDriver driver;
        By btnConsentUseData = By.XPath($"//button[contains(@class, 'fc-cta-consent')]");
        string clickableDivForCategory(string categoryName) => $"//h5[text()='{categoryName}']//ancestor::div[contains(@class, 'card mt-4 top-card')]";

        
        //public HomePage(IWebDriver driver)
        //{
        //    this.driver = driver;
        //    driver.Url = defaultLink;

        //    CloseConsentPopup(driver);
        //    HideAds(driver);
        //}

        public HomePage(PageContext context)
         : base(context)
        {
            driver.Url = defaultLink;
            CloseConsentPopup(driver);
            HideAds(driver);
        }

        private void CloseConsentPopup(IWebDriver driver)
        {
            driver.FindElement(btnConsentUseData).Click();
        }

        private void HideAds(IWebDriver driver)
        {
            IWebElement elem = driver.FindElement(By.Id("fixedban"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility='hidden'", elem);
        }

        public void SelectCategory(string categoryName)
        {            
            IWebElement categoryElement = driver.FindElement(By.XPath(clickableDivForCategory(categoryName)));
            new Actions(driver).MoveToElement(categoryElement).Click(categoryElement).Perform();

            //return new ElementsCategoryPage();
        }
    }
}
