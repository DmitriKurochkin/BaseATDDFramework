using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AIMS.Tests.Common.PageLibrary.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AIMS.Tests.Common.PageLibrary.Pages
{
    public class OverviewMainPage : PageBase
    {
        [FindsBy(How = How.XPath, Using = "//div[@ng-repeat='environment in environments']")]
        private readonly IList<IWebElement> _listOfEnvironments = null;

        [FindsBy(How = How.ClassName, Using = "icon-cog")]
        private readonly IWebElement _settingsIcon = null;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Log out')]")]
        private readonly IWebElement _logoutButton = null;

        public LoginPage LogoutFromPortal()
        {
            _settingsIcon.Click("");
            _logoutButton.Click("");
            return GetInstance<LoginPage>();
        }

        public IWebElement GetInvironmentXPath(string environmentName)
        {
            return Driver.FindElement(By.XPath("//a[contains(.,'" + environmentName + "')]"));
        }

        public DashBoardPage SelectEnvironmentOnOverviewPageByName(string envName)
        {
            var envLocator = GetInvironmentXPath(envName);
            envLocator.TryClick();

            return GetInstance<DashBoardPage>();
        }

        public DashBoardPage SelectEnvironmentAndGoByGotoEnvironmentLink(string envName)
        {
            foreach (var environment in _listOfEnvironments.Where(environment => environment.Text.Contains(envName)))
            {
                environment.FindElement(By.CssSelector(".btn.btn-link")).Click(string.Format("go to {0} environment", envName));
                break;
            }
            return GetInstance<DashBoardPage>();
        }

        public void DoesEnvironmentHaveChartsAndDataCount(string envName, string chartName)
        {
            var environment = GetEnvironMentOnOverviewPage(envName);
            Assert.IsTrue(environment.Text.Contains(chartName));
        }

        public void DoesEnvironmentHaveCounts(string envName)
        {
            var environment = GetEnvironMentOnOverviewPage(envName);

            var listOfCounts = environment.FindElements(By.CssSelector(".cut.ng-scope.ng-binding")).ToList();
            Assert.IsTrue(listOfCounts.Count.Equals(4));
        }

        public IWebElement GetEnvironMentOnOverviewPage(string envName)
        {
            return _listOfEnvironments.FirstOrDefault(environment => environment.Text.Contains(envName));
        }
    }
}