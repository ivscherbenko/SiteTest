using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using VeeamSiteTest.Gui.Controls;
using VeeamSiteTest.Tools;

namespace VeeamSiteTest.Gui
{
    public class Vacancies
    {
        public BaseControl MainLogo => new BaseControl("//*[@class='img-logo']");

        public List<BaseControl> AvailableVacancies
        {
            get
            {
                var xpath = @"//a[contains(@class,'card-sm') and contains(@href,'vacancies')]"; 
                var elements = CoreEnvironment.Browser
                    .FindElements(By.XPath(xpath))
                    .ToList();
                return elements.Select(e => new BaseControl(xpath)).ToList();
            }
        }
    }
}
