using System.Collections.Generic;
using VeeamSiteTest.Gui.Controls;

namespace VeeamSiteTest.Gui
{
    public class Main
    {
        public BaseControl MainLogo => new BaseControl("//*[@class='img-logo']");

        public Link LocalizationMenu => 
            new Link("//nav[contains(@class,'justify')]/nav[contains(@class,'Collapse')]//div[@class='dropdown nav-item']/a");

        public List<Link> Languages = new List<Link>
        {
            new Link("//a[contains(@href,'ru')]"),
            new Link("//a[contains(@href,'cz')]")
        };
    }
}
