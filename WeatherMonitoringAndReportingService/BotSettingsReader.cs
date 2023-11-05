using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService
{
    public class BotSettingsReader : IBotSettingsReader
    {
        private readonly IConfiguration _configuration;
        public BotSettingsReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public BotSettings GetBotSettings(string key)
        {
            var botSettings = _configuration.GetSection(key).Get<BotSettings>();
            if (botSettings == null)
            {
                throw new Exception($"No BotSettings found for key '{key}'");
            }
            return botSettings;
        }
    }
}
