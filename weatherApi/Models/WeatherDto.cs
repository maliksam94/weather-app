using System.Text.Json.Serialization;

namespace sampleWebApi.Models;

public class WeatherResponse
{
    [JsonPropertyName("current_condition")]
    public List<CurrentCondition> CurrentCondition { get; set; } = new();
}

public class CurrentCondition
{
    [JsonPropertyName("FeelsLikeC")]
    public string? FeelsLikeC { get; set; }

    [JsonPropertyName("FeelsLikeF")]
    public string? FeelsLikeF { get; set; }

    [JsonPropertyName("cloudcover")]
    public string? Cloudcover { get; set; }

    [JsonPropertyName("humidity")]
    public string? Humidity { get; set; }

    [JsonPropertyName("observation_time")]
    public string? ObservationTime { get; set; }

    [JsonPropertyName("precipInches")]
    public string? PrecipInches { get; set; }

    [JsonPropertyName("precipMM")]
    public string? PrecipMM { get; set; }

    [JsonPropertyName("pressure")]
    public string? Pressure { get; set; }

    [JsonPropertyName("pressureInches")]
    public string? PressureInches { get; set; }

    [JsonPropertyName("temp_C")]
    public string? TempC { get; set; }

    [JsonPropertyName("temp_F")]
    public string? TempF { get; set; }

    [JsonPropertyName("uvIndex")]
    public string? UvIndex { get; set; }

    [JsonPropertyName("visibility")]
    public string? Visibility { get; set; }

    [JsonPropertyName("visibilityMiles")]
    public string? VisibilityMiles { get; set; }

    [JsonPropertyName("weatherCode")]
    public string? WeatherCode { get; set; }

    [JsonPropertyName("weatherDesc")]
    public List<WeatherDescription> WeatherDesc { get; set; } = new();

    [JsonPropertyName("weatherIconUrl")]
    public List<WeatherIcon> WeatherIconUrl { get; set; } = new();

    [JsonPropertyName("winddir16Point")]
    public string? Winddir16Point { get; set; }

    [JsonPropertyName("winddirDegree")]
    public string? WinddirDegree { get; set; }

    [JsonPropertyName("windspeedKmph")]
    public string? WindspeedKmph { get; set; }

    [JsonPropertyName("windspeedMiles")]
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