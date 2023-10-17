
using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService
{
    internal class AppSettingsReader
    {
        private readonly IConfiguration _configuration;
        public AppSettingsReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public WeatherSettings GetWeatherSettings(string key)
        {
            try
            {
                return _configuration.GetSection(key).Get<WeatherSettings>();
            }
            catch (Exception ex)
            {
                throw new Exception($"No WeatherSettings found for key '{key}'", ex);
            }
        }
    }
}
