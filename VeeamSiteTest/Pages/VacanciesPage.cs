using System;
using System.Linq;
using OpenQA.Selenium;
using VeeamSiteTest.Gui;
using VeeamSiteTest.Tools;
using VeeamSiteTest.Tools.Extensions;
using static VeeamSiteTest.Pages.MainPage;
using ILogger = NLog.ILogger;

namespace VeeamSiteTest.Pages
{
    public class VacanciesPage : OpenablePage
    {
        private static ILogger Logger = typeof(VacanciesPage).CreateLogger(); 
        private readonly Vacancies _vacancies; 

        public VacanciesPage(Action action) : base(action)
        {
            _vacancies = GuiCore.Vacancies; 
        }

        public override bool IsOpened(Localization localization)
        {
            Logger.Info("Is vacancies page opened");
            var result = _vacancies.MainLogo.Displayed;
            Logger.Info($"Result: '{result}'");
            return _vacancies.MainLogo.Displayed && 
                   CoreEnvironment.Browser.Url.Contains(EnumHelper.GetDescription(localization));
        }

        public int DisplayedVacancies
        {
            get
            {
                Logger.Info("Getting available vacancies");
                return _vacancies.AvailableVacancies.Count; 
            }
        }
    }
}