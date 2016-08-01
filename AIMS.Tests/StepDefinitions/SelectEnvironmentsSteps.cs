using System.Linq;
using AIMS.Tests.Common.PageLibrary.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AIMS.Tests.StepDefinitions
{
    [Binding]
    public class SelectEnvironmentsSteps : BrowserFeatureBase
    {
        [Given(@"I select ""(.*)"" environment using it name")]
        [When(@"I select ""(.*)"" environment using it name")]
        public void WhenISelectEnvironment(string environmentName)
        {
            CurrentPage = CurrentPage.As<OverviewMainPage>().SelectEnvironmentOnOverviewPageByName(environmentName);
            CurrentPage.WaitForPageToLoad();
        }

        /// <summary>
        /// The page titles are simirlary at all pages so there is one way to check proper page: page url will
        /// contain environment name.
        /// This method get environment name from braces if exists or replace whitespaces if exists to "-".
        /// </summary>
        /// <returns></returns>
        [Then(@"I will get dashboard page for ""(.*)"" environment")]
        public void ThenIWillGetDashboardPageForEnvironment(string envName)
        {
            if (envName.Contains("("))
            {
                int index;
                envName = envName.Substring(index = 1 + envName.IndexOf('('),
                                envName.IndexOf(')') - index).ToLower();
            }
            else
            {
                envName = envName.Replace(" ", "-").ToLower();
            }
            
            Assert.IsTrue(CurrentDriver.Url.Contains(envName));
            Assert.IsTrue(CurrentPage.IsPageLoad());
        }

        [When(@"I select ""(.*)"" environment using 'go to environment' link")]
        public void WhenISelectEnvironmentUsingLink(string envName)
        {
            CurrentPage = CurrentPage.As<OverviewMainPage>().SelectEnvironmentAndGoByGotoEnvironmentLink(envName);
        }

        [Then(@"""(.*)"" environment will have charts")]
        public void ThenEnvironmentWillHaveCharts(string envName, Table table)
        {
            ScenarioContext.Current.Add("environment", envName);

            foreach (var chart in table.Rows.Select(row => row["Chart name"]))
            {
                CurrentPage.As<OverviewMainPage>().DoesEnvironmentHaveChartsAndDataCount(envName, chart);
            }
        }

        [Then(@"These charts will have counts")]
        public void ThenTheseChartsWillHaveCounts()
        {
            var env = ScenarioContext.Current.Get<string>("environment");
            CurrentPage.As<OverviewMainPage>().DoesEnvironmentHaveCounts(env);
        }
    }
}