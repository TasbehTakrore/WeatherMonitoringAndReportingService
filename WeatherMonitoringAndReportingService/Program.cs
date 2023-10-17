
using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.DataParsing;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            var appSettingReader = new BotSettingsReader(configuration);
            WeatherReportPublisher weatherReportPublisher = new WeatherReportPublisher();
            var rainBot = new RainBot(appSettingReader.GetBotSettings("RainBot"));
            var SunBot = new SunBot(appSettingReader.GetBotSettings("SunBot"));
            var SnowBot = new SnowBot(appSettingReader.GetBotSettings("SnowBot"));
            weatherReportPublisher.Subscribe(rainBot);
            weatherReportPublisher.Subscribe(SunBot);
            weatherReportPublisher.Subscribe(SnowBot);
            while (true)
            {
                try
                {
                    string data = Console.ReadLine();
                    DataParsingStrategyFactory factory = new DataParsingStrategyFactory();
                    var parsingStrategy = factory.CreateDataParsingStrategy(data);
                    var parser = new DataParserContext(parsingStrategy);
                    var result = parser.ParseData(data);
                    Console.WriteLine(result);
                    weatherReportPublisher.ChangeWeatherData(result);

                }
                catch(Exception e)
                {
                    Console.WriteLine($"An exception occurred: {e.Message}");
                }

            }

        }
    }
}
