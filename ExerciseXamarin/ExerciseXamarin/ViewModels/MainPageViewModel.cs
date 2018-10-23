using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExerciseXamarin.ViewModels
{
   public class MainPageViewModel
    {
        public string Title { get; set; }
        public MainPageViewModel()
        {
            Title = CurrentDeviceInfo.GetDeviceInfo();
        }

        private string navigateToPage;
        public string NavigateToPage
        {
            get { return navigateToPage; }
            set
            {
                navigateToPage = value;
                Navigate(navigateToPage);
            }
        }
        public void Navigate(string numOfPage)
        {
            IPage currentPage = DependencyService.Get<MainPageView>();

            IPage navigationPage;

            INavigation navigation = ((ContentPage)currentPage).Navigation;

            switch (numOfPage)
            {
                case "CustomControlsPageView":

                    navigationPage = DependencyService.Get<CustomControlsPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                case "EssentialsPageView":

                    navigationPage = DependencyService.Get<EssentialsPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                case "ItemsListPageView":

                    navigationPage = DependencyService.Get<ItemsListPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                case "HttpClientPageView":

                    navigationPage = DependencyService.Get<HttpClientPageView>();
                    navigation.PushAsync(DependencyService.Get<HttpClientPageView>(), true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                //case Pages.MainPageView:

                //    navigation.PopToRootAsync(true);
                //    break;

                default:
                    break;
            }
        }
    }
    public enum Pages
    {
        MainPageView = 1,
        CustomControlsPageView,
        EssentialsPageView,
        HttpClientPageView,
        ItemsListPageView
    }
}
