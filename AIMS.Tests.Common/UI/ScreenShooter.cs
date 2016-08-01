using System;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using AIMS.Tests.Common.TestUtil;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AIMS.Tests.Common.UI
{
    public class ScreenShooter
    {
        private const string ApiKey = "d9c9a8dc32c068c";
        private const string ApiBaseUrl = "https://api.imgur.com/3/upload.xml";
        private static string _imgeUrl;

        /// <summary>
        /// Take desktop screen-shot and upload to imgur.com
        /// </summary>
        /// <param name="imgName">Image name</param>
        /// <returns>Link to image</returns>
        public static string TakeDesktopScreenShot(string imgName = "UIDesktopException")
        {
            try
            {
                imgName += "_desktop.png";
                var imgPath = Environment.CurrentDirectory + "\\" + imgName;
                ScreenCapture sc = new ScreenCapture();
                sc.CaptureScreenToFile(imgPath, ImageFormat.Png);
                _imgeUrl = UploadImage(imgPath);
                Log.Write("Desktop screen-shot:");
                Log.Write(_imgeUrl);
                Log.Write(imgPath);
            }
            catch (Exception e)
            {
                Log.Write("Error: get screen-shot from desktop.", e);
            }
            return _imgeUrl;
        }

        /// <summary>
        /// Take browser screen-shot and upload to imgur.com
        /// </summary>
        /// <param name="imgName">Image name</param>
        /// <returns>Link to image</returns>
        public static string TakeBrowserScreenShot(string imgName = "UIBrowserException")
        {
            try
            {
                IWebDriver driver = (IWebDriver)ScenarioContext.Current["CurrentDriver"];
                imgName += "_browser.png";
                var imgPath = Environment.CurrentDirectory + "\\" + imgName;
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(imgName, ImageFormat.Png);
                _imgeUrl = UploadImage(imgPath);
                Log.Write("Browser screen-shot:");
                Log.Write(_imgeUrl);
                Log.Write(imgPath);
            }
            catch (Exception e)
            {
                Log.Write("Error: get screen-shot from browser.", e);
            }
            return _imgeUrl;
        }

        public static string TakeBrowserScreenShot(IWebDriver driver, string imgName = "UIBrowserException")
        {
            try
            {
                imgName += "_browser.png";
                var imgPath = Environment.CurrentDirectory + "\\" + imgName;
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(imgName, ImageFormat.Png);
                _imgeUrl = UploadImage(imgPath);
                Log.Write("Browser screen-shot:");
                Log.Write(_imgeUrl);
                Log.Write(imgPath);
            }
            catch (Exception e)
            {
                Log.Write("Error: get screen-shot from browser.", e);
            }
            return _imgeUrl;
        }

        /// <summary>
        /// Upload an image to Imgur.com
        /// </summary>
        /// <param name="filePath">The file to upload.</param>
        public static string UploadImage(string filePath)
        {
            string url = null;
            if (!File.Exists(filePath)) return null;

            using (var w = new WebClient())
            {
                var values = new NameValueCollection
                {
                    { "image", Convert.ToBase64String(File.ReadAllBytes(filePath)) },
                    { "title", "test" }
                };

                w.Headers.Add("Authorization", string.Format("Client-ID {0}", ApiKey));

                byte[] response = w.UploadValues(ApiBaseUrl, values);

                XDocument xml = XDocument.Load(new MemoryStream(response));

                var linkNode = xml.Descendants("link").FirstOrDefault();
                if (linkNode != null) url = linkNode.Value;
            }
            return url;
        }
    }
}