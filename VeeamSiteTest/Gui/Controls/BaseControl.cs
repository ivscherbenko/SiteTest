using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using VeeamSiteTest.Tools;
using VeeamSiteTest.Tools.Extensions;

namespace VeeamSiteTest.Gui.Controls
{
    public class BaseControl
    {
        protected string XPath { get; }
        private Browser Browser => CoreEnvironment.Browser;
        protected static readonly ILogger Logger = typeof(BaseControl).CreateLogger();
        private readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(10);

        public BaseControl(string xpath)
        {
            XPath = xpath; 
        }

        public bool Exists
        {
            get
            {
                Logger.Info($"Is element exist: '{XPath}'"); 
                var result = GetElementSafe() != null;
                Logger.Info($"Result: '{result}'");
                return result; 
            }
        }

        public bool Displayed
        {
            get
            {
                Logger.Info($"Does element displayed: '{XPath}'");
                var element = GetElementSafe();
                var result = element != null && element.Displayed;
                Logger.Info($"Result: '{result}'");
                return result; 
            }
        }

        protected IWebElement Element
        {
            get
            {
                var element = GetElementSafe();
                if (element != null)
                {
                    return element; 
                }

                throw new Exception("Element not found");
            }
        }

        protected IWebElement GetElementSafe()
        {
            Logger.Info($"Trying to get an element by xpath: '{XPath}'");
            var wait = new WebDriverWait(Browser.WebDriver, _defaultTimeout);
            return wait.Until(ExpectedConditions.ElementExists(By.XPath(XPath)));
        }
    }
}
