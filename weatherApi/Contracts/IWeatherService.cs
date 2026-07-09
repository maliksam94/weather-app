using sampleWebApi.Models;

namespace sampleWebApi.Contracts;

/// <summary>
/// Interface for weather data retrieval service
/// </summary>
public interface IWeatherService
    {
        /// <summary>
        /// Get weather information for a specific city from wttr.in API
        /// </summary>
        /// <param name="city">City name (e.g., "London", "New York")</param>
        /// <returns>Weather forecast data as JSON</returns>
        Task<WeatherResponse?> GetWeatherAsync(string city);
    }