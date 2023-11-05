using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherService.Test.WeatherReportPublishingTests
{
    public class WeatherReportPublisherTests
    {
        [Theory]
        [AutoData]
        public void Subscribe_AddsObserverToWeatherObserversList(
            Mock<IWeatherObserver> mockObserver,
            WeatherReportPublisher sut)
        {
            //Act
            sut.Subscribe(mockObserver.Object);

            //Assert
            sut.GetSubscribers().Should().HaveCount(1);
            sut.GetSubscribers().Should().Contain(mockObserver.Object);
        }

        [Theory]
        [AutoMoqData]
        public void Subscribe_AddsObserversToWeatherObserversList(
            List<IWeatherObserver> mockObservers,
            WeatherReportPublisher sut)
        {
            //Act
            sut.Subscribe(mockObservers);

            //Assert
            sut.GetSubscribers().Should().Contain(mockObservers);
            sut.GetSubscribers().Should().HaveSameCount(mockObservers);
        }

        [Theory]
        [AutoMoqData]
        public void Unsubscribe_RemoveObserverFromWeatherObserversList(
            Mock<IWeatherObserver> mockObserver,
            WeatherReportPublisher sut)
        {
            //Arrange
            sut.Subscribe(mockObserver.Object);

            //Act
            sut.Unsubscribe(mockObserver.Object);

            //Assert
            sut.GetSubscribers().Should().NotContain(mockObserver.Object);
        }

        [Theory]
        [AutoMoqData]
        public void NotifySubscribers_Should_RunObservers(
            WeatherData weatherData,
            Mock<IWeatherObserver> mockObserver,
            WeatherReportPublisher sut)
        {
            //Arrange
            sut.Subscribe(mockObserver.Object);

            //Act
            sut.NotifySubscribers(weatherData);

            //Assert
            mockObserver.Verify(x => x.Run(weatherData), Times.Exactly(sut.GetSubscribers().Count()));
        }

        [Theory]
        [AutoMoqData]
        public void PublishData_Should_InvokeNotifySubscribers(
            Mock<IWeatherObserver> mockObserver,
            WeatherData weatherData,
            WeatherReportPublisher sut)
        {
            // Arrange
            sut.Subscribe(mockObserver.Object);

            // Act
            sut.PublishData(weatherData);

            // Assert
            mockObserver.Verify(x => x.Run(weatherData), Times.Once);
        }

    }
}
