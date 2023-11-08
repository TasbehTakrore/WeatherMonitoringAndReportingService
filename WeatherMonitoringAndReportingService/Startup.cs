using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.BotFactory;
using WeatherMonitoringAndReportingService.DataHandling;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService
{
    public static class Startup
    {
        public static object CreateAndSubscribeWeatherReportPublisher()
        {
            throw new NotImplementedException();
        }

        public static (IDataParser, IWeatherReportPublisher, IDataReader) InitializeWeatherMonitoringService()
        {
            IConfiguration configuration = BuildConfiguration();
            BotSettingsReader botSettingReader = new BotSettingsReader(configuration);
            IWeatherBotFactory weatherBotFactory = new WeatherBotFactory(botSettingReader);
            List<IDataParsingStrategy> parsingStrategies = new List<IDataParsingStrategy>
            {
                new XmlParsingStrategy(),
                new JsonParsingStrategy()
            };
            IDataParser dataParser = new DataParser(parsingStrategies);
            IDataReader dataReader = new DataReader();
            return (dataParser, CreateAndSubscribeWeatherReportPublisher(weatherBotFactory), dataReader);
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static WeatherReportPublisher CreateAndSubscribeWeatherReportPublisher(IWeatherBotFactory factory)
        {
            WeatherReportPublisher weatherReportPublisher = new WeatherReportPublisher();
            var bots = factory.GetEnabledWeatherObservers();
            weatherReportPublisher.Subscribe(bots);
            return weatherReportPublisher;
        }
    }
}
