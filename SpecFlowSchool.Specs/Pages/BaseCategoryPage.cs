using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSchool.Specs.Pages
{
    internal class BaseCategoryPage
    {
        protected IWebDriver driver;
        string clickableDivForSection(string sectionName) => $"//*[text()='{sectionName}']//ancestor::*[contains(@class, 'btn-light')]";
        
        public BaseCategoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectSection(string sectionName)
        {
            IWebElement sectionElement = driver.FindElement(By.XPath(clickableDivForSection(sectionName)));
            new Actions(driver).Click(sectionElement).Perform();
        }
    }
}
