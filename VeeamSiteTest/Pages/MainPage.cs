using NLog;
using System;
using System.ComponentModel;
using System.Linq;
using VeeamSiteTest.Gui;
using VeeamSiteTest.Tools;
using VeeamSiteTest.Tools.Extensions;

namespace VeeamSiteTest.Pages
{
    public class MainPage : OpenablePage
    {
        private readonly Main _main;
        protected static readonly ILogger Logger = typeof(OpenablePage).CreateLogger(); 

        public MainPage(Action action) : base(action)
        {
            _main = GuiCore.Main; 
        }

        public override bool IsOpened()
        {
            Logger.Info("Is main page opened");
            var result = _main.MainLogo.Displayed;
            Logger.Info($"Result: '{result}'");
            return _main.MainLogo.Displayed;
        }

        public void ChangeLocalization(Localization localization)
        {
            Logger.Info($"Trying to switch localiztion to: {localization}");
            OpenLocalizationMenu();
            SelectLanguage(localization);
        }

        private void SelectLanguage(Localization localization)
        {
            switch (localization)
            {
                case Localization.Russian:
                    _main.Languages.First(i => i.Href.Contains(EnumHelper.GetDescription(Localization.Russian))).Click(); 
                    break;
                case Localization.Czech:
                    _main.Languages.First(i => i.Href.Contains(EnumHelper.GetDescription(Localization.Czech))).Click();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(localization), localization, null);
            }
        }

        public void OpenLocalizationMenu()
        {
            Logger.Info("Open localization menu");
            _main.LocalizationMenu.Click();
        }

        public enum Localization
        {
            [Description("ru")]
            Russian,
            [Description("cz")]
            Czech,
            [Description("com")]
            Global
        }

        public bool CurrentLocalizationIs(Localization localization)
        {
            return CoreEnvironment.Browser.Url.Contains(EnumHelper.GetDescription(localization));
        }
    }
}
