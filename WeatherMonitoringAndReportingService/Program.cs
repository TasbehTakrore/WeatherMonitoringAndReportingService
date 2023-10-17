
using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.DataParsing;

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

            var appSettingReader = new AppSettingsReader(configuration);
            while (true)
            {
                try
                {
                    string data = Console.ReadLine();
                    DataParsingStrategyFactory factory = new DataParsingStrategyFactory();
                    var parsingStrategy = factory.CreateDataParsingStrategy(data);
                    var parser = new DataParserContext(parsingStrategy);
                    var result = parser.ParseData(data);
                    Console.WriteLine(result.Temperature);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"An exception occurred: {e.Message}");
                }

            }

        }
    }
}
