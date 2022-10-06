using OpenWeatherMap.repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LocationWeather.Pages.MainPageContent
{
    public class MainPageFormattedStrings {

        public static FormattedString GetMainPageContent(string location, RootObject weatherInfo) 
        {
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
                GetDefaultSpan("No city was chosen to be displayed.")
            }
        };

        private static FormattedString WrongCityFormattedString(string city) {
            return new FormattedString {
                Spans = {
                    GetDefaultSpan("City " + city + " does not exist.")
                }
            };
        }

        private static FormattedString InitializedFormattedString(RootObject weatherInfo) {
            return new FormattedString {
                Spans = {
                    GetDefaultSpan("Country: " + weatherInfo.sys.country + "\n\n"),
                    GetDefaultSpan("City Name: " + weatherInfo.name + "\n\n"),
                    GetDefaultSpan("DateTime: " + DateTime.Now + "\n\n"),
                    GetDefaultSpan("Coordinates: (" + weatherInfo.coord.lat + ", " + weatherInfo.coord.lon + ")" + "\n\n"),
                    GetDefaultSpan("Weather: " + weatherInfo.weather[0].main + "\n\n"),
                    GetDefaultSpan("Weather Description: " + weatherInfo.weather[0].description + "\n\n"),
                    GetDefaultSpan("Exact Temperature: " + weatherInfo.main.temp + " Kelvin\n\n"),
                    GetDefaultSpan("Temperature: ( " + weatherInfo.main.temp_min + " Kelvin, " + weatherInfo.main.temp_max + " Kelvin)" + "\n\n"),
                    GetDefaultSpan("Wind: (" + weatherInfo.wind.speed + " m/s, " + weatherInfo.wind.deg + " degrees)" + "\n\n"),
                    GetDefaultSpan("Pressure: " + weatherInfo.main.pressure + " hPa\n\n"),
                    GetDefaultSpan("Humidity: " + weatherInfo.main.humidity + "%\n\n"),
                }
            };
        }
    }
}
