using System;
using OpenQA.Selenium;

namespace AIMS.Tests.Common.UI
{
    public class UiException : Exception
    {
        public UiException(string message)
            : base(message + Environment.NewLine +
                   "Screen-shot from browser: " + ScreenShooter.TakeBrowserScreenShot() + Environment.NewLine +
                   "Screen-shot from desktop: " + ScreenShooter.TakeDesktopScreenShot())
        {
        }

        public UiException(string message, Exception innerException)
            : base(message + Environment.NewLine +
                   "Screen-shot from browser: " + ScreenShooter.TakeBrowserScreenShot() + Environment.NewLine +
                   "Screen-shot from desktop: " + ScreenShooter.TakeDesktopScreenShot(), innerException)
        {
        }

        public UiException(IWebDriver driver, string message, Exception innerException)
            : base(message + Environment.NewLine +
                   "Screen-shot from browser: " + ScreenShooter.TakeBrowserScreenShot(driver) + Environment.NewLine +
                   "Screen-shot from desktop: " + ScreenShooter.TakeDesktopScreenShot(), innerException)
        {
        }
    }
}
