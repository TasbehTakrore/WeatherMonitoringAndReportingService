
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    public interface IWeatherObserver
    {
        public void Run(WeatherData weatherData);
    }
}
