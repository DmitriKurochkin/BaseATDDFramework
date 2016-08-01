using TechTalk.SpecFlow;

namespace AIMS.Tests
{
    [Binding]
    public class SpecflowHooksFeatureBase : BrowserFeatureBase
    {
        private BrowserType _browserForTest = BrowserType.Chrome;

        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioContext.Current["browserForTest"] = _browserForTest;
            CurrentDriver = BrowserTestSetup(_browserForTest);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BrowserTestTeardown(CurrentDriver);
        }
    }
}