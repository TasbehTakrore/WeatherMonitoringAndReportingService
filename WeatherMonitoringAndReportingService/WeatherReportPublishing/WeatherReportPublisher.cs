
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    public class WeatherReportPublisher : IWeatherReportPublisher
    {
        private List<IWeatherObserver> weatherObservers = new List<IWeatherObserver>();

        public void Subscribe(IWeatherObserver observerBot)
        {
            weatherObservers.Add(observerBot);
        }
        public void Subscribe(List<IWeatherObserver> observerBots)
        {
            weatherObservers.AddRange(observerBots);
        }
        public void Unsubscribe(IWeatherObserver observerBot)
        {
            weatherObservers.Remove(observerBot);
        }
        public List<IWeatherObserver> GetSubscribers()
        {
            return weatherObservers;
        }
        public void NotifySubscribers(WeatherData weatherData)
        {
            foreach (var weatherObserver in weatherObservers)
            {
                weatherObserver.Run(weatherData);
            }
        }
        public void PublishData(WeatherData weatherData)
        {
            NotifySubscribers(weatherData);
        }
    }
}
