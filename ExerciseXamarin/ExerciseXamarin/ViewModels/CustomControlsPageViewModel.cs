using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ExerciseXamarin.ViewModels
{
    public class CustomControlsPageViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        private string homeButtonTextChangerLabel;
        public string HomeButtonTextChangerLabel
        {
            get { return homeButtonTextChangerLabel; }
            set { homeButtonTextChangerLabel = value;OnPropertyChanged(); }
        }
        public string HttpButtonTextChangerLabel { get; set; }
        public string EssentialsButtonTextChangerLabel { get; set; }
        public string ListViewButtonTextChangerLabel { get; set; }
        public string CustomControlTextChangerLabel { get; set; }
        public string HttpButtonTextColorChangerLabel { get; set; }

        private string navigateToPage;

        public event PropertyChangedEventHandler PropertyChanged;

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
            HomeButtonTextChangerLabel = "Home Button Text Changer";
            HttpButtonTextColorChangerLabel = "Http Button Text Color Changer";
            HttpButtonTextChangerLabel = "Http Button Text Changer";
            EssentialsButtonTextChangerLabel = "Essentials Button Text Changer";
            ListViewButtonTextChangerLabel = "ListView Button Text Changer";
            CustomControlTextChangerLabel = "CustomControl Text Changer";
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
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
