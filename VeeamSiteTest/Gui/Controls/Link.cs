namespace VeeamSiteTest.Gui.Controls
{
    public class Link : BaseControl
    {
        public Link(string xpath) : base(xpath)
        {
        }

        public string Href
        {
            get
            {
                var href = Element.GetAttribute("href");
                Logger.Info($"Trying to get href for the element: '{XPath}'");
                Logger.Info($"href: '{href}'");
                return href;
            }
        }

        public string Text
        {
            get
            {
                var text = Element.Text; 
                Logger.Info($"Trying to get text for the element: '{XPath}'");
                Logger.Info($"Text: '{text}'"); 
                return text;
            }
        }

        public void Click()
        {
            Logger.Info($"Trying to click on the element: '{XPath}'");
            Element.Click();
            Logger.Info($"Success: '{XPath}'");
        }
    }
}
