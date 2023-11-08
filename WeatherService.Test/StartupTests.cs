using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService;
using WeatherMonitoringAndReportingService.BotFactory;
using WeatherMonitoringAndReportingService.DataHandling;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherService.Test
{
    public class StartupTests
    {
        [Theory]
        [AutoMoqData]
        public void InitializeWeatherMonitoringService_Should_ReturnInitializationObjects(
            Mock<IWeatherBotFactory> mockWeatherBotFactory,
            RainBot rainBot,
            SunBot sunBot)
        {
            //Arrange
            mockWeatherBotFactory.Setup(weatherBotFactory => weatherBotFactory.GetEnabledWeatherObservers())
                .Returns(
                new List<IWeatherObserver>
                {
                    rainBot, sunBot
                });

            //Act
            var result = Startup.InitializeWeatherMonitoringService();

            //Assert
            result.Should().NotBeNull();
            result.Item1.Should().BeOfType<DataParser>();
            result.Item2.Should().BeOfType<WeatherReportPublisher>();
            result.Item3.Should().BeOfType<DataReader>();
        }
    }
}
