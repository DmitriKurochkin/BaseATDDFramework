using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using AIMS.Tests.Common.TestUtil;
using AIMS.Tests.Common.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using TechTalk.SpecFlow;

namespace AIMS.Tests.Common
{
    public class Context : Steps
    {
        public enum BrowserType
        {
            InternetExplorer,
            FireFox,
            Chrome,
            ChromeMobile,
            Phantom,
            BrowserStack
        }

        /// <summary>
        /// Execute browser
        /// </summary>
        /// <param name="browser">Browser type</param>
        /// <returns>Driver for browser</returns>
        public IWebDriver BrowserTestSetup(BrowserType browser)
        {
            IWebDriver webDriver;
            try
            {
                switch (browser)
                {
                    case BrowserType.FireFox:
                        Log.Write("Running FireFox");
                        var profile = new FirefoxProfile();
                        webDriver = new FirefoxDriver(profile);
                        break;
                    case BrowserType.Chrome:
                        Log.Write("Running Google Chrome");
                        var options = new ChromeOptions();
                        options.AddArguments("no-sandbox");
                        options.AddArguments("always-authorize-plugins");
                        options.AddArguments("disable-web-security");
                        options.AddArguments("disable-improved-download-protection");
                        webDriver = new ChromeDriver(@"C:\Users\DKurochkin\Documents", options);
                        webDriver.Navigate().Forward();
                        break;
                    case BrowserType.InternetExplorer:
                        Log.Write("Running Internet Explorer");
                        webDriver = new InternetExplorerDriver();
                        var eventFiringWebDriver = new EventFiringWebDriver(webDriver);
                        webDriver = eventFiringWebDriver;
                        break;
                    default:
                        throw new WarningException("Wrong browser type.");
                }
            }
            catch (DriverServiceNotFoundException)
            {
                throw;
            }
            catch (WebDriverException e)
            {
                Log.Write("Could not execute browser", e);
                webDriver = BrowserTestSetup(browser);
            }

            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMinutes(3));
            webDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromMinutes(3));
            webDriver.Manage().Window.Maximize();
            return webDriver;
        }

        /// <summary>
        /// Quit from browser 
        /// </summary>
        public void BrowserTestTeardown(IWebDriver webDriver)
        {
            if (ScenarioContext.Current.TestError != null)
            {
                // get save path and delete all not allow characters
                string saveTitle = ScenarioContext.Current.ScenarioInfo.Title;
                char[] charInvalidFileChars = Path.GetInvalidFileNameChars();
                saveTitle = charInvalidFileChars.Aggregate(saveTitle, (current, charInvalid) => current.Replace(charInvalid, '_'));

                // do not do screen-shot if it is already exist
                if (!ScenarioContext.Current.TestError.Message.Contains("Screen-shot"))
                {
                    ScreenShooter.TakeBrowserScreenShot(saveTitle);
                    ScreenShooter.TakeDesktopScreenShot(saveTitle);
                }
            }
            if (webDriver != null)
            {
                webDriver.Dispose();
            }
        }
    }
}