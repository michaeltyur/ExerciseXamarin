using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Models;
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
        private NavManager _navManager;
        public string TextChangerLabel { get; set; }
        public string SizeChangerLabel { get; set; }
        public string BackColorChangerLabel { get; set; }

        #region  Button
        private string buttonText;
        public string ButtonText
        {
            get { return buttonText; }
            set { buttonText = value;OnPropertyChanged(); }
        }

        private int buttonBackColor;
        public int ButtonBackColor
        {
            get { return buttonBackColor; }
            set { buttonBackColor = value; OnPropertyChanged(); }
        }

        private int buttonSize;
        public int ButtonSize
        {
            get { return buttonSize; }
            set { buttonSize = value; OnPropertyChanged(); }
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
            _navManager = DependencyService.Get<NavManager>();
            Title = CurrentDeviceInfo.GetDeviceInfo()+" Custom Controls";
            TextChangerLabel = "Custom Controls Text Changer";
            SizeChangerLabel = "Custom Controls Button Size Changer";
            BackColorChangerLabel = "Custom Controls Button Backgroind Color Changer";
            ButtonText = "Custom Controls";

            PageTitleTextValueChangerLabel = "Page Title Text Value Changer";
            PageTitleTextColorChangerLabel = "Page Title Text Color Changer";
            PageTitleBackColorChangerLabel = "Page Title Background Changer";

            PageTitleTextColorChanger = 255;
        }
        public void Navigate(string numOfPage)
        {

            IPage currentPage = DependencyService.Get<CustomControlsPageView>();
            _navManager.Navigate(currentPage, numOfPage);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
