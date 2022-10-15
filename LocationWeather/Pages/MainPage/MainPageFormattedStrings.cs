using LocationWeather.Repositories;
using LocationWeather.Utils;
using Xamarin.Forms;

namespace LocationWeather.Pages.MainPage
{
    public static class MainPageFormattedStrings {

        public static FormattedString GetMainPageFormattedStringContent(string location, RootObject weatherInfo) {
            
            if (string.IsNullOrEmpty(location))
                return NoCityFormattedString;
            
            else if (weatherInfo == null)
                return WrongCityFormattedString(location);
            
            else
                return InitializedFormattedString(weatherInfo);
        }

        private static Span GetDefaultSpan(string spanText) 
        {
            return new Span
            {
                TextColor = Color.LimeGreen,
                Text = spanText
            };
        }

        private static FormattedString NoCityFormattedString = new FormattedString
        {
            Spans = {
                GetDefaultSpan(Constants.NO_CITY_CHOSEN)
            }
        };

        private static FormattedString WrongCityFormattedString(string city) {
            return new FormattedString {
                Spans = {
                    GetDefaultSpan(Messages.GetNonExistingCityMessage(city))
                }
            };
        }

        private static FormattedString InitializedFormattedString(RootObject weatherInfo) {

            return new FormattedString {
                Spans = {
                    GetDefaultSpan(Messages.GetCountryMessage(weatherInfo.sys.country)),
                    GetDefaultSpan(Messages.GetCityMessage(weatherInfo.name)),
                    GetDefaultSpan(Messages.GetDatetimeMessage()),
                    GetDefaultSpan(Messages.GetCoordinateMessage(weatherInfo.coord.lat, weatherInfo.coord.lon)),
                    GetDefaultSpan(Messages.GetWeatherStatusMessage(weatherInfo.weather[0].main)),
                    GetDefaultSpan(Messages.GetWeatherDescriptionMessage(weatherInfo.weather[0].description)),
                    GetDefaultSpan(Messages.GetExactTemperatureMessage(weatherInfo.main.temp)),
                    GetDefaultSpan(Messages.GetTemparatureRangeMessage(weatherInfo.main.temp_min, weatherInfo.main.temp_max)),
                    GetDefaultSpan(Messages.GetWindMessage(weatherInfo.wind.speed, weatherInfo.wind.deg)),
                    GetDefaultSpan(Messages.GetPressureMessage(weatherInfo.main.pressure)),
                    GetDefaultSpan(Messages.GetHumidityMessage(weatherInfo.main.humidity)),
                }
            };
        }
    }
}
