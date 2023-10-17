
using Microsoft.Extensions.Configuration;

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
            Console.WriteLine(appSettingReader.GetWeatherSettings("RainBot"));
        }
    }
}
