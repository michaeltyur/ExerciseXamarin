using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ExerciseXamarin.ViewModels
{
    public class CustomControlsPageViewModel 
    {
        public string Title { get; set; }

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

        public CustomControlsPageViewModel()
        {
            Title = CurrentDeviceInfo.GetDeviceInfo();
        }
        public void Navigate(string numOfPage)
        {

            IPage currentPage = DependencyService.Get<CustomControlsPageView>();

            IPage navigationPage;

            INavigation navigation = ((ContentPage)currentPage).Navigation;

            switch (numOfPage)
            {
                //case Pages.CustomControlsPageView:

                //    navigationPage = DependencyService.Get<CustomControlsPageView>();
                //    navigation.PushAsync((ContentPage)navigationPage, true);
                //    navigation.RemovePage((ContentPage)currentPage);
                //    break;
                case "ItemsListPageView":

                    navigationPage = DependencyService.Get<ItemsListPageView>();
                    navigation.PushAsync(DependencyService.Get<HttpClientPageView>());
                    break;

                case "EssentialsPageView":

                    navigationPage = DependencyService.Get<EssentialsPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                case "HttpClientPageView":

                    navigationPage = DependencyService.Get<HttpClientPageView>();
                    navigation.PushAsync(DependencyService.Get<HttpClientPageView>(),true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                case "MainPageView":

                    navigation.PopToRootAsync(true);
                    break;

                default:
                    break;
            }   

        }
    }

}
