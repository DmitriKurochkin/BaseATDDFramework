﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AIMS.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DashboardFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Dashboard.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Dashboard", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Dashboard")))
            {
                AIMS.Tests.Features.DashboardFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line 4
 testRunner.Given("I open login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
 testRunner.And("I login to portal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.And("I select \"Test (test)\" environment using it name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        public virtual void Check_Blocks_On_Dashboard_Page(string blockname, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_blocks_on_dashboard_page", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 9
 testRunner.Then(string.Format("{0} block will be present on dashboard page", blockname), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_blocks_on_dashboard_page: Warnings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Warnings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:blockname", "Warnings")]
        public virtual void Check_Blocks_On_Dashboard_Page_Warnings()
        {
            this.Check_Blocks_On_Dashboard_Page("Warnings", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_blocks_on_dashboard_page: Errors")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Errors")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:blockname", "Errors")]
        public virtual void Check_Blocks_On_Dashboard_Page_Errors()
        {
            this.Check_Blocks_On_Dashboard_Page("Errors", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_blocks_on_dashboard_page: Avg. message delay")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Avg. message delay")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:blockname", "Avg. message delay")]
        public virtual void Check_Blocks_On_Dashboard_Page_Avg_MessageDelay()
        {
            this.Check_Blocks_On_Dashboard_Page("Avg. message delay", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_blocks_on_dashboard_page: Message count")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Message count")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:blockname", "Message count")]
        public virtual void Check_Blocks_On_Dashboard_Page_MessageCount()
        {
            this.Check_Blocks_On_Dashboard_Page("Message count", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_warnings_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_Warnings_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_warnings_block_on_dashboard_page", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 20
 testRunner.Then("\"Warnings\" block will be present on dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_that_date_intervals_in_warnings_block_displays_correctly_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_That_Date_Intervals_In_Warnings_Block_Displays_Correctly_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_that_date_intervals_in_warnings_block_displays_correctly_on_dashboard_page", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 23
 testRunner.Then("Date intervals in \"Warnings\" block will be displayed correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date boundary values"});
            table1.AddRow(new string[] {
                        "Today vs Yesterday"});
            table1.AddRow(new string[] {
                        "Past 7 days vs Preceding 7 days"});
            table1.AddRow(new string[] {
                        "Past 31 days vs Preceding 31 days"});
            table1.AddRow(new string[] {
                        "Current week vs Previous week"});
            table1.AddRow(new string[] {
                        "Current month vs Previous month"});
#line 24
 testRunner.And("I can select default date boundary values from dropdown menu", ((string)(null)), table1, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_Errors_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_Errors_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_Errors_block_on_dashboard_page", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 33
 testRunner.Then("\"Errors\" block will be present on dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_that_date_intervals_in_errors_block_displays_correctly_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_That_Date_Intervals_In_Errors_Block_Displays_Correctly_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_that_date_intervals_in_errors_block_displays_correctly_on_dashboard_page", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 36
 testRunner.Then("Date intervals in \"Errors\" block will be displayed correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date boundary values"});
            table2.AddRow(new string[] {
                        "Today vs Yesterday"});
            table2.AddRow(new string[] {
                        "Past 7 days vs Preceding 7 days"});
            table2.AddRow(new string[] {
                        "Past 31 days vs Preceding 31 days"});
            table2.AddRow(new string[] {
                        "Current week vs Previous week"});
            table2.AddRow(new string[] {
                        "Current month vs Previous month"});
#line 37
 testRunner.And("I can select default date boundary values from dropdown menu", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_Avg.messageDelay_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_Avg_MessageDelay_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_Avg.messageDelay_block_on_dashboard_page", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 47
 testRunner.Then("\"Avg. message delay\" block will be present on dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_that_date_intervals_in_avg_message_delay_block_displays_correctly_on_dashbo" +
            "ard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_That_Date_Intervals_In_Avg_Message_Delay_Block_Displays_Correctly_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_that_date_intervals_in_avg_message_delay_block_displays_correctly_on_dashbo" +
                    "ard_page", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 50
 testRunner.Then("Date intervals in \"Avg. message delay\" block will be displayed correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date boundary values"});
            table3.AddRow(new string[] {
                        "Today vs Yesterday"});
            table3.AddRow(new string[] {
                        "Past 7 days vs Preceding 7 days"});
            table3.AddRow(new string[] {
                        "Past 31 days vs Preceding 31 days"});
            table3.AddRow(new string[] {
                        "Current week vs Previous week"});
            table3.AddRow(new string[] {
                        "Current month vs Previous month"});
#line 51
 testRunner.And("I can select default date boundary values from dropdown menu", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_MessageCount_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_MessageCount_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_MessageCount_block_on_dashboard_page", ((string[])(null)));
#line 59
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 60
 testRunner.Then("\"Message count\" block will be present on dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_that_date_intervals_in_message_count_block_displays_correctly_on_dashboard_" +
            "page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_That_Date_Intervals_In_Message_Count_Block_Displays_Correctly_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_that_date_intervals_in_message_count_block_displays_correctly_on_dashboard_" +
                    "page", ((string[])(null)));
#line 62
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 63
 testRunner.Then("Date intervals in \"Message count\" block will be displayed correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date boundary values"});
            table4.AddRow(new string[] {
                        "Today vs Yesterday"});
            table4.AddRow(new string[] {
                        "Past 7 days vs Preceding 7 days"});
            table4.AddRow(new string[] {
                        "Past 31 days vs Preceding 31 days"});
            table4.AddRow(new string[] {
                        "Current week vs Previous week"});
            table4.AddRow(new string[] {
                        "Current month vs Previous month"});
#line 64
 testRunner.And("I can select default date boundary values from dropdown menu", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_dailyAPDEXSCORE_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_DailyAPDEXSCORE_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_dailyAPDEXSCORE_block_on_dashboard_page", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 73
 testRunner.Then("\"Daily APDEX SCORE\" block will have proper title on dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_ActivityAndChanges_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_ActivityAndChanges_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_ActivityAndChanges_block_on_dashboard_page", ((string[])(null)));
#line 75
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 76
 testRunner.Then("\"Activity & changes\" block will have proper title on dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
 testRunner.And("Current date in \"Activity & changes\" block will be displayed correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date boundary values"});
            table5.AddRow(new string[] {
                        "Today"});
            table5.AddRow(new string[] {
                        "Past 7 days"});
            table5.AddRow(new string[] {
                        "Past 31 days"});
            table5.AddRow(new string[] {
                        "Current week"});
            table5.AddRow(new string[] {
                        "Current month"});
#line 78
 testRunner.And("I can select default date boundary values from dropdown menu", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_TopGroupsByMessageCountChange_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_TopGroupsByMessageCountChange_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_TopGroupsByMessageCountChange_block_on_dashboard_page", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 87
 testRunner.Then("\"Top groups by Message count change\" block will be present on dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_that_date_intervals_in_TopGroupsMyMessageVolumeChange_block_displays_correc" +
            "tly_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_That_Date_Intervals_In_TopGroupsMyMessageVolumeChange_Block_Displays_Correctly_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_that_date_intervals_in_TopGroupsMyMessageVolumeChange_block_displays_correc" +
                    "tly_on_dashboard_page", ((string[])(null)));
#line 89
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 90
 testRunner.Then("Date intervals in \"Top groups by Message count change\" block will be displayed co" +
                    "rrectly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date boundary values"});
            table6.AddRow(new string[] {
                        "Today vs Yesterday"});
            table6.AddRow(new string[] {
                        "Past 7 days vs Preceding 7 days"});
            table6.AddRow(new string[] {
                        "Past 31 days vs Preceding 31 days"});
            table6.AddRow(new string[] {
                        "Current week vs Previous week"});
            table6.AddRow(new string[] {
                        "Current month vs Previous month"});
#line 91
 testRunner.And("I can select default date boundary values from dropdown menu", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_TopGroupsByMessageDelay_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_TopGroupsByMessageDelay_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_TopGroupsByMessageDelay_block_on_dashboard_page", ((string[])(null)));
#line 99
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check_PerformanceParametersOfBizTalk_block_on_dashboard_page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Dashboard")]
        public virtual void Check_PerformanceParametersOfBizTalk_Block_On_Dashboard_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check_PerformanceParametersOfBizTalk_block_on_dashboard_page", ((string[])(null)));
#line 102
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 103
 testRunner.Then("\"Performance parameters of BizTalk\" block will have proper title on dashboard pag" +
                    "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion