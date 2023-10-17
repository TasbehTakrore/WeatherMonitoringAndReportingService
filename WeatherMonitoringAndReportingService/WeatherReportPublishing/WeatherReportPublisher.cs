
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    internal class WeatherReportPublisher : IWeatherReportPublisher
    {
        private List<IWeatherObserver> weatherObservers = new List<IWeatherObserver>();

        public void Subscribe(IWeatherObserver observerBot)
        {
            weatherObservers.Add(observerBot);
        }
        public void Unsubscribe(IWeatherObserver observerBot)
        {
            weatherObservers.Remove(observerBot);
        }

        public void NotifySubscribers(WeatherData weatherData)
        {
            foreach (var weatherObserver in weatherObservers)
            {
                weatherObserver.Run(weatherData);
            }
        }

        public void ChangeWeatherData(WeatherData weatherData)
        {
            NotifySubscribers(weatherData);
        }
    }
}
