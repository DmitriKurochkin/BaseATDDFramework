using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using AIMS.Tests.Common.TestUtil;
using AIMS.Tests.Common.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AIMS.Tests.Common.PageLibrary.Base
{
    public static class WebElementExtentions
    {
        public static IWebElement GetParentElement(this IWebElement el)
        {
            return el.FindElement(By.XPath(".."));
        }

        public static void ClearAndType(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
            Log.Write(string.Format("Type text [ {0} ] to field [ {1} ]", value, element.Text));
            Thread.Sleep(100);
        }

        public static void ClearAndType(this IWebElement element, string value, string description)
        {
            element.Clear();
            element.SendKeys(value);
            Log.Write(string.Format("Type text [ {0} ] to field [ {1} ]", value, description));
            Thread.Sleep(100);
        }

        public static TWebObject GetWebElementInstance<TWebObject>(this IWebElement element) where TWebObject : new()
        {
            if (!element.IsPresent())
            {
                Waiter.WaitUpTo(10000, element.IsPresent, "custom web-top object will be displayed.");
            }

            var webElementInstance = new TWebObject();

            PageFactory.InitElements(element, webElementInstance);
            return webElementInstance;
        }

        public static bool TryClick(this IWebElement element)
        {
            try
            {
                element.Click();
                return true;
            }
            catch (ElementNotVisibleException)
            {
            }
            catch (NullReferenceException)
            {
            }
            catch (NoSuchElementException)
            {
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (InvalidOperationException)
            {
            }
            catch (WebDriverException)
            {
            }
            catch (TargetInvocationException)
            {
            }
            return false;
        }

        public static void WaitAndClick(this IWebElement element, string elementDescription = "")
        {
            Waiter.WaitUpTo(10000, element.TryClick, string.Format("Can't click on element '{0}'", elementDescription));
        }

        public static TWebObject GetWebElementInstance<TWebObject>(this IList<IWebElement> elements) where TWebObject : new()
        {
            foreach (var webElement in elements)
            {
                if (webElement.IsPresent())
                {
                    var webElementInstance = new TWebObject();

                    PageFactory.InitElements(webElement, webElementInstance);
                    return webElementInstance;
                }
            }
            return new TWebObject();
        }

        public static bool IsPresent(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (ElementNotVisibleException)
            {
            }
            catch (NullReferenceException)
            {
            }
            catch (NoSuchElementException)
            {
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (InvalidOperationException)
            {
            }
            catch (WebDriverException)
            {
            }
            catch (TargetInvocationException)
            {
            }
            return false;
        }

        public static bool IsClickable(this IWebElement element)
        {
            try
            {
                return element.Displayed && element.Enabled;

            }
            catch (ElementNotVisibleException)
            {
            }
            catch (NullReferenceException)
            {
            }
            catch (NoSuchElementException)
            {
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (InvalidOperationException)
            {
            }
            catch (WebDriverException)
            {
            }
            catch (TargetInvocationException)
            {
            }
            return false;
        }

        public static void Click(this IWebElement element, string elementDescription)
        {
            try
            {
                Log.Write(string.Format("Click to [ {0} ]", elementDescription));
                Waiter.WaitUpTo((int)TimeSpan.FromMinutes(1).TotalMilliseconds, element.IsPresent, "element is not visible");
                element.Click();
            }
            catch (TargetInvocationException e)
            {
                Log.Write(e.Message);
            }
            catch (WebDriverException e)
            {
                if (e.Message.Contains("timed out after 60 seconds."))
                {
                    Log.Write(e.Message);
                }
                else
                {
                    throw;
                }
            }
        }

        public static void Click(this IList<IWebElement> links, string linkText)
        {
            IWebElement link = null;
            Waiter.WaitUpTo(10000, () =>
            {
                link = links.FirstOrDefault(lnk => string.Equals(lnk.Text.Trim(), linkText, StringComparison.InvariantCultureIgnoreCase));
                return link.IsPresent();
            }, "Element " + linkText + " is not found");

            if (link == null)
            {
                throw new UiException(string.Format("Link {0} is not found", linkText));
            }
            link.Click(linkText);
        }

        public static void SelectElementByText(this IWebElement element, String text)
        {
            Log.Write(string.Format("Select item [ {0} ] from combobox ", text));
            new SelectElement(element).SelectByText(text);
        }
    }
}