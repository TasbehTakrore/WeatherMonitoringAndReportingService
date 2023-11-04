
namespace WeatherMonitoringAndReportingService.Models
{
    public class BotSettings
    {
        public bool Enabled { get; set; }
        public int TemperatureThreshold { get; set; }
        public int HumidityThreshold { get; set; }
        public string Message { get; set; }
    }
}
