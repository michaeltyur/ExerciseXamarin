using ExerciseXamarin.Interfaces;
using ExerciseXamarin.Views;
using Xamarin.Forms;

namespace ExerciseXamarin.Models
{
    public class NavManager
    {

        public NavManager()
        {

        }

        public void Navigate(IPage page, string numOfPage)
        {
            IPage currentPage = page;

            IPage navigationPage;

            INavigation navigation = ((ContentPage)currentPage).Navigation;

            switch (numOfPage)
            {
                case "CustomControlsPageView":

                    navigationPage = DependencyService.Get<CustomControlsPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    break;

                case "EssentialsPageView":

                    navigationPage = DependencyService.Get<EssentialsPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    break;

                case "ItemsListPageView":

                    navigationPage = DependencyService.Get<ItemsListPageView>();
                    navigation.PushAsync((ContentPage)navigationPage, true);
                    break;

                case "HttpClientPageView":

                    navigationPage = DependencyService.Get<HttpClientPageView>();
                    navigation.PushAsync(DependencyService.Get<HttpClientPageView>(), true);
                    break;

                //case Pages.MainPageView:

                //    navigation.PopToRootAsync(true);
                //    break;

                default:
                    break;
            }
        }
    }
}
