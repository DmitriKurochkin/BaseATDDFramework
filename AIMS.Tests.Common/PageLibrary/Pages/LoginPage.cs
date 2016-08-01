using System.Threading;
using AIMS.Tests.Common.PageLibrary.Base;
using AIMS.Tests.Common.TestUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AIMS.Tests.Common.PageLibrary.Pages
{
    public class LoginPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "email")]
        private readonly IWebElement _emailInput = null;

        [FindsBy(How = How.Id, Using = "password")]
        private readonly IWebElement _passwordInput = null;

        [FindsBy(How = How.Id, Using = "submit-login")]
        private readonly IWebElement _submitLogin = null;

        [FindsBy(How = How.XPath, Using = "//div[@ng-bind-html='message']")]
        private readonly IWebElement _errorMessagePane = null;
        
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private readonly IWebElement _rememberMeCheckBox = null;
        
        public OverviewMainPage LoginToPortal(string email, string pw)
        {
            _emailInput.ClearAndType(email);
            _passwordInput.ClearAndType(pw);
            _submitLogin.WaitAndClick("Submit login btn");
            Waiter.WaitUpTo(20000, () => !_submitLogin.IsPresent(), "until 'Submit login' btn is present");
            return GetInstance<OverviewMainPage>();
        }

        public static TExpectedPage LoadUrl<TExpectedPage>(IWebDriver driver, string baseUrl, string pageTitle = null) where TExpectedPage : PageBase, new()
        {
            driver.Navigate().GoToUrl(baseUrl.TrimEnd(new[] { '/' }));
            Log.Write("Open URL: " + baseUrl);
            return GetInstance<TExpectedPage>(driver, baseUrl, pageTitle);
        }

        public void EnterUserName(string userName)
        {
            _emailInput.ClearAndType(userName);
        }

        public void EnterUserPassword(string password)
        {
            _passwordInput.ClearAndType(password);   
        }

        public void ClickLoginButton()
        {
            _submitLogin.Click();
        }

        public DashBoardPage LoginButtonClick()
        {
            _submitLogin.Click();
            return GetInstance<DashBoardPage>();
        }

        public void HasUserNameOrPasswordFieldRedBorder()
        {
            _submitLogin.Click();
            Thread.Sleep(1000);
            var expectedCondition = _passwordInput.GetCssValue("border-color").Equals("rgb(228, 76, 76)") ||
                            _emailInput.GetCssValue("border-color").Equals("rgb(228, 76, 76)");
            Waiter.WaitUpTo(10000, () => expectedCondition, "until password or username border color will be rgb(228, 76, 76)");
        }

        public void CheckThatLoginErrorExists(string messageText)
        {
            Waiter.WaitUpTo(5000, () => _errorMessagePane.Text.Equals(messageText), string.Format("until error message text will be equals to {0}", messageText));
        }

        public void SetRememberMeCheckBox()
        {
            if (!_rememberMeCheckBox.Selected)
                _rememberMeCheckBox.Click("remember me checkbox");
            Assert.IsTrue(_rememberMeCheckBox.Selected, "remember me checkbox is not selected");
        }

        public bool RememberMeCheckBoxChecked()
        {
            return _rememberMeCheckBox.Selected;
        }
    }
}