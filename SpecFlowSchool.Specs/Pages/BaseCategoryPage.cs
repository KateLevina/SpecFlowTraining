﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowSchool.Specs.Pages
{
    internal class BaseCategoryPage : PageBase
    {
        private string _originalWindow = "";
        private string clickableDivForSection(string sectionName) => $"//span[text()='{sectionName}']//ancestor::li[contains(@class, 'btn-light')]";
        protected string buttonByTitle(string buttonTitle) => $"//button[text()='{buttonTitle}']";
        protected string footer => $"//footer";

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
            GetBuilder().MoveToElement(section).Click().Perform();
        }

        public bool CheckMessagePresence(string message)
        {
            IWebElement expectedLabel;
            try
            {
                expectedLabel = GetElement(By.XPath($"//*[text()='{message}']"));
            }
            finally
            {
                SwitchToOriginalWindow();
            }
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
            if (_originalWindow != Context.Driver.CurrentWindowHandle)
            {
                foreach (string window in Context.Driver.WindowHandles)
                {
                    if (window == _originalWindow)
                    {
                        Context.Driver.SwitchTo().Window(window);
                        break;
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
