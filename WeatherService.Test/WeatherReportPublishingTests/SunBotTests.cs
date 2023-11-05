using AutoFixture.Xunit2;
using FluentAssertions;
using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherService.Test.WeatherReportPublishingTests
{
    public class SunBotTests
    {
        [Theory]
        [AutoData]
        public void Run_ShouldActivateBot_WhenTemperatureIsMoreThanThreshold(
            [Frozen] BotSettings botSettings, WeatherData weatherData,
            ConsoleOutputCapture consoleOutputCapture, SunBot sut)
        {
            //Arrange
            botSettings.TemperatureThreshold = 40;
            weatherData.Temperature = 45;

            //Act
            sut.Run(weatherData);
            var captureOutput = consoleOutputCapture.GetCapturedOutput();
            //Assert
            captureOutput.Should().NotBeNull();
            captureOutput.Should().Contain("SunBot activated!");
        }

        [Theory]
        [AutoData]
        public void Run_ShouldNotActivateBot_WhenTemperatureIsLessThanThreshold(
            [Frozen] BotSettings botSettings, WeatherData weatherData,
            ConsoleOutputCapture consoleOutputCapture, SunBot sut)
        {
            //Arrange
            botSettings.TemperatureThreshold = 40;
            weatherData.Temperature = 30;

            //Act
            sut.Run(weatherData);
            var captureOutput = consoleOutputCapture.GetCapturedOutput();
            //Assert
            captureOutput.Should().BeEmpty();
            captureOutput.Should().NotContain("SunBot activated!");
        }
    }
}
