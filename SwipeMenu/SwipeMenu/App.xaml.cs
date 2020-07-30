using AgendaApp;
using SwipeMenu.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeMenu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "SwipeView_Experimental" });
            MainPage = new NavigationPage (new  LoginPagina());
            //MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new OrdenesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
