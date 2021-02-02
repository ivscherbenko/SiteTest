using System;
using static VeeamSiteTest.Pages.MainPage;

namespace VeeamSiteTest.Pages
{
    public class OpenablePage
    {
        private readonly Action _action; 

        public OpenablePage(Action action)
        {
            _action = action; 
        }

        public virtual void Open()
        {
            _action(); 
        }

        public virtual bool IsOpened() => throw new NotImplementedException();

        public virtual bool IsOpened(Localization localization) => throw new NotImplementedException();
    }
}
