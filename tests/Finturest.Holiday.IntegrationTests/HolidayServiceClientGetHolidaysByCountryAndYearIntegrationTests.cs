using System.Net;
using System.Net.Http;

using Finturest.Holiday.Abstractions.Models.Enums;

namespace Finturest.Holiday.IntegrationTests;

public partial class HolidayServiceClientIntegrationTests
{
    [Theory]
    [InlineData("PL", -1, null)]
    public async Task GetHolidaysByCountryAndYearAsync_YearParameterIsNotValid_EnsureBadRequestStatusCode(string countryCode, int year, HolidayType? type)
    {
        // Act
        Func<Task> action = async () => await _sut.GetHolidaysAsync(countryCode, year, type).ConfigureAwait(false);

        // Assert
#if NET5_0_OR_GREATER
        var assertion = await action.ShouldThrowAsync<HttpRequestException>();

        assertion.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
#else
        await action.ShouldThrowAsync<HttpRequestException>();
#endif
    }

    [Theory]
    [InlineData("PL", 2025, null)]
    [InlineData("PL", 2025, HolidayType.Public)]
    public async Task GetHolidaysByCountryAndYearAsync_HolidaysExist_ReturnCorrectResult(string countryCode, int year, HolidayType? type)
    {
        // Act
        var result = await _sut.GetHolidaysAsync(countryCode, year, type);

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

    [Theory]
    [InlineData("PL", 2024, HolidayType.Observance)]
    public async Task GetHolidaysByCountryAndYearAsync_HolidaysDontExist_ReturnCorrectResult(string countryCode, int year, HolidayType? type)
    {
        // Act
        var result = await _sut.GetHolidaysAsync(countryCode, year, type);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public async Task GetHolidaysByCountryAndYearAsync_CountryParamIsNotValid_ReturnCorrectResult()
    {
        // Act
        var result = await _sut.GetHolidaysAsync(countryCode: "PLTY", year: 2025);

        // Assert
        result.ShouldBeEmpty();
    }
}
