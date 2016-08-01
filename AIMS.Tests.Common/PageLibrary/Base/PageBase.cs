using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AIMS.Tests.Common.TestUtil;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AIMS.Tests.Common.PageLibrary.Base
{
    public abstract class PageBase
    {
        public IWebDriver Driver { get; set; }
        public string BaseUrl { get; set; }
        public virtual string DefaultTitle { get { return "AIMS for BizTalk"; } }

        protected TPage GetInstance<TPage>(IWebDriver driver = null, string expectedTitle = null) where TPage : PageBase, new()
        {
            return GetInstance<TPage>(driver ?? Driver, BaseUrl, expectedTitle);
        }

        protected TPage GetInstanceFromNewTab<TPage>(IWebDriver driver = null, string expectedTitle = null) where TPage : PageBase, new()
        {
            Waiter.WaitUpTo((int)new TimeSpan(0, 1, 0).TotalMilliseconds, () => Driver.WindowHandles.Count > 1, "open new tab");
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            return GetInstance<TPage>(driver ?? Driver, BaseUrl, expectedTitle);
        }

        public TPage GetInstanceFromFirstTab<TPage>(IWebDriver driver = null, string expectedTitle = null) where TPage : PageBase, new()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
            return GetInstance<TPage>(driver ?? Driver, BaseUrl, expectedTitle);
        }

        public TPage GotoLastTab<TPage>(string expectedTitle = null) where TPage : PageBase, new()
        {
            return GetInstanceFromNewTab<TPage>(Driver, expectedTitle);
        }

        protected static TPage GetInstance<TPage>(IWebDriver driver, string url, string expectedTitle = null) where TPage : PageBase, new()
        {
            TPage pageInstance = new TPage
            {
                Driver = driver,
                BaseUrl = url
            };

            PageFactory.InitElements(driver, pageInstance);
            pageInstance.WaitForPageToLoad();
            if (expectedTitle == null)
            {
                expectedTitle = pageInstance.DefaultTitle;
            }

            if (!string.IsNullOrEmpty(expectedTitle))
            {
                Waiter.WaitUpTo((int)new TimeSpan(0, 3, 0).TotalMilliseconds,
                        () => String.Compare(driver.Title, expectedTitle, StringComparison.OrdinalIgnoreCase) == 0,
                        string.Format("Page titles are not equal. Actual [ {0} ] expected [ {1} ] ", driver.Title, expectedTitle), 1000);
            }
            driver.Manage().Window.Maximize();

            return pageInstance;
        }

        /// <summary>
        /// Asserts that the current page is of the given type
        /// </summary>
        public bool Is<TPage>() where TPage : PageBase, new()
        {
            return (this is TPage);
        }

        //public IList<JavaScriptError> GetJsErrors()
        //{
        //    if (((RemoteWebDriver)Driver).Capabilities.BrowserName != "firefox")
        //        throw new Exception("JavaScript errors handling is supported for FireFox browser only.");

        //    var jsErrorList = JavaScriptError.ReadErrors(Driver);
        //    Log.Write("JavaScript error count: " + jsErrorList.Count);
        //    return jsErrorList;
        //}

        /// <summary>
        /// In-line cast to the given page type
        /// </summary>
        public TPage As<TPage>() where TPage : PageBase, new()
        {
            return (TPage)this;
        }

        /// <summary>
        /// Close current page 
        /// </summary>
        public void Close()
        {
            Driver.Close();
        }

        /// <summary>
        /// Refresh page 
        /// </summary>
        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
            WaitForPageToLoad();
        }

        public void WaitForPageToLoad()
        {
            new ActionAttempter
            {
                Action = (a) => IsPageLoad(),
                ListOfIgnoredExceptionsDuringAttempt = new List<Type> { typeof(WebDriverTimeoutException) }
            }.Run();
            //Thread.Sleep(5000);TODO: check this
        }

        public bool IsPageLoad()
        {
            var timeout = new TimeSpan(0, 3, 0);
            WebDriverWait wait = new WebDriverWait(Driver, timeout);
            IJavaScriptExecutor javascript = Driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new Exception("Driver must support javascript execution");

            wait.Until(delegate
            {
                try
                {
                    string readyState = javascript.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    throw new Exception(e.Message.ToLower().Contains("unable to get browser").ToString());
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    throw new Exception(e.Message.ToLower().Contains("unable to connect").ToString());
                }
                catch (Exception e)
                {
                    //Something went wrong
                    throw new Exception(e.Message);
                }
            });
            return true;
        }

        public static IWebElement GetDisplayedElement(By locator, IWebDriver driver)
        {
            try
            {
                var findElements = driver.FindElements(locator);
                var element = findElements.FirstOrDefault(e => e.Displayed);
                return element;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element by locator [" + locator + "] is not displayed!");
                Console.WriteLine(e);
                return null;
            }
        }

        public bool ContainsText(string text)
        {
            try
            {
                Driver.FindElement(By.XPath(".//*[contains(text(), '" + text + "')]"));
                Log.Write(string.Format("Text [ {0} ] has been found on the page", text));
            }
            catch (WebDriverException)
            {
                Log.Write(string.Format("Text [ {0} ] has not been found on the page", text));
                return false;
            }
            return true;
        }

        protected void SetImplicitlyWait(TimeSpan timeout)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(timeout);
        }

        public List<IWebElement> GetAllLinks()
        {
            try
            {
                var findElements = Driver.FindElements(By.TagName("a"));

                return findElements.ToList();
            }
            catch (NoSuchElementException)
            {
                Log.Write("The page does not have links");
                return null;
            }
        }
    }
}