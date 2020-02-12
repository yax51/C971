using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace C971
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new StartPage());
        }


        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new StartPage());
            DatabaseLocation = databaseLocation;

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
