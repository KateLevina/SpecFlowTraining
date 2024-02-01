using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
namespace SpecFlowSchool.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer container;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = container.Resolve<IWebDriver>();
            if(driver != null)
            {
                driver.Quit();
            }
        }
    }
}