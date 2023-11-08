using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService
{
    public interface IBotSettingsReader
    {
        BotSettings GetBotSettings(string key);
    }
}