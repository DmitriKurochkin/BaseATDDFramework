using System.Linq;
using AIMS.Tests.Common.PageLibrary.Pages;
using TechTalk.SpecFlow;

namespace AIMS.Tests.StepDefinitions
{
    [Binding]
    public class DashboardSteps : BrowserFeatureBase
    {
        [Then(@"""(.*)"" block will be present on dashboard page")]
        public void ThenBlockWillBePresentOnDashboardPage(string blockName)
        {
            CurrentPage.WaitForPageToLoad();
            CurrentPage.As<DashBoardPage>().DoesBlockWithDataPresent(blockName);
        }

        [Then(@"""(.*)"" block will have proper title on dashboard page")]
        public void ThenBlockWillHaveProperTitleOnDashboardPage(string blockName)
        {
            CurrentPage.WaitForPageToLoad();
            CurrentPage.As<DashBoardPage>().CheckBlockTitle(blockName);
        }

        [Then(@"Date intervals in ""(.*)"" block will be displayed correctly")]
        public void ThenDateIntervalsInBlockWillBeDisplayedCorrectly(string blockName)
        {
            ScenarioContext.Current.Add("block name", blockName);
            CurrentPage.As<DashBoardPage>().DoesDateIntervalsDisplaysCorrectlyByDefault(blockName);
        }

        [Then(@"Current date in ""(.*)"" block will be displayed correctly")]
        public void ThenCurrentDateInBlockWillBeDisplayedCorrectly(string blockName)
        {
            ScenarioContext.Current.Add("block name", blockName);
            CurrentPage.As<DashBoardPage>().DoesDateIntervalsDisplaysCorrectlyByDefault(blockName);
        }


        [Then(@"I can select default date boundary values from dropdown menu")]
        public void ThenICanSelectDefaultDateBoundaryValyesFromDropdownMenu(Table table)
        {
            var blockName = ScenarioContext.Current.Get<string>("block name");

            foreach (var date in table.Rows.Select(row => row["Date boundary values"]))
            {
                CurrentPage.As<DashBoardPage>().SelectDateBoundatyValuesFromDropDown(blockName, date);
            }
        }

        [Then(@"""().*"" block will be present on dashboard page")]
        public void ThenWarningsBlockWillBePresentOnDashboardPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}