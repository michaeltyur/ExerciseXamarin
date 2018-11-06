using ExerciseXamarin.Helpers;
using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Models;
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
using Location = Xamarin.Essentials.Location;

namespace ExerciseXamarin.ViewModels
{
    public class EssentialsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NavManager _navManager;

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
            _navManager = DependencyService.Get<NavManager>();
            Title = CurrentDeviceInfo.GetDeviceInfo()+ " Essentials";

            Geocoding.MapKey = "MJ0VPbUB8qN8a65B705U~BVTx7iZ0LoszsAqqogkJ7g~AiiDFPi-CEC68spKYqX5ew-PUCFmUfa4qqIuXVEI0wC0amsG9uezm5JMft7Lc_jQ";
            Alert = "Searching location";
             GetMaps();
        }
        public void Navigate(string numOfPage)
        {
            IPage currentPage = DependencyService.Get<EssentialsPageView>();
            _navManager.Navigate(currentPage, numOfPage);     
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

