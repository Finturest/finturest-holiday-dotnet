namespace Finturest.Holiday.Abstractions.Models;

/// <summary>
/// Represents the basic identifying information for a country, compliant with ISO 3166-1 standards.
/// </summary>
public record CountryBasicModel
{
    /// <summary>
    /// The official country name as defined by ISO 3166-1.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Name { get; init; }
#else
    public string Name { get; set; } = null!;
#endif

    /// <summary>
    /// The country's name in its native language or script.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string LocalName { get; init; }
#else
    public string LocalName { get; set; } = null!;
#endif

    /// <summary>
    /// A two-character country code compliant with ISO 3166-1 alpha-2 (e.g., "US", "DE").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Alpha2Code { get; init; }
#else
    public string Alpha2Code { get; set; } = null!;
#endif

    /// <summary>
    /// A three-character country code compliant with ISO 3166-1 alpha-3 (e.g., "USA", "DEU").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Alpha3Code { get; init; }
#else
    public string Alpha3Code { get; set; } = null!;
#endif

    /// <summary>
    /// A three-digit numeric country code as per ISO 3166-1 (e.g., "840", "276").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string NumericCode { get; init; }
#else
    public string NumericCode { get; set; } = null!;
#endif
}
