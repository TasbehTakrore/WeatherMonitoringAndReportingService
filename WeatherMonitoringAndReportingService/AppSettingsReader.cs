
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
            return _configuration.GetSection(key).Get<WeatherSettings>() ?? new WeatherSettings();
        }
    }
}
