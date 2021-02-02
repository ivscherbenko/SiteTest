namespace VeeamSiteTest.Tools
{
    public class CoreEnvironment
    {
        public static Browser Browser => _browser ?? (_browser = new Browser());
        private static Browser _browser;
    }
}
