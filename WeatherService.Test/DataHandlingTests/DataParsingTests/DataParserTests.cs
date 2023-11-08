using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherService.Test.DataHandlingTests.DataParsingTests
{
    public class DataParserTests
    {
        [Theory]
        [AutoMoqData]
        public void ParseData_NoSuitableStrategy_ThrowsException(
          [Frozen] Mock<IDataParsingStrategy> mockStrategy,
          string invalidData,
          DataParser sut)
        {
            // Arrange
            mockStrategy.Setup(strategy => strategy.IsDataCompatible(invalidData)).Returns(false);

            // Act and Assert
            Action act = () => sut.ParseData(invalidData);
            act.Should().Throw<Exception>()
                .WithMessage("Failed to determine a suitable parsing strategy for the provided data.");
        }

        [Theory]
        [AutoMoqData]
        public void ParseData_ValidData_ReturnsParsedData(
          [Frozen] Mock<IDataParsingStrategy> mockStrategy,
          string validData,
          WeatherData expectedResult,
          DataParser sut)
        {
            //Arrange
            mockStrategy.Setup(strategy => strategy.IsDataCompatible(validData)).Returns(true);
            mockStrategy.Setup(strategy => strategy.ParseData(validData)).Returns(expectedResult);

            //Act
            var parsedData = sut.ParseData(validData);

            //Assert
            parsedData.Should().Be(expectedResult);
        }
    }
}
