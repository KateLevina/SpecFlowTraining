using OpenQA.Selenium;

namespace SpecFlowSchool.Specs.Pages
{
    internal class BaseCategoryPage : PageBase
    {
        private const string OriginalWindowKey = "OriginalWindow";
        protected ScenarioContext _scenarioContext;
        private string clickableDivForSection(string sectionName) => $"//span[text()='{sectionName}']//ancestor::li[contains(@class, 'btn-light')]";
        protected string buttonByTitle(string buttonTitle) => $"//button[text()='{buttonTitle}']";
        protected string footer => $"//footer";

        public BaseCategoryPage(PageContext context, ScenarioContext scenarioContext) : base(context)
        {
            this._scenarioContext = scenarioContext;
        }

        public void HideFooter()
        {
            ExecuteScript("arguments[0].style.visibility='hidden'", GetElement(By.XPath(footer)));
        }

        public void SelectSection(string sectionName)
        {
            var section = GetElement(By.XPath(clickableDivForSection(sectionName)));
            GetBuilder().MoveToElement(section).Click().Perform();
        }

        public bool CheckMessagePresence(string message)
        {
            bool messageIsPresent;
            try
            {
                messageIsPresent = !string.IsNullOrEmpty(GetTextByXPath($"//*[text()='{message}']"));
            }
            finally
            {
                SwitchToOriginalWindow();
            }
            return messageIsPresent;
        }

        private void SwitchToNewTabOrWindow(string originalWindow)
        {
            _scenarioContext[OriginalWindowKey] = originalWindow;
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
            if (_scenarioContext.ContainsKey(OriginalWindowKey))
            {
                if (_scenarioContext[OriginalWindowKey].ToString() != Context.Driver.CurrentWindowHandle)
                {
                    foreach (string window in Context.Driver.WindowHandles)
                    {
                        if (window == _scenarioContext[OriginalWindowKey].ToString())
                        {
                            Context.Driver.SwitchTo().Window(window);
                            break;
                        }
                    }
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
                case "New Tab":
                case "New Window":
                    btn.Click();
                    SwitchToNewTabOrWindow(originalWindowHandle);
                    break;
                case "Right Click Me":
                    // right click is not performing correctly with our default FindElement with scroll.
                    // initialize it finding without scroll. 
                    btn = Context.Driver.FindElement(By.XPath(buttonByTitle(btnTitle)));
                    GetBuilder().ContextClick(btn).Perform();
                    break;
                default:
                    btn.Click();
                    break;
            }
        }
    }
}
