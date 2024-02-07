using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowSchool.Specs.Pages
{
    internal class BaseCategoryPage : PageBase
    {
        private string clickableDivForSection(string sectionName) => $"//*[text()='{sectionName}']//ancestor::*[contains(@class, 'btn-light')]";
        protected string buttonByTitle(string buttonTitle) => $"//button[text()='{buttonTitle}']";

        public BaseCategoryPage(PageContext context) : base(context)
        {
        }

        public void SelectSection(string sectionName)
        {
            var section = GetElement(By.XPath(clickableDivForSection(sectionName)));
            new Actions(Context.Driver).MoveToElement(section);
            HideAds();
            section.Click();
        }

        public bool CheckMessagePresence(string message)
        {
            var expectedLabel = GetElement(By.XPath($"//*[text()='{message}']"));
            return expectedLabel != null;

        }

        private void SwitchToNewTabOrWindow(string originalWindow)
        {
            //Loop through until we find a new window handle
            foreach (string window in Context.Driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    Context.Driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public void InteractWithButtonAccordingToItsType(string btnTitle)
        {
            Actions actions = new Actions(Context.Driver);
            var btn = GetElement(By.XPath(buttonByTitle(btnTitle)));

            string originalWindowHandle = Context.Driver.CurrentWindowHandle;
            switch (btnTitle)
            {
                case "Double Click Me":
                    actions.DoubleClick(btn).Perform();
                    break;
                case "Right Click Me":
                    actions.ContextClick(btn).Perform();
                    break;
                case "New Tab":
                case "New Window":
                    btn.Click();
                    SwitchToNewTabOrWindow(originalWindowHandle);
                    break;
                default:
                    btn.Click();
                    break;
            }
        }
    }
}
