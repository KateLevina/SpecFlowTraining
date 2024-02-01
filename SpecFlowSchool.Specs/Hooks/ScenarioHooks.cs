using BoDi;

namespace SpecFlowSchool.Specs.Hooks
{
    using SpecFlowSchool.Specs.Pages;

    [Binding]
    public class ScenarioHooks
    {
        private readonly IObjectContainer objectContainer;

        public ScenarioHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.objectContainer.RegisterInstanceAs(new PageContext(TestRunContext.Driver));
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}