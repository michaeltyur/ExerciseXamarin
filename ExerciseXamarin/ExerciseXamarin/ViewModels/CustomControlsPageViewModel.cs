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

        public string HomeButtonTextChangerLabel { get; set; }
        public string HomeButtonTextColorChangerLabel { get; set; }
        public string HomeButtonBackColorChangerLabel { get; set; }

        #region Home Button
        private string homeButtonText;
        public string HomeButtonText
        {
            get { return homeButtonText; }
            set { homeButtonText = value;OnPropertyChanged(); }
        }

        private int homeButtonBackColor;
        public int HomeButtonBackColor
        {
            get { return homeButtonBackColor; }
            set { homeButtonBackColor = value; OnPropertyChanged(); }
        }

        private int homeButtonTextColor;
        public int HomeButtonTextColor
        {
            get { return homeButtonTextColor; }
            set { homeButtonTextColor = value; OnPropertyChanged(); }
        }
        #endregion

        #region Page Title
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string PageTitleTextValueChangerLabel { get; set; }
        public string PageTitleTextColorChangerLabel { get; set; }
        public string PageTitleBackColorChangerLabel { get; set; }

        public int pageTitleTextColorChanger;
        public int PageTitleTextColorChanger
        {
            get { return pageTitleTextColorChanger; }
            set
            {
                pageTitleTextColorChanger = value;
                OnPropertyChanged();
            }
        }

        private int pageTitleBackColorChanger;
        public int PageTitleBackColorChanger
        {
            get { return pageTitleBackColorChanger; }
            set
            {
                pageTitleBackColorChanger = value;
                OnPropertyChanged();
            }
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

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
            HomeButtonTextChangerLabel = "Home Button Text Changer";
            HomeButtonTextColorChangerLabel = "Home Button Text Color Changer";
            HomeButtonBackColorChangerLabel = "Home Button Backgroind Color Changer";

            PageTitleTextValueChangerLabel = "Page Title Text Value Changer";
            PageTitleTextColorChangerLabel = "Page Title Text Color Changer";
            PageTitleBackColorChangerLabel = "Page Title Background Changer";

            PageTitleTextColorChanger = 255;
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
