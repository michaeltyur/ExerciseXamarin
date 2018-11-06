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
            MainPageView mainPage = DependencyService.Get<MainPageView>();

            IPage currentPage = page;

            IPage navigationPage;

            INavigation navigation = ((ContentPage)currentPage).Navigation;

            switch (numOfPage)
            {
                case "CustomControlsPageView":

                    navigationPage = DependencyService.Get<CustomControlsPageView>();
                    if (currentPage != navigationPage)
                    {
                        navigation.PushAsync((ContentPage)navigationPage);
                        if (currentPage != mainPage)
                        {
                            navigation.RemovePage((ContentPage)currentPage);
                        }
                    }
                    break;

                case "EssentialsPageView":

                    navigationPage = DependencyService.Get<EssentialsPageView>();
                    if (currentPage != navigationPage)
                    {
                        navigation.PushAsync((ContentPage)navigationPage);
                        if (currentPage != mainPage)
                        {
                            navigation.RemovePage((ContentPage)currentPage);
                        }
                    }
                    break;

                case "ItemsListPageView":

                    navigationPage = DependencyService.Get<ItemsListPageView>();
                    if (currentPage != navigationPage)
                    {
                        navigation.PushAsync((ContentPage)navigationPage);
                        if (currentPage != mainPage)
                        {
                            navigation.RemovePage((ContentPage)currentPage);
                        }
                    }
                    break;

                case "HttpClientPageView":

                    navigationPage = DependencyService.Get<HttpClientPageView>();
                    if (currentPage != navigationPage)
                    {
                        navigation.PushAsync(DependencyService.Get<HttpClientPageView>());
                        if (currentPage != mainPage)
                        {
                            navigation.RemovePage((ContentPage)currentPage);
                        }
                    }
                    break;

                default:

                    navigation = mainPage.Navigation;
                    navigation.PopToRootAsync();
                    break;
            }
        }
    }
}
