using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowSchool.Specs.Pages
{
    internal class BaseCategoryPage : PageBase
    {
        private string clickableDivForSection(string sectionName) => $"//*[text()='{sectionName}']//ancestor::*[contains(@class, 'btn-light')]";
        protected string buttonByTitle(string buttonTitle) => $"//button[text()='{buttonTitle}']";
        protected string footer => $"//footer";

        private string _originalWindow;
        public BaseCategoryPage(PageContext context) : base(context)
        {
        }

        public void HideFooter()
        {
            ExecuteScript("arguments[0].style.visibility='hidden'", GetElement(By.XPath(footer)));
        }

        public void SelectSection(string sectionName)
        {
            var section = GetElement(By.XPath(clickableDivForSection(sectionName)));
            GetBuilder().MoveToElement(section);
            HideAds();
            section.Click();
        }

        public bool CheckMessagePresence(string message)
        {
            var expectedLabel = GetElement(By.XPath($"//*[text()='{message}']"));
            SwitchToOriginalWindow();
            return expectedLabel != null;

        }

        private void SwitchToNewTabOrWindow(string originalWindow)
        {
            _originalWindow = originalWindow;
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

        private void SwitchToOriginalWindow()
        {
            //Loop through until we find a new window handle
            foreach (string window in Context.Driver.WindowHandles)
            {
                if (window == _originalWindow)
                {
                    Context.Driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public void InteractWithButtonAccordingToItsType(string btnTitle)
        {
            var btn = GetElement(By.XPath(buttonByTitle(btnTitle)));

            string originalWindowHandle = Context.Driver.CurrentWindowHandle;
            switch (btnTitle)
            {
                case "Double Click Me":
                    GetBuilder().DoubleClick(btn).Perform();
                    break;
                case "Right Click Me":
                    GetBuilder().ContextClick(btn).Perform();
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
