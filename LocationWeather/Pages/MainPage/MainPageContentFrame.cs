using LocationWeather.Repositories;
using Xamarin.Forms;

namespace LocationWeather.Pages.MainPage {
    static class MainPageContentFrame
    {
        public static Frame GetActivityIndicatorMainPageContent()
        {
            return new Frame
            {
                BackgroundColor = Color.ForestGreen,
                Content = new ActivityIndicator
                {
                    IsRunning = true,
                    IsEnabled = true,
                    IsVisible = true,
                    BackgroundColor = Color.ForestGreen,
                    Color = Color.LightGreen
                }
            };
        }

        public static Frame GetMainPageContent(string location, RootObject weatherInfo)
        {
            return new Frame
            {
                BackgroundColor = Color.ForestGreen,
                Content = new Label
                {
                    BackgroundColor = Color.ForestGreen,
                    FontSize = 18,
                    Margin = new Thickness(10, 10, 10, 10),
                    FormattedText = MainPageFormattedStrings.GetMainPageFormattedStringContent(location, weatherInfo)
                }
            };
        }
    }
}
