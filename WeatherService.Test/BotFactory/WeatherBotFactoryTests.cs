using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService;
using WeatherMonitoringAndReportingService.BotFactory;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherService.Test.BotFactory
{
    public class WeatherBotFactoryTests
    {
        [Theory]
        [AutoMoqData]
        public void GetEnabledWeatherObservers_InvalidBotSettings_ThrowException(
            [Frozen] Mock<IBotSettingsReader> mockBotSettingsReader, WeatherBotFactory sut)
        {
            mockBotSettingsReader.Setup(reader => reader.GetBotSettings(It.IsAny<string>()))
                .Throws(new Exception());

            //Act & Assert
            Action Act = () => sut.GetEnabledWeatherObservers();
            Act.Should().Throw<Exception>().WithMessage(
                "Failed to create bots. An error occurred while initializing bot instances.");
        }

        [Theory]
        [AutoMoqData]
        public void GetEnabledWeatherObservers_Should_ReturnListOfIWeatherObserver(
            [Frozen] Mock<IBotSettingsReader> mockBotSettingsReader, WeatherBotFactory sut)
        {
            // Arrange
            mockBotSettingsReader.Setup(settingReader => settingReader.GetBotSettings("RainBot"))
                .Returns(new BotSettings
                {
                    Enabled = true,
                    HumidityThreshold = 70,
                    Message = "It looks like it's about to pour down!"
                });

            mockBotSettingsReader.Setup(settingReader => settingReader.GetBotSettings("SunBot"))
                .Returns(new BotSettings
                {
                    Enabled = true,
                    TemperatureThreshold = 30,
                    Message = "Wow, it's a scorcher out there!"
                });
            mockBotSettingsReader.Setup(settingReader => settingReader.GetBotSettings("SnowBot"))
                .Returns(new BotSettings
                {
                    Enabled = false,
                    TemperatureThreshold = 0,
                    Message = "Brrr, it's getting chilly!"
                });

            // Act
            var observers = sut.GetEnabledWeatherObservers();

            // Assert
            observers.Should().HaveCount(2);
        }
    }
}
