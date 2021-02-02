using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;

namespace VeeamSiteTest.Tools
{
    public class Browser
    {
        public IWebDriver WebDriver { get; set; }

        public string Url => WebDriver.Url;

        public void Start()
        {
            WebDriver = StartWebDriver();
        }

        private IWebDriver StartWebDriver()
        {
            var service = ChromeDriverService.CreateDefaultService(Directory.GetCurrentDirectory());
            service.LogPath = Path.Combine($"{Directory.GetCurrentDirectory()}","chromedriver.log"); 

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            return new ChromeDriver(service,chromeOptions);
        }

        public void Quit()
        {
            WebDriver?.Quit();
            WebDriver = null;
        }

        public void NavigateTo(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public bool IsStarted()
        {
            return WebDriver != null;
        }

        public IEnumerable<IWebElement> FindElements(By selector)
        {
            return WebDriver.FindElements(selector); 
        }
    }
}
