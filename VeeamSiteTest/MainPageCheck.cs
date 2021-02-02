using Microsoft.VisualStudio.TestTools.UnitTesting;
using static VeeamSiteTest.Pages.MainPage;

namespace VeeamSiteTest
{
    [TestClass]
    public class MainPageCheck : TestBase
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            BaseClassInitialize(testContext);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            BaseTestInitialize();
        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseClassCleanup(); 
        }
        
        [TestMethod]
        public void CheckVacanciesPage()
        {
            Logger.Info("Step 1. Open the main page");
            Logger.Info("Expected result: Main page is opened");
            TestManager.MainPage.Open();
            Assert.IsTrue(TestManager.MainPage.IsOpened());

            Logger.Info("Step 2. Change language to 'Russian'");
            Logger.Info("Expected result: localization switched to Russian");
            TestManager.MainPage.ChangeLocalization(Localization.Russian); 
            Assert.IsTrue(TestManager.MainPage.CurrentLocalizationIs(Localization.Russian));

            Logger.Info("Step 3. Check vacancies");
            Logger.Info("Expected result: vacancies count is 3");
            Assert.IsTrue(TestManager.VacanciesPage.IsOpened(Localization.Russian));
            var vacancies = TestManager.VacanciesPage.DisplayedVacancies; 
            Assert.AreEqual(4, vacancies);

        }
    }
}
