using LocationWeather.Repositories;

namespace LocationWeather.Models
{
    public class OpenWeatherMapModel {
        
        private readonly OpenWeatherMapRepository openWeatherMapRepository = new OpenWeatherMapRepository();
        private RootObject weatherInfo;

        public RootObject GetWeatherInfo(string location) {
            var response = openWeatherMapRepository.GetWeatherInfo(location);
            weatherInfo = response.IsSuccessful ? weatherInfo = response.Data : null;
            return weatherInfo;
        }
    }
}