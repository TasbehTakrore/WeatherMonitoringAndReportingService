using FluentAssertions;
using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService;

namespace WeatherService.Test
{
    public class BotSettingsReaderTests
    {
        [Theory]
        [InlineData("RainBot")]
        [InlineData("SunBot")]
        public void GetBotSettings_Should_ReturnBotSettings(string key)
        {
            //Act
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var botSettingsReader = new BotSettingsReader(configuration);

            //Act
            var botSettings = botSettingsReader.GetBotSettings(key);

            //Assert
            botSettings.Should().NotBeNull();
        }

        [Fact]
        public void GetBotSettings_InvalidKey_ThrowException()
        {
            // Arrange
            var wrongKey = "NoBot";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var botSettingsReader = new BotSettingsReader(configuration);

            // Act and Assert
            Action act = () => botSettingsReader.GetBotSettings(wrongKey);
            act.Should().Throw<Exception>().WithMessage($"No BotSettings found for key '{wrongKey}'");
        }
    }
}
