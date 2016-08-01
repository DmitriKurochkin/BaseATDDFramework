using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AIMS.Tests.Common.PageLibrary.Base;
using AIMS.Tests.Common.TestUtil;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AIMS.Tests.Common.PageLibrary.Pages
{
    public class DashBoardPage : PageBase
    {
        [FindsBy(How = How.ClassName, Using = "panel panel-default panel-biztalk")]
        private readonly IList<IWebElement> _listOfPanesOnDashBoard = null;

        [FindsBy(How = How.XPath, Using = "//h3[@title='Warnings']")]
        private readonly IWebElement _warningsTitle = null;

        [FindsBy(How = How.XPath, Using = "//h3[@title='Errors']")]
        private readonly IWebElement _errorsTitle = null;

        [FindsBy(How = How.XPath, Using = "//h3[@title='Daily APDEX SCORE']")]
        private readonly IWebElement _dailyApdexScoreTitle= null;

        //
        
        [FindsBy(How = How.XPath, Using = "//div[@data-col-number='0']")]
        private readonly IWebElement _firstColumnOfBlocks= null;

        [FindsBy(How = How.XPath, Using = "//div[@data-col-number='1']")]
        private readonly IWebElement _secondColumnOfBlocks = null;

        [FindsBy(How = How.XPath, Using = "//div[@data-col-number='2']")]
        private readonly IWebElement _thirdColumnOfBlocks = null;


        /// <summary>
        /// List of all blocks on dashboard page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".panel.panel-default.report-block")]
        private readonly IList<IWebElement> _listOfBlocks = null;
        

        [FindsBy(How = How.XPath, Using = "//div[@id='block-1-1']")]
        private readonly IWebElement _warningsBlock = null;

        [FindsBy(How = How.XPath, Using = "//div[@id='block-1-7']")]
        private readonly IWebElement _avgMessageDelayBlock = null;

        [FindsBy(How = How.XPath, Using = "//div[@id='block-6-8']")]
        private readonly IWebElement __topGroupsByMessageDelayBlock = null;

        private readonly string _periodValueDropDown = ".//button[@period-value='block.data.periodValue']";

        private const string DefaultDropDownDatePeriodCount = "Past 7 days vs Preceding 7 days ";

        private const string DefaultDropDownDate = "Past 7 days ";

        //public static string DefDropDownDate
        //{
        //    get { return DefaultDropDownDate; }
        //}

        public static string ToMonthName(DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public void CheckBlockTitle(string blockName)
        {
            var blockTitle = string.Format("//h3[@title='{0}']", blockName);
            Waiter.WaitUpTo(20000, () => Driver.FindElement(By.XPath(blockTitle)).IsPresent(), "");
        }

        public void DoesBlockWithDataPresent(string blockName)
        {
            CheckBlockTitle(blockName);

            var currentBlock = _listOfBlocks.FirstOrDefault(block => block.Text.Contains(blockName));

            Waiter.WaitUpTo(20000, () => currentBlock != null && currentBlock.FindElement(By.
                XPath(_periodValueDropDown)).
                IsClickable(), "");

            var rightBlockTitleCondition = currentBlock != null &&
                                           (currentBlock.FindElement(By.XPath(_periodValueDropDown)).
                                               Text.Equals(DefaultDropDownDatePeriodCount) || 
                                               currentBlock.FindElement(By.XPath(_periodValueDropDown)).Text.Equals(DefaultDropDownDate));

            Waiter.WaitUpTo(20000, () => rightBlockTitleCondition, "");
        }

        public void DoesDateIntervalsDisplaysCorrectlyByDefault(string blockName)
        {
            //Done TODO remove _warningBlock and use _listOfBlocks.Select(blockName) Done
            var currentBlock = SelectBlockOnDashboardPage(blockName);

            var rightBlockTitleCondition = currentBlock != null &&
                                           (currentBlock.FindElement(By.XPath(_periodValueDropDown)).
                                               Text.Equals(DefaultDropDownDatePeriodCount) ||
                                               currentBlock.FindElement(By.XPath(_periodValueDropDown)).Text.Equals(DefaultDropDownDate));

            Waiter.WaitUpTo(20000, () => rightBlockTitleCondition, "");
            //Waiter.WaitUpTo(10000, () => currentBlock.FindElement(By.XPath(_periodValueDropDown)).
                //Text.Equals(DefaultDropDownDatePeriodCount), "");
        }

        public void SelectDateBoundatyValuesFromDropDown(string blockName, string date)
        {
            //var currentBlock = _listOfBlocks.FirstOrDefault(block => block.Text.Contains(blockName));
            var currentBlock = SelectBlockOnDashboardPage(blockName);

            if (currentBlock != null)
                currentBlock.FindElement(By.XPath(_periodValueDropDown)).Click();

            var dropDownMenuLocator = string.Format("//span[contains(.,'{0}')]", date);

            Driver.FindElement(By.XPath(dropDownMenuLocator)).Click();

            //var currentDay = DateTime.Now.Day;
            //var currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            
            //var currentDayAndMonth = currentDay + " " + currentMonth;

            var isDateSelected =
                currentBlock != null && currentBlock.FindElement(By.
                XPath(string.Format("//button[contains(.,'{0}')]", date))).Displayed;

            Waiter.WaitUpTo(10000, () => isDateSelected, "");
        }

        public IWebElement SelectBlockOnDashboardPage(string blockName)
        {
            return _listOfBlocks.FirstOrDefault(block => block.Text.Contains(blockName));
        }
    }
}