using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using VeeamSiteTest.Tools;
using VeeamSiteTest.Tools.Extensions;

namespace VeeamSiteTest
{
    public class TestBase
    {
        protected static TestManager TestManager => _testManager ?? (_testManager = new TestManager());
        private static TestManager _testManager;
        protected static ILogger Logger = typeof(TestBase).CreateLogger();

        protected static void BaseClassInitialize(TestContext testContext)
        {
            TestManager.StartBrowser();
        }

        protected static void BaseTestInitialize()
        {
            TestManager.OpenHomePage(); 
        }

        protected static void BaseClassCleanup()
        {
            TestManager.CloseBrowser();
        }
    }
}