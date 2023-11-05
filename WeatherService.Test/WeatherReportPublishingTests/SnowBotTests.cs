using AutoFixture.Xunit2;
using FluentAssertions;
using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherService.Test.WeatherReportPublishingTests
{
    public class SnowBotTests
    {
        [Theory]
        [AutoData]
        public void Run_ShouldActivateBot_WhenTemperatureIsLessThanThreshold(
            [Frozen] BotSettings botSettings, WeatherData weatherData,
            SnowBot sut)
        {
            //Arrange
            botSettings.TemperatureThreshold = 0;
            weatherData.Temperature = -2;

            var writer = new StringWriter();
            Console.SetOut(writer);

            //Act
            sut.Run(weatherData);
            var consoleOutput = writer.ToString();
            //Assert
            consoleOutput.Should().NotBeNull();
            consoleOutput.Should().Contain("SnowBot activated!");
        }

        [Theory]
        [AutoData]
        public void Run_ShouldNotActivateBot_WhenTemperatureIsMoreThanThreshold(
            [Frozen] BotSettings botSettings, WeatherData weatherData,
            ConsoleOutputCapture consoleOutputCapture, SnowBot sut)
        {
            //Arrange
            botSettings.TemperatureThreshold = 0;
            weatherData.Temperature = 10;

            //Act
            sut.Run(weatherData);
            var captureOutput = consoleOutputCapture.GetCapturedOutput();
            //Assert
            captureOutput.Should().BeEmpty();
            captureOutput.Should().NotContain("SnowBot activated!");
        }
    }
}
