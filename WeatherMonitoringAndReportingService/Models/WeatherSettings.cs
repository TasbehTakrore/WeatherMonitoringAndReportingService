
namespace WeatherMonitoringAndReportingService.Models
{
    internal class WeatherSettings
    {
        public bool Enabled { get; set; }
        public int HumidityThreshold { get; set; }
        public string Message { get; set; }
    }
}
