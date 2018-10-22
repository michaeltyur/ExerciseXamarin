using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseXamarin.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavigationControl : ContentView
	{
        public ICommand NavToMainPageCommand { get; set; }
        public ICommand NavToHttpClientPageViewCommand { get; set; }

        public NavigationControl ()
		{
			InitializeComponent ();
            NavToMainPageCommand = new Command(NavigateToMainPage);
            NavToHttpClientPageViewCommand= new Command(NavigateToHttpClientPageView);
            var test = Type.GetType("ExerciseXamarin.Views.ItemsListPageView");
           // MainPageButton.
        }
        public  void NavigateToMainPage()
        {
            var mainPage= DependencyService.Get<MainPageView>();
            var currentPage= DependencyService.Get<CustomControlsPageView>();
            Activator.CreateInstance(typeof(MainPageView));
            var test = Type.GetType("ExerciseXamarin.Views.ItemsListPageView");

            ((ContentPage)currentPage).Navigation.PushAsync((ContentPage)mainPage);
        }

        public void NavigateToHttpClientPageView()
        {
            var mainPage = (MainPageView)DependencyService.Get<MainPageView>();
            var destinationPage = DependencyService.Get<HttpClientPageView>();

            ((ContentPage)mainPage).Navigation.PushAsync((ContentPage)destinationPage);
        }

        public void NavigateToEssentialsPageView()
        {
            var mainPage = (MainPageView)DependencyService.Get<MainPageView>();
            var destinationPage = DependencyService.Get<EssentialsPageView>();

            ((ContentPage)mainPage).Navigation.PushAsync((ContentPage)destinationPage);
        }

        public void NavigateToItemsListPageView()
        {
            var mainPage = (MainPageView)DependencyService.Get<MainPageView>();
            var destinationPage = DependencyService.Get<ItemsListPageView>();

            ((ContentPage)mainPage).Navigation.PushAsync((ContentPage)destinationPage);
        }

        public void NavigateToCustomControlsPageView()
        {
            var mainPage = (MainPageView)DependencyService.Get<MainPageView>();
            var destinationPage = DependencyService.Get<CustomControlsPageView>();

            ((ContentPage)mainPage).Navigation.PushAsync((ContentPage)destinationPage);
        }

    }
}