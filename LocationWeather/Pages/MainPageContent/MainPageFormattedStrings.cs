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

        public static FormattedString NoCityFormattedString = new FormattedString
        {
            Spans = {
                    new Span {
                        TextColor = Color.LimeGreen,
                        Text = "No city was chosen to be displayed."
                    }
                }
        };

        public static FormattedString WrongCityFormattedString(string city) {
            return new FormattedString {
                Spans = {
                    new Span {
                        TextColor = Color.LimeGreen,
                        Text = "City " + city + " does not exist."
                    }
                }
            };
        }

        public static FormattedString InitializedFormattedString(RootObject weatherInfo) {
            return new FormattedString {
                Spans = {
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text = "Country: " + weatherInfo.sys.country + "\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text = "City Name: " + weatherInfo.name + "\n\n"
                        },
                        new Span
                        {
                            TextColor = Color.LimeGreen,
                            Text = "DateTime: " + DateTime.Now + "\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text = "Coordinates: (" + weatherInfo.coord.lat + ", " + weatherInfo.coord.lon + ")" + "\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text =  "Weather: " + weatherInfo.weather[0].main + "\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text = "Weather Description: " + weatherInfo.weather[0].description + "\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text = "Exact Temperature: " + weatherInfo.main.temp + "\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text = "Temperature: ( " + weatherInfo.main.temp_min + " Kelvin, " + weatherInfo.main.temp_max + " Kelvin)" + "\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text = "Wind: (" + weatherInfo.wind.speed + " m/s, " + weatherInfo.wind.deg + " degrees)" + "\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text =  "Pressure: " + weatherInfo.main.pressure + " hPa\n\n"
                        },
                        new Span {
                            TextColor = Color.LimeGreen,
                            Text = "Humidity: " + weatherInfo.main.humidity + "%\n\n"
                        },
                    }
            };
        }
    }
}
