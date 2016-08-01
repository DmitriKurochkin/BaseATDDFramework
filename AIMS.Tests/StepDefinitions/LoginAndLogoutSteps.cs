using System.Configuration;
using AIMS.Tests.Common.PageLibrary.Base;
using AIMS.Tests.Common.PageLibrary.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AIMS.Tests.StepDefinitions
{
    [Binding]
    public class LoginAndLogoutSteps : BrowserFeatureBase
    {
        private static readonly string UserName = ConfigurationManager.AppSettings["adminUserMailBox"];
        private static readonly string Password = ConfigurationManager.AppSettings["adminUserPw"];

        private static readonly string WrongUserName = "1" + ConfigurationManager.AppSettings["adminUserMailBox"];
        private static readonly string WronUserPassword = "1" + ConfigurationManager.AppSettings["adminUserPw"];

        private static readonly string BaseUrl = ConfigurationManager.AppSettings["baseUrl"];
        
        [Given(@"I have not entered user password\(empty step\)")]
        [Given(@"I have not entered username\(empty step\)")]
        [When(@"I will try to login to portal\(empty step\)")]
        public void WhenIWillTryToLoginToPortal()
        {
        }

        [Given(@"I open login page")]
        [Then(@"I open login page")]
        public void GivenIOpenLoginPage()
        {
            CurrentPage = PageNavigation.LoadLoginPage(CurrentDriver, BaseUrl);
        }

        [Given(@"I login to portal")]
        [When(@"I login to portal")]
        public void GivenILoginToPortal()
        {
            CurrentPage = CurrentPage.As<LoginPage>().LoginToPortal(UserName, Password);
        }

        [When(@"I will logout from portal")]
        public void WhenIWillLogoutFromPortal()
        {
            CurrentPage = CurrentPage.As<OverviewMainPage>().LogoutFromPortal();
        }

        [Given(@"I will login to portal")]
        public void GivenIWillLoginToPortal()
        {
            CurrentPage = CurrentPage.As<LoginPage>().LoginButtonClick();
        }


        [Then(@"I will get login page")]
        public void ThenIWillGetLoginPage()
        {
            Assert.IsTrue(CurrentPage.Is<LoginPage>());
        }

        [Given(@"I have enter right username")]
        public void GivenIHaveEnterRightUsername()
        {
            CurrentPage.As<LoginPage>().EnterUserName(UserName);
        }

        [Given(@"I have entered wrong username")]
        public void GivenIHaveEnteredWrongUsername()
        {
            CurrentPage.As<LoginPage>().EnterUserName(WrongUserName);
        }

        [Given(@"I have enter wrong password")]
        public void GivenIHaveEnterWrongPassword()
        {
            CurrentPage.As<LoginPage>().EnterUserPassword(WronUserPassword);
        }

        [Given(@"I have enter right user password")]
        public void GivenIHaveEnterRightUserPassword()
        {
            CurrentPage.As<LoginPage>().EnterUserPassword(Password);
        }

        [Then(@"I will get tooltip with warning if I click login button")]
        public void ThenIWillGetTooltipWithWarning()
        {
            CurrentPage.As<LoginPage>().HasUserNameOrPasswordFieldRedBorder();
        }

        [When(@"I try to login to portal")]
        [Given(@"I try to login to portal")]
        public void WhenITryToLoginToPortal()
        {
            CurrentPage.As<LoginPage>().ClickLoginButton();
        }

        [Then(@"I will get login page error message ""(.*)""")]
        public void ThenIWillGetLoginPageErrorMessage(string messageText)
        {
            CurrentPage.As<LoginPage>().CheckThatLoginErrorExists(messageText);
        }

        [Given(@"I will set 'Remember me' checkbox")]
        public void GivenIWillSetCheckbox()
        {
            CurrentPage.As<LoginPage>().SetRememberMeCheckBox();
        }

        [Then(@"I will restart browser")]
        public void ThenIWillRestartBrowser()
        {
            RestartBrowser();
        }
    }
}