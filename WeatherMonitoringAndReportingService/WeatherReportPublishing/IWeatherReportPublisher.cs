using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    public interface IWeatherReportPublisher
    {
        void PublishData(WeatherData weatherData);
        void NotifySubscribers(WeatherData weatherData);
        void Subscribe(IWeatherObserver observerBot);
        void Unsubscribe(IWeatherObserver observerBot);
    }
}