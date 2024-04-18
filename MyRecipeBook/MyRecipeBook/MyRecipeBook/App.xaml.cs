using MyRecipeBook.Services;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRecipeBook
{
    public partial class App : Application
    {
        public static DatabaseHelper DatabaseHelper { get; private set; }
        public App()
        {
            InitializeComponent();
            //MainPage = new HomePage();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3");
            DatabaseHelper = new DatabaseHelper(dbPath);

            MainPage = new NavigationPage(new LoginPage());
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
