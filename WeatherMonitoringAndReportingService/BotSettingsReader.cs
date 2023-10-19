
using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService
{
    internal class BotSettingsReader
    {
        private readonly IConfiguration _configuration;
        public BotSettingsReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public BotSettings GetBotSettings(string key)
        {
            try
            {
                return _configuration.GetSection(key).Get<BotSettings>();
            }
            catch
            {
                throw new Exception($"No BotSettings found for key '{key}'");
            }
        }
    }
}
