using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Models;
using ExerciseXamarin.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ExerciseXamarin.ViewModels
{
    public class ItemsListPageViewModel : INotifyPropertyChanged
    {

        public ObservableCollection <User> UsersList { get; set; }

        private bool loadingBar;
        public bool LoadingBar
        {
            get { return loadingBar; }
            set { loadingBar = value; OnPropertyChanged(); }
        }
        public string Title { get; set; }
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
        public ItemsListPageViewModel()
        {
            UsersList = new ObservableCollection<User>();
            LoadingBar = true;
            Title = CurrentDeviceInfo.GetDeviceInfo();
            GetUsersList();
        }
        public void Navigate(string numOfPage)
        {
            IPage currentPage = DependencyService.Get<ItemsListPageView>();

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

                //case Pages.ItemsListPageView:

                //    navigationPage = DependencyService.Get<ItemsListPageView>();
                //    navigation.PushAsync((ContentPage)navigationPage, true);
                //    navigation.RemovePage((ContentPage)currentPage);
                //    break;

                case "HttpClientPageView":

                    navigationPage = DependencyService.Get<HttpClientPageView>();
                    navigation.PushAsync(DependencyService.Get<HttpClientPageView>(), true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                case "MainPageView":

                    navigation.PopToRootAsync(true);
                    break;

                default:
                    break;
            }
        }

        public async void GetUsersList()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://randomuser.me/api/?inc=gender,name,cell,location,picture&results=20");
                var model = JsonConvert.DeserializeObject<UserList>(result);
                
                for (int i = 0; i < model.Results.Length; i++)
                {
                    model.Results[i].Name.FullName = $"{model.Results[i].Name.first} {model.Results[i].Name.last}";
                    UsersList.Add(model.Results[i]);
                }
                LoadingBar = false;
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
