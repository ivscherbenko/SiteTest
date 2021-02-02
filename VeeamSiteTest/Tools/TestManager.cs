using VeeamSiteTest.Pages;
using static VeeamSiteTest.Pages.MainPage;

namespace VeeamSiteTest.Tools
{
    public class TestManager
    {
        private const string BaseUrl = "https://careers.veeam.com/";
        private static Browser Browser => CoreEnvironment.Browser;
        public MainPage MainPage => new MainPage(OpenHomePage);
        public VacanciesPage VacanciesPage => new VacanciesPage(() => MainPage.ChangeLocalization(Localization.Russian));

        public void StartBrowser()
        {
            if (!Browser.IsStarted())
            {
                Browser.Start();
            }
        }

        public void CloseBrowser()
        {
            Browser.Quit();
        }

        public void OpenHomePage()
        {
            Browser.NavigateTo(BaseUrl);
        }
    }
}
