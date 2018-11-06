using ExerciseXamarin.ViewModels;
using ExerciseXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Autofac;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ExerciseXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<MainPageView>();
            DependencyService.Register<CustomControlsPageView>();
            DependencyService.Register<HttpClientPageView>();
            DependencyService.Register<ItemsListPageView>();
            DependencyService.Register<EssentialsPageView>();
            DependencyService.Register<NavManager>();

            MainPage = new NavigationPage(DependencyService.Get<MainPageView>())
            {
                BarBackgroundColor = Color.DarkGray,
                BarTextColor = Color.Coral,
                Title = "Welcome to Xamarin Exersices"
            };

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
