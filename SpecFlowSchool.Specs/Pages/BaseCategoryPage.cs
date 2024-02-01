using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace SpecFlowSchool.Specs.Pages
{
    internal class BaseCategoryPage : PageBase
    {
        protected IWebDriver driver;
        string clickableDivForSection(string sectionName) => $"//*[text()='{sectionName}']//ancestor::*[contains(@class, 'btn-light')]";
        
        //public BaseCategoryPage(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}

        public BaseCategoryPage(PageContext context)
    : base(context)
        {
        }

        public void SelectSection(string sectionName)
        {
            IWebElement sectionElement = driver.FindElement(By.XPath(clickableDivForSection(sectionName)));
            new Actions(driver).Click(sectionElement).Perform();
        }
    }
}
