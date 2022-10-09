using System;

namespace LocationWeather.Utils
{
    public class Messages : Constants
    {
        public static string GetNonExistingCityMessage(string city) {
            return CITY + city + DOES_NOT_EXIST;
        }

        public static string GetCountryMessage(string country) {
            return COUNTRY + country + BREAKLINE;
        }

        public static string GetCityMessage(string city) {
            return CITY_NAME + city + BREAKLINE;
        }

        public static string GetDatetimeMessage() {
            return DATETIME + DateTime.Now + BREAKLINE;
        }

        public static string GetCoordinateMessage(float lat, float lon) {
            return COORDINATES + lat + COMMA + lon + END_PARENTHESIS + BREAKLINE;
        }

        public static string GetWeatherStatusMessage(string weatherStatus) {
            return WEATHER + weatherStatus + BREAKLINE;
        }

        public static string GetWeatherDescriptionMessage(string weatherDescription) {
            return WEATHER_DESCRIPTION + weatherDescription + BREAKLINE;
        }

        public static string GetExactTemperatureMessage(float exactTemperature) {
            return EXACT_TEMPERATURE + exactTemperature + KELVIN + BREAKLINE;
        }

        public static string GetTemparatureRangeMessage(float minTemperature, float maxTemperature) {
            return TEMPERATURE + minTemperature + KELVIN + COMMA + maxTemperature + KELVIN + END_PARENTHESIS + BREAKLINE;
        }

        public static string GetWindMessage(float speed, float deg) {
            return WIND + speed + MPERS + COMMA + deg + DEGREES + END_PARENTHESIS + BREAKLINE;
        }

        public static string GetPressureMessage(int pressure) {
            return PRESSURE + pressure + HPA + BREAKLINE;
        }

        public static string GetHumidityMessage(int humidity) {
            return HUMIDITY + humidity + PER100 + BREAKLINE;
        }
    }
}
