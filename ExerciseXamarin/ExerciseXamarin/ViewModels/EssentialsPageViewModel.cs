using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Views;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExerciseXamarin.ViewModels
{
    public class EssentialsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
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
        public EssentialsPageViewModel()
        {
            Title = CurrentDeviceInfo.GetDeviceInfo();

            Geocoding.MapKey = "MJ0VPbUB8qN8a65B705U~BVTx7iZ0LoszsAqqogkJ7g~AiiDFPi-CEC68spKYqX5ew-PUCFmUfa4qqIuXVEI0wC0amsG9uezm5JMft7Lc_jQ";
            Alert = "Searching location";
             GetMaps();
        }
        public void Navigate(string numOfPage)
        {
            IPage currentPage = DependencyService.Get<EssentialsPageView>();

            IPage navigationPage;

            INavigation navigation = ((ContentPage)currentPage).Navigation;

            switch (numOfPage)
            {
                case "CustomControlsPageView":

                    navigationPage = DependencyService.Get<CustomControlsPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

                //case Pages.EssentialsPageView:

                //    navigationPage = DependencyService.Get<EssentialsPageView>();
                //    navigation.PushAsync((ContentPage)navigationPage, true);
                //    navigation.RemovePage((ContentPage)currentPage);
                //    break;

                case "ItemsListPageView":

                    navigationPage = DependencyService.Get<ItemsListPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    navigation.RemovePage((ContentPage)currentPage);
                    break;

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

        public async Task GetMaps()
        {
            Location location = new Location();
            
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                    var placemark = placemarks?.FirstOrDefault();
                    if (placemark!=null)
                    {
                      Alert = $"Country: {placemark.CountryName}, " +
                              $" City: {placemark.Locality}, " +
                              $" Street: {placemark.Thoroughfare}, " +
                              $"Number: {placemark.SubThoroughfare}";
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Alert = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                Alert = pEx.Message;
            }
            catch (Exception ex)
            {
                Alert = ex.Message;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alert)));
       
            var options = new MapsLaunchOptions { Name = "You are here" };

            await Maps.OpenAsync(location, options);
        }

    }
}

