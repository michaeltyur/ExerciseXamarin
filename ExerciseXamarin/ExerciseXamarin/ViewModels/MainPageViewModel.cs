using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Models;
using ExerciseXamarin.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExerciseXamarin.ViewModels
{
   public class MainPageViewModel
    {
        public string Title { get; set; }
        public ICommand NavCommand { get; set; }
        private NavManager _navManager;

        public MainPageViewModel()
        {
            _navManager= DependencyService.Get<NavManager>();
            Title = CurrentDeviceInfo.GetDeviceInfo()+" Home Page";
            NavCommand = new Command<string>(Navigate);
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

            _navManager.Navigate(currentPage,numOfPage);
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
