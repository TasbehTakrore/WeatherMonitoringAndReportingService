using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.BotFactory;
using WeatherMonitoringAndReportingService.DataHandling;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService
{
    internal static class Startup
    {
        public static (DataParser, WeatherReportPublisher, DataReader) InitializeWeatherMonitoringService()
        {
            IConfiguration configuration = BuildConfiguration();
            BotSettingsReader botSettingReader = new BotSettingsReader(configuration);
            WeatherBotFactory weatherBotFactory = new WeatherBotFactory(botSettingReader);
            List<IDataParsingStrategy> parsingStrategies = new List<IDataParsingStrategy>
            {
                new XmlParsingStrategy(),
                new JsonParsingStrategy()
            };
            DataParser dataParser = new DataParser(parsingStrategies);
            DataReader dataReader = new DataReader();
            return (dataParser, CreateAndSubscribeWeatherReportPublisher(weatherBotFactory), dataReader);
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static WeatherReportPublisher CreateAndSubscribeWeatherReportPublisher(WeatherBotFactory factory)
        {
            WeatherReportPublisher weatherReportPublisher = new WeatherReportPublisher();
            var bots = factory.GetEnabledWeatherObservers();
            weatherReportPublisher.Subscribe(bots);
            return weatherReportPublisher;
        }
    }
}
