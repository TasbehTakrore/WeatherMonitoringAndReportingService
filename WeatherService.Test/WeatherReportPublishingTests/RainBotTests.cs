using AutoFixture.Xunit2;
using FluentAssertions;
using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherService.Test.WeatherReportPublishingTests
{
    public class RainBotTests
    {
        [Theory]
        [AutoData]
        public void Run_ShouldActivateBot_WhenHumidityIsMoreThanThreshold(
            [Frozen] BotSettings botSettings, WeatherData weatherData,
            ConsoleOutputCapture consoleOutputCapture, RainBot sut)
        {
            //Arrange
            botSettings.HumidityThreshold = 70;
            weatherData.Humidity = 75;

            //Act
            sut.Run(weatherData);
            var captureOutput = consoleOutputCapture.GetCapturedOutput();
            //Assert
            captureOutput.Should().NotBeNull();
            captureOutput.Should().Contain("RainBot activated!");
        }

        [Theory]
        [AutoData]
        public void Run_ShouldNotActivateBot_WhenHumidityIsLessThanThreshold(
            [Frozen] BotSettings botSettings, WeatherData weatherData,
            ConsoleOutputCapture consoleOutputCapture, RainBot sut)
        {
            //Arrange
            botSettings.HumidityThreshold = 70;
            weatherData.Humidity = 50;

            //Act
            sut.Run(weatherData);
            var captureOutput = consoleOutputCapture.GetCapturedOutput();
            //Assert
            captureOutput.Should().BeEmpty();
            captureOutput.Should().NotContain("RainBot activated!");
        }
    }
}
