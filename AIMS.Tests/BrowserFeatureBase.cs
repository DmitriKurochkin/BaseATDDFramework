using System;
using System.Threading;
using AIMS.Tests.Common;
using AIMS.Tests.Common.PageLibrary.Base;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AIMS.Tests
{
    public class BrowserFeatureBase : Context
    {
        private readonly TimeSpan _sleepResetBrowser = new TimeSpan(0, 0, 0, 5);

        protected IWebDriver CurrentDriver
        {
            get { return (IWebDriver)ScenarioContext.Current["CurrentDriver"]; }
            set { ScenarioContext.Current["CurrentDriver"] = value; }
        }

        protected PageBase CurrentPage
        {
            get { return (PageBase)ScenarioContext.Current["CurrentPage"]; }
            set { ScenarioContext.Current["CurrentPage"] = value; }
        }

        protected byte[] FileContent
        {
            get { return (byte[])ScenarioContext.Current["FileContent"]; }
            set { ScenarioContext.Current["FileContent"] = value; }
        }

        public void RestartBrowser()
        {
            BrowserTestTeardown(CurrentDriver);
            Thread.Sleep(_sleepResetBrowser);
            CurrentDriver = BrowserTestSetup((BrowserType)ScenarioContext.Current["browserForTest"]);
        }
    }
}