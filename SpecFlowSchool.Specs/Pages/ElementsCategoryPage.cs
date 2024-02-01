using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowSchool.Specs.Pages
{

    internal class ElementsCategoryPage : BaseCategoryPage
    {
        //public ElementsCategoryPage(IWebDriver driver) : base(driver)
        //{
        //}

        public ElementsCategoryPage(PageContext context) : base(context)
        {
        }

        public void InteractWithButtonAccordingToItsType(string buttonTitle)
        {
            Actions actions = new Actions(driver);

            var btn = driver.FindElement(By.XPath($"//button[text()='{buttonTitle}']"));
            
            //TODO: need to find better solution
            Thread.Sleep(1000);
            switch (buttonTitle)
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
                    throw new NotImplementedException($"'{buttonTitle}' type of button is not supported");
            }
        }

        public bool CheckMessagePresence(string message)
        {
            var expectedLabel = driver.FindElement(By.XPath($"//p[text()='{message}']"));
            return expectedLabel != null;
        }
    }
}