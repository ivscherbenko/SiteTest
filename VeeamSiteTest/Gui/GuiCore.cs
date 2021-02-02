namespace VeeamSiteTest.Gui
{
    public static class GuiCore
    {
        public static Main Main => _main ?? (_main = new Main());
        private static Main _main;

        public static Vacancies Vacancies => _vacancies ?? (_vacancies = new Vacancies());
        private static Vacancies _vacancies;
    }
}
