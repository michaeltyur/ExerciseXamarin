using System;
using System.Runtime.CompilerServices;
using ExerciseXamarin.ViewModels;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseXamarin.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavigationControl : ContentView
	{
        #region Name Of Page
        public static readonly BindableProperty NameOfPageProperty = 
                                             BindableProperty.Create(nameof(NameOfPage),
                                                                     typeof(string), 
                                                                     typeof(NavigationControl), 
                                                                     default(string), 
                                                                     BindingMode.TwoWay);
        public string NameOfPage
        {
            get
            {
                return (string)GetValue(NameOfPageProperty);
            }
            set
            {
                SetValue(NameOfPageProperty, value);
            }
        }
        #endregion

        #region Home Text  Button
        public static readonly BindableProperty HomeButtonTextProperty =
                                             BindableProperty.Create(nameof(HomeButtonText),
                                                                     typeof(string),
                                                                     typeof(NavigationControl),
                                                                     default(string),
                                                                     BindingMode.TwoWay);
        public string HomeButtonText
        {
            get
            {
                return (string)GetValue(HomeButtonTextProperty);
            }
            set
            {
                SetValue(HomeButtonTextProperty, value);
            }
        }
        #endregion

        #region Home Button Background Color
        public static readonly BindableProperty HomeButtonBackColorProperty =
                                             BindableProperty.Create(nameof(HomeButtonBackColor),
                                                                     typeof(int),
                                                                     typeof(NavigationControl),
                                                                     default(int),
                                                                      BindingMode.TwoWay);
        public int HomeButtonBackColor
        {
            get
            {
                return (int)GetValue(HomeButtonBackColorProperty);
            }
            set
            {
                SetValue(HomeButtonBackColorProperty, value);
            }
        }
        #endregion

        #region Home Button Text Color
        public static readonly BindableProperty HomeButtonTextColorProperty =
                                             BindableProperty.Create(nameof(HomeButtonTextColor),
                                                                     typeof(int),
                                                                     typeof(NavigationControl),
                                                                     default(int),
                                                                     BindingMode.TwoWay);
        public int HomeButtonTextColor
        {
            get
            {
                return (int)GetValue(HomeButtonTextColorProperty);
            }
            set
            {
                SetValue(HomeButtonTextColorProperty, value);
            }
        }
        #endregion

        public NavigationControl ()
		{
			InitializeComponent ();
            MainPageButton.Clicked += MainPageButton_Clicked;
            HttpClientButton.Clicked += HttpClientButton_Clicked;
            EssentalsButton.Clicked += EssentalsButton_Clicked;
            ListViewButton.Clicked += ListViewButton_Clicked;
            CustomControlButton.Clicked += CustomControlButton_Clicked;
        }

      
        private void MainPageButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.MainPageView.ToString();
            //ChangeStateNavButtons(Pages.MainPageView);
        }
        private void HttpClientButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.HttpClientPageView.ToString();
            //ChangeStateNavButtons(Pages.HttpClientPageView);
        }
        private void EssentalsButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.EssentialsPageView.ToString();
           // ChangeStateNavButtons(Pages.EssentialsPageView);
        }
        private void ListViewButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.ItemsListPageView.ToString();
           // ChangeStateNavButtons(Pages.ItemsListPageView);
        }
        private void CustomControlButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.CustomControlsPageView.ToString();
            //ChangeStateNavButtons(Pages.CustomControlsPageView);
        }
        //private void ChangeStateNavButtons(Pages page)
        //{
        //    if (page == Pages.MainPageView)
        //    {
        //        MainPageButton.IsEnabled = false;
        //        MainPageButton.IsEnabled = false;
        //    }
        //    else MainPageButton.IsEnabled = true;

        //    if (page == Pages.CustomControlsPageView)
        //        CustomControlButton.IsEnabled = false;
        //    else CustomControlButton.IsEnabled = true;

        //    if (page == Pages.EssentialsPageView)
        //        EssentalsButton.IsEnabled = false;
        //    else EssentalsButton.IsEnabled = true;

        //    if (page == Pages.HttpClientPageView)
        //        HttpClientButton.IsEnabled = false;
        //    else HttpClientButton.IsEnabled = true;

        //    if (page == Pages.ItemsListPageView)
        //        ListViewButton.IsEnabled = false;
        //    else ListViewButton.IsEnabled = true;
        //}

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
          
            #region Home Button
            base.OnPropertyChanged(propertyName);
            if (propertyName == HomeButtonTextProperty.PropertyName)
            {
                MainPageButton.Text = HomeButtonText;
            }
            if (propertyName == HomeButtonBackColorProperty.PropertyName)
            {
                var newColor= Color.FromRgb(HomeButtonBackColor, 125+ HomeButtonBackColor, 255- HomeButtonBackColor);

                MainPageButton.BackgroundColor = newColor;
            }
            if (propertyName == HomeButtonTextColorProperty.PropertyName)
            {
                var newColor = Color.FromRgb(HomeButtonTextColor, 255, HomeButtonTextColor + HomeButtonTextColor);

                MainPageButton.TextColor = newColor;
            }
            #endregion
            //if (propertyName == SliderValueTextColorProperty.PropertyName)
            //{
            //    textColorSlider.Value = SliderValueTextColor;
            //}
            //if (propertyName == BackColorSliderLabelProperty.PropertyName)
            //{
            //    backColorSliderLabel.Text = BackColorSliderLabel;
            //}
            //if (propertyName == SliderValueBackColorProperty.PropertyName)
            //{
            //    backColorSlider.Value = SliderValueBackColor;
            //}
        }
    }
}