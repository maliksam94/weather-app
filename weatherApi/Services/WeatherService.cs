using System.Text.Json;
using sampleWebApi.Contracts;
using sampleWebApi.Models;

namespace sampleWebApi.Services;

/// <summary>
/// Service for fetching weather data from wttr.in API using IHttpClientFactory
/// </summary>
public class WeatherService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string WttrApiUrl = "https://wttr.in/{0}?format=j1"; // j1 means JSON format

    /// <summary>
    /// Initialize WeatherService with HttpClientFactory dependency
    /// </summary>
    /// <param name="httpClientFactory">Factory for creating HttpClient instances</param>
    public WeatherService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    /// <summary>
    /// Get weather information for a specific city
    /// </summary>
    /// <param name="city">City name (e.g., "London", "New York")</param>
    /// <returns>Weather forecast data as JSON element</returns>
    /// <exception cref="ArgumentException">Thrown when city name is null or empty</exception>
    /// <exception cref="HttpRequestException">Thrown when API request fails</exception>
    public async Task<WeatherResponse?> GetWeatherAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City name cannot be null or empty", nameof(city));
        }

        var client = _httpClientFactory.CreateClient();
        var url = string.Format(WttrApiUrl, Uri.EscapeDataString(city));

        using var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to fetch weather data for city '{city}'. Status code: {response.StatusCode}");
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var weatherData = JsonSerializer.Deserialize<WeatherResponse>(jsonContent, options);

        return weatherData;
    }
}
