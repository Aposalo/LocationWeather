using OpenWeatherMap.repository;

namespace OpenWeatherMap.Model
{
    public class OpenWeatherMapModel
    {
        private readonly OpenWeatherMapRepository openWeatherMapRepository = new OpenWeatherMapRepository();
        private RootObject weatherInfo;

        public RootObject GetWeatherInfo(string location) {
            var response = openWeatherMapRepository.GetWeatherInfo(location);
            
            if (response.IsSuccessful)
                weatherInfo = response.Data;
            
            else
                weatherInfo = null;

            return weatherInfo;
        }
    }
}