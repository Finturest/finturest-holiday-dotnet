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

        var queryParams = new List<string>();

        if (type is not null)
        {
            queryParams.Add($"{RouteConstants.Type}={Uri.EscapeDataString(type.Value.ToString())}");
        }

        if (days.HasValue)
        {
            queryParams.Add($"{RouteConstants.Days}={days.Value}");
        }

        if (queryParams.Count > 0)
        {
            uri += $"?{string.Join("&", queryParams)}";
        }

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<HolidayModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

#if NET6_0_OR_GREATER
    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(DateOnly holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Holidays}/{RouteConstants.Search}/{RouteConstants.Date}/{holidayDate}";

        if (type is not null)
        {
            uri += $"?{RouteConstants.Type}={Uri.EscapeDataString(type.Value.ToString())}";
        }

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<HolidayModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, DateOnly holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Holidays}/{countryCode}/{RouteConstants.Search}/{RouteConstants.Date}/{holidayDate}";

        if (type is not null)
        {
            uri += $"?{RouteConstants.Type}={Uri.EscapeDataString(type.Value.ToString())}";
        }

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<HolidayModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }
#else
    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(DateTime holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Holidays}/{RouteConstants.Search}/{RouteConstants.Date}/{holidayDate:yyyy-MM-dd}";

        if (type is not null)
        {
            uri += $"?{RouteConstants.Type}={Uri.EscapeDataString(type.Value.ToString())}";
        }

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<HolidayModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, DateTime holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Holidays}/{countryCode}/{RouteConstants.Search}/{RouteConstants.Date}/{holidayDate:yyyy-MM-dd}";

        if (type is not null)
        {
            uri += $"?{RouteConstants.Type}={Uri.EscapeDataString(type.Value.ToString())}";
        }

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<HolidayModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }
#endif

    public async Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, int year, HolidayType? type = null, CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Holidays}/{countryCode}/{RouteConstants.Search}/{RouteConstants.Year}/{year}";

        if (type is not null)
        {
            uri += $"?{RouteConstants.Type}={Uri.EscapeDataString(type.Value.ToString())}";
        }

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<HolidayModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }
}
