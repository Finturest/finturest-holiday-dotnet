using Finturest.Holiday.Abstractions.Models.Enums;

namespace Finturest.Holiday.IntegrationTests;

public partial class HolidayServiceClientIntegrationTests
{
    [Theory]
    [InlineData("PL", null, null)]
    [InlineData("PL", 700, null)]
    [InlineData("PL", 700, HolidayType.Public)]
    public async Task GetUpcomingHolidaysAsync_HolidaysExist_ReturnCorrectResult(string countryCode, int? days, HolidayType? type)
    {
        // Act
        var result = await _sut.GetUpcomingHolidaysAsync(countryCode, days, type);

        // Assert
        result.ShouldNotBeEmpty();

        foreach (var holiday in result)
        {
            holiday.Name.ShouldNotBeNullOrEmpty();
            holiday.LocalName.ShouldNotBeNullOrEmpty();

            holiday.Country.ShouldNotBeNull();

            holiday.Country.Name.ShouldNotBeNullOrEmpty();
            holiday.Country.Alpha2Code.ShouldNotBeNullOrEmpty();
            holiday.Country.Alpha3Code.ShouldNotBeNullOrEmpty();
            holiday.Country.NumericCode.ShouldNotBeNullOrEmpty();

            holiday.Types.ShouldNotBeEmpty();
        }
    }
}
