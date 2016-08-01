using System;
using AIMS.Tests.Common.PageLibrary.Pages;
using AIMS.Tests.Common.TestUtil;
using OpenQA.Selenium;

namespace AIMS.Tests.Common.PageLibrary.Base
{
    public class PageNavigation : PageBase
    {
        public static LoginPage LoadLoginPage(IWebDriver driver, string baseUrl, string pageTitle = null)
        {
            Log.Write(driver.Title);
            Log.Write(baseUrl);
            Log.Write(pageTitle);

            try
            {
                driver.Navigate().GoToUrl(baseUrl.TrimEnd(new[] { '/' }));
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message);
            }
            
            Log.Write("Open login page: " + baseUrl);
            return GetInstance<LoginPage>(driver, baseUrl, pageTitle);
        }

        public static TExpectedPage LoadUrl<TExpectedPage>(IWebDriver driver, string baseUrl, string pageTitle = null) where TExpectedPage : PageBase, new()
        {
            driver.Navigate().GoToUrl(baseUrl.TrimEnd(new[] { '/' }));
            Log.Write("Open URL: " + baseUrl);
            return GetInstance<TExpectedPage>(driver, baseUrl, pageTitle);
        }
    }
}