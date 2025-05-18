namespace Finturest.Holiday.Options;

/// <summary>
/// Represents configuration options for accessing the Finturest Holiday API.
/// </summary>
public record HolidayOptions
{
    /// <summary>
    /// Gets or sets the API key used to authenticate requests to the Finturest Holiday API.
    /// This property is required.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string ApiKey { get; set; }
#else
    public string ApiKey { get; set; } = null!;
#endif

    /// <summary>
    /// Gets or sets the base URL of the Finturest Holiday API.
    /// Defaults to <c>https://api.finturest.com/</c>.
    /// </summary>
    public string BaseAddress { get; set; } = "https://api.finturest.com/";
}
