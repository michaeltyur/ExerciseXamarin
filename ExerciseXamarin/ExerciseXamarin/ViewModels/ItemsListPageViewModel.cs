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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExerciseXamarin.ViewModels
{
    public class ItemsListPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<StoryHeader> itemsList;
        public ObservableCollection<StoryHeader> ItemsList
        {
            get { return itemsList; }
            set
            {
                itemsList = value;
                OnPropertyChanged();
            }
        }
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
            set { title = value; OnPropertyChanged(); }
        }

        private string navigateToPage;
        private string _apiAddress = "https://content.guardianapis.com/search?api-key=6e094816-d879-46d7-ae1b-a8c0ad2aa647&show-fields=thumbnail,trailText";

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
            ItemsList = new ObservableCollection<StoryHeader>();
            LoadingBar = true;
            Title = CurrentDeviceInfo.GetDeviceInfo() + " News List";
            Alert = string.Empty;
            FillNewsList(_apiAddress);
        }
        public void Navigate(string numOfPage)
        {
            //IPage currentPage = DependencyService.Get<MainPageView>();
            IPage currentPage = DependencyService.Get<ItemsListPageView>();

            _navManager.Navigate(currentPage, numOfPage);
        }

        private async Task<T> GetListItems<T>(string apiAdress, T model)
        {
            using (var client = new HttpClient())
            {

                try
                {
                    var result = await client.GetStringAsync(apiAdress);
                    model = JsonConvert.DeserializeObject<T>(result);
                    return model;
                }
                catch (Exception ex)
                {

                    Alert = ex.Message;
                    return default(T);
                }

            }
        }
        private async void FillNewsList(string apiAddress)
        {
               var result = await GetListItems(apiAddress, new SearchResult());
               var array = result.SearchResponse.StoryHeaders;
            ObservableCollection<StoryHeader> list = new ObservableCollection<StoryHeader>();
            for (int i = 0; i< array.Length; i++)
                {
                  list.Add(array[i]);
                }
                LoadingBar = false;
            ItemsList = list;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
