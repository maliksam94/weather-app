using System.Text.Json.Serialization;

namespace sampleWebApi.Models;

public class WeatherResponse
{
    [JsonPropertyName("current_condition")]
    public List<CurrentCondition> CurrentCondition { get; set; } = new();
}

public class CurrentCondition
{
    public string? FeelsLikeC { get; set; }
    
    public string? FeelsLikeF { get; set; }

    public string? CloudCover { get; set; }

    public string? Humidity { get; set; }

    [JsonPropertyName("observation_time")]
    public string? ObservationTime { get; set; }

    public string? PrecipInches { get; set; }

    public string? PrecipMM { get; set; }

    public string? Pressure { get; set; }

    public string? PressureInches { get; set; }

    [JsonPropertyName("temp_C")]
    public string? TempC { get; set; }

    [JsonPropertyName("temp_F")]
    public string? TempF { get; set; }

    public string? UvIndex { get; set; }

    public string? Visibility { get; set; }

    public string? VisibilityMiles { get; set; }

    public string? WeatherCode { get; set; }

    public List<WeatherDescription> WeatherDesc { get; set; } = new();

    public List<WeatherIcon> WeatherIconUrl { get; set; } = new();

    public string? Winddir16Point { get; set; }

    public string? WinddirDegree { get; set; }

    public string? WindspeedKmph { get; set; }

    public string? WindspeedMiles { get; set; }
}

public class WeatherDescription
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}

public class WeatherIcon
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}