using System;
using System.Net;
using System.Net.Http;

using Finturest.Holiday.Abstractions.Models.Enums;

namespace Finturest.Holiday.IntegrationTests;

public partial class HolidayServiceClientIntegrationTests
{
    [Theory]
    [InlineData("PL", -100, null)]
    [InlineData("PL", 2000, null)]
    public async Task GetUpcomingHolidaysAsync_DaysParameterIsNotValid_EnsureBadRequestStatusCode(string countryCode, int? days, HolidayType? type)
    {
        // Act
        Func<Task> action = async () => await _sut.GetUpcomingHolidaysAsync(countryCode, days, type).ConfigureAwait(false);

        // Assert
#if NET5_0_OR_GREATER
        var assertion = await action.ShouldThrowAsync<HttpRequestException>();

        assertion.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
#else
        await action.ShouldThrowAsync<HttpRequestException>();
#endif
    }

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

    [Theory]
    [InlineData("PL", 1, HolidayType.Observance)]
    public async Task GetUpcomingHolidaysAsync_HolidaysDontExist_ReturnCorrectResult(string countryCode, int? days, HolidayType? type)
    {
        // Act
        var result = await _sut.GetUpcomingHolidaysAsync(countryCode, days, type);

        // Assert
        result.ShouldBeEmpty();
    }
}
