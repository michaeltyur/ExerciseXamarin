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
    }
}