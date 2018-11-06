using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Models;
using ExerciseXamarin.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ExerciseXamarin.ViewModels
{
    public class HttpClientPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NavManager _navManager;

        private bool loadingBar;
        public bool LoadingBar
        {
            get { return loadingBar; }
            set { loadingBar = value; OnPropertyChanged(); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value;OnPropertyChanged(); }
        }
        public string Name { get; set; }
        public string City { get; set; }
        public string Cell { get; set; }
        public string Image { get; set; }

        private string alert;
        public string Alert
        {
            get { return alert; }
            set { alert = value;OnPropertyChanged(); }
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
        public HttpClientPageViewModel()
        {
            _navManager = DependencyService.Get<NavManager>();
            Title = CurrentDeviceInfo.GetDeviceInfo() + " Http Client";

            LoadingBar = true;
            City = "City: ";
            Cell = "Phone: ";
            GetRandomUser();
        }

        public void Navigate(string numOfPage)
        {
            IPage currentPage = DependencyService.Get<HttpClientPageView>();
            _navManager.Navigate(currentPage, numOfPage);
        }

        private async void GetRandomUser()
        {
            using (var client = new HttpClient())
            {
                try
                {

                    var result = await client.GetStringAsync("https://randomuser.me/api/?inc=gender,name,cell,location,picture");
                    var model = JsonConvert.DeserializeObject<UserList>(result);
                    Name = $"{model.Results[0].Name.first} { model.Results[0].Name.last}";
                    City += model.Results[0].Location.city;
                    Cell += model.Results[0].Cell;
                    Image = model.Results[0].Picture.large;
                    Alert = "";
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("City"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cell"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Image"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alert"));
                    LoadingBar = false;
                }
                catch (Exception ex)
                {
                    Alert = ex.Message;
                    throw;
                }
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
