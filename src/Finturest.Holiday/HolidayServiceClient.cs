using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using Finturest.Holiday.Abstractions;
using Finturest.Holiday.Abstractions.Models;
using Finturest.Holiday.Abstractions.Models.Enums;
using Finturest.Holiday.Constants;

namespace Finturest.Holiday;

public class HolidayServiceClient : IHolidayServiceClient
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public HolidayServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }

    public async Task<IReadOnlyList<HolidayModel>> GetUpcomingHolidaysAsync(string countryCode, int? days = null, HolidayType? type = null, CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Holidays}/{countryCode}/{RouteConstants.Upcoming}";

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<HolidayModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

#if NET6_0_OR_GREATER
    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(DateOnly holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default)
    {
    }

    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, DateOnly holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default)
    {
    }
#else
    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(DateTime holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default)
    {

    }

    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, DateTime holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default)
    {

    }
#endif

    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, int year, HolidayType? type = null, CancellationToken cancellationToken = default)
    {

    }
}
