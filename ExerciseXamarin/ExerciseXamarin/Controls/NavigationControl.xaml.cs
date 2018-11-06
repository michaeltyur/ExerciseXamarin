using System;
using System.Runtime.CompilerServices;
using ExerciseXamarin.ViewModels;
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

        #region Text  Button
        public static readonly BindableProperty ButtonTextProperty =
                                             BindableProperty.Create(nameof(ButtonText),
                                                                     typeof(string),
                                                                     typeof(NavigationControl),
                                                                     default(string),
                                                                     BindingMode.TwoWay);
        public string ButtonText
        {
            get
            {
                return (string)GetValue(ButtonTextProperty);
            }
            set
            {
                SetValue(ButtonTextProperty, value);
            }
        }
        #endregion

        #region Button Background Color
        public static readonly BindableProperty ButtonBackColorProperty =
                                             BindableProperty.Create(nameof(ButtonBackColor),
                                                                     typeof(int),
                                                                     typeof(NavigationControl),
                                                                     default(int),
                                                                      BindingMode.TwoWay);
        public int ButtonBackColor
        {
            get
            {
                return (int)GetValue(ButtonBackColorProperty);
            }
            set
            {
                SetValue(ButtonBackColorProperty, value);
            }
        }
        #endregion

        #region Button Size
        public static readonly BindableProperty ButtonSizeProperty =
                                             BindableProperty.Create(nameof(ButtonSize),
                                                                     typeof(int),
                                                                     typeof(NavigationControl),
                                                                     default(int),
                                                                     BindingMode.TwoWay);
        public int ButtonSize
        {
            get
            {
                return (int)GetValue(ButtonSizeProperty);
            }
            set
            {
                SetValue(ButtonSizeProperty, value);
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
        }
        private void HttpClientButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.HttpClientPageView.ToString();

        }
        private void EssentalsButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.EssentialsPageView.ToString();

        }
        private void ListViewButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.ItemsListPageView.ToString();

        }
        private void CustomControlButton_Clicked(object sender, EventArgs e)
        {
            NameOfPage = Pages.CustomControlsPageView.ToString();

        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
          
            #region Button
            base.OnPropertyChanged(propertyName);
            if (propertyName == ButtonTextProperty.PropertyName)
            {
                CustomControlButton.Text = ButtonText;
            }
            if (propertyName == ButtonBackColorProperty.PropertyName)
            {
                var newColor= Color.FromRgb(ButtonBackColor, 125+ ButtonBackColor, 255- ButtonBackColor);

                CustomControlButton.BackgroundColor = newColor;
            }
            if (propertyName == ButtonSizeProperty.PropertyName)
            {
              
                CustomControlButton.HeightRequest = CustomControlButton.HeightRequest + ButtonSize;
                CustomControlButton.WidthRequest = CustomControlButton.WidthRequest + ButtonSize;
            }
            #endregion

        }
    }
}