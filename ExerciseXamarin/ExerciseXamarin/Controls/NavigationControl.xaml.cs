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

        #region Home Button Text Value
        public static readonly BindableProperty ButtonTextValueProperty =
                                     BindableProperty.Create(nameof(HomeButtonTextValue),
                                                             typeof(string),
                                                             typeof(NavigationControl),
                                                             default(string),
                                                             BindingMode.TwoWay);
        public string HomeButtonTextValue
        {
            get
            {
                return (string)GetValue(ButtonTextValueProperty);
            }
            set
            {
                SetValue(ButtonTextValueProperty, value);
            }
        }
        #endregion

        #region Home Text  Button
        public static readonly BindableProperty TextButtonProperty =
                                             BindableProperty.Create(nameof(HomeTextButton),
                                                                     typeof(string),
                                                                     typeof(NavigationControl),
                                                                     default(string),
                                                                     BindingMode.TwoWay);
        public string HomeTextButton
        {
            get
            {
                return (string)GetValue(TextButtonProperty);
            }
            set
            {
                SetValue(TextButtonProperty, value);
            }
        }
        #endregion

        #region Home Button Background Color
        public static readonly BindableProperty HomeButtonBackColorProperty =
                                             BindableProperty.Create(nameof(HomeButtonBackColor),
                                                                     typeof(Color),
                                                                     typeof(NavigationControl),
                                                                     default(Color),
                                                                     BindingMode.TwoWay);
        public Color HomeButtonBackColor
        {
            get
            {
                return (Color)GetValue(HomeButtonBackColorProperty);
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
                                                                     typeof(Color),
                                                                     typeof(NavigationControl),
                                                                     default(Color),
                                                                     BindingMode.TwoWay);
        public Color HomeButtonTextColor
        {
            get
            {
                return (Color)GetValue(HomeButtonTextColorProperty);
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
            ChangeStateNavButtons(Pages.MainPageView);
        }
        private void HttpClientButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.HttpClientPageView.ToString();
            ChangeStateNavButtons(Pages.HttpClientPageView);
        }
        private void EssentalsButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.EssentialsPageView.ToString();
            ChangeStateNavButtons(Pages.EssentialsPageView);
        }
        private void ListViewButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.ItemsListPageView.ToString();
            ChangeStateNavButtons(Pages.ItemsListPageView);
        }
        private void CustomControlButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.CustomControlsPageView.ToString();
            ChangeStateNavButtons(Pages.CustomControlsPageView);
        }
        private void ChangeStateNavButtons(Pages page)
        {
            if (page == Pages.MainPageView)
                MainPageButton.IsEnabled = false;
            else MainPageButton.IsEnabled = true;

            if (page == Pages.CustomControlsPageView)
                CustomControlButton.IsEnabled = false;
            else CustomControlButton.IsEnabled = true;

            if (page == Pages.EssentialsPageView)
                EssentalsButton.IsEnabled = false;
            else EssentalsButton.IsEnabled = true;

            if (page == Pages.HttpClientPageView)
                HttpClientButton.IsEnabled = false;
            else HttpClientButton.IsEnabled = true;

            if (page == Pages.ItemsListPageView)
                ListViewButton.IsEnabled = false;
            else ListViewButton.IsEnabled = true;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //home button
            base.OnPropertyChanged(propertyName);
            if (propertyName == TextButtonProperty.PropertyName)
            {
                MainPageButton.Text = HomeTextButton;
            }
            if (propertyName == HomeButtonBackColorProperty.PropertyName)
            {
                MainPageButton.BackgroundColor = HomeButtonBackColor;
            }
            if (propertyName == HomeButtonTextColorProperty.PropertyName)
            {
                MainPageButton.TextColor = HomeButtonTextColor;
            }

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