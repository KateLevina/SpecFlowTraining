namespace SpecFlowSchool.Specs.Pages
{
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;
    using System;

    //COMMON ACTIONS FOR WEBDRIVER
    /// <summary>
    /// Common actions for WebDriver
    /// This base class contains a useful set of helper methods for scripting Selenium.
    /// </summary>
    public class PageBase
    {
        protected readonly PageContext Context;
        private const int MaxWaitSeconds = 10;

        public PageBase(PageContext context)
        {
            this.Context = context;
        }

        public Actions GetBuilder()
        {
            return Context.Actions;
        }

        public void NavigateTo(string url)
        {
            this.Context.Driver.Navigate().GoToUrl(url);
        }

        public IReadOnlyCollection<IWebElement> GetElementsById(string id)
        {
            return Context.Driver.FindElements(By.Id(id));
        }

        public string GetTextByXPath(string XPathText)
        {
            WaitForVisibility(By.XPath(XPathText), 10);
            return Context.Driver.FindElement(By.XPath(XPathText)).Text;
        }

        public IWebElement GetElement(By byCriterion)
        {
            ((IJavaScriptExecutor)Context.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Context.Driver.FindElement(byCriterion));
            return Context.Driver.FindElement(byCriterion);
        }

        public void ExecuteScript(string script, params object[] args)
        {
            ((IJavaScriptExecutor)this.Context.Driver).ExecuteScript(script, args);
        }

        public IWebElement WaitForVisibility(By byCriterion, int maxWaitSeconds = MaxWaitSeconds)
        {
            var wait = new WebDriverWait(this.Context.Driver, TimeSpan.FromSeconds(maxWaitSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(byCriterion));
        }

        public void HideAds()
        {
            var googleAdsItemId = "fixedban";
            ExecuteScript("arguments[0].style.visibility='hidden'", GetElementsById(googleAdsItemId).FirstOrDefault());
        }
    }
}