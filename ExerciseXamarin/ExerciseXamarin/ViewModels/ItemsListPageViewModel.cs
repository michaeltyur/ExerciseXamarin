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
        private NavManager _navManager;

        //Alert
        private string alert;
        public string Alert
        {
            get { return alert; }
            set { alert = value; OnPropertyChanged(); }
        }

        private bool loadingBar;
        public bool LoadingBar
        {
            get { return loadingBar; }
            set { loadingBar = value; OnPropertyChanged(); }
        }

        //Title
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value;OnPropertyChanged(); }
        }

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
            _navManager = DependencyService.Get<NavManager>();
            UsersList = new ObservableCollection<User>();
            LoadingBar = true;
            Title = CurrentDeviceInfo.GetDeviceInfo()+ " Users List";
            Alert = string.Empty;
            GetUsersList();
        }
        public void Navigate(string numOfPage)
        {
            //IPage currentPage = DependencyService.Get<MainPageView>();
            IPage currentPage = DependencyService.Get<ItemsListPageView>();

            _navManager.Navigate(currentPage, numOfPage);
        }

        public async void GetUsersList()
        {
            using (var client = new HttpClient())
            {
                UserList model = new UserList();
                try
                {
                    var result = await client.GetStringAsync("https://randomuser.me/api/?inc=gender,name,cell,location,picture&results=20");
                    model = JsonConvert.DeserializeObject<UserList>(result);
                }
                catch (Exception ex)
                {

                    Alert = ex.Message;
                    return;
                }
                
                
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
