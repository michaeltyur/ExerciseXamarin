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

        private bool loadingBar;
        public bool LoadingBar
        {
            get { return loadingBar; }
            set { loadingBar = value; OnPropertyChanged(); }
        }

        public string Title { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Cell { get; set; }
        public string Image { get; set; }
        public string Alert { get; set; }

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
            Title = CurrentDeviceInfo.GetDeviceInfo();
            LoadingBar = true;
            Alert = "Wait please...";
            City = "City: ";
            Cell = "Phone: ";
            GetRandomUser();
        }

        public void Navigate(string numOfPage)
        {
            IPage currentPage = DependencyService.Get<HttpClientPageView>();

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

                case "ItemsListPageView":

                    navigationPage = DependencyService.Get<ItemsListPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                //case Pages.HttpClientPageView:

                //    navigationPage = DependencyService.Get<HttpClientPageView>();
                //    navigation.PushAsync(DependencyService.Get<HttpClientPageView>(), true);
                //    navigation.RemovePage((ContentPage)currentPage);
                //    break;

                case "MainPageView":

                    navigation.PopToRootAsync(true);
                    break;

                default:
                    break;
            }
        }

        private async void GetRandomUser()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://randomuser.me/api/?inc=gender,name,cell,location,picture");
                var model = JsonConvert.DeserializeObject<UserList>(result);
                Name =$"{model.Results[0].Name.first} { model.Results[0].Name.last}";
                City += model.Results[0].Location.city;
                Cell+= model.Results[0].Cell;
                Image = model.Results[0].Picture.large;
                Alert = "";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("City"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cell"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Image"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alert"));
                LoadingBar = false ;
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
