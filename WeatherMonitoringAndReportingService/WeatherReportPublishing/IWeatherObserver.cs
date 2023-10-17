
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    internal interface IWeatherObserver
    {
        public void Run(WeatherData weatherData);
    }
}
