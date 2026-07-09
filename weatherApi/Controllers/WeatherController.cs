using Microsoft.AspNetCore.Mvc;
using sampleWebApi.Contracts;

namespace sampleWebApi.Controllers
{
    /// <summary>
    /// Controller for weather forecast API endpoints
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        /// <summary>
        /// Initialize WeatherController with weather service dependency
        /// </summary>
        /// <param name="weatherService">Weather service for fetching weather data</param>
        public WeatherController(
            IWeatherService weatherService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
        }

        /// <summary>
        /// Get weather forecast information for a specific city
        /// </summary>
        /// <param name="city">City name (e.g., "London", "New York", "Tokyo")</param>
        /// <returns>Weather forecast data from wttr.in API</returns>
        /// <response code="200">Weather data successfully retrieved</response>
        /// <response code="400">Invalid city name provided</response>
        /// <response code="404">Weather data not found for the specified city</response>
        /// <response code="500">Internal server error occurred while fetching weather data</response>
        [HttpGet]
        public async Task<IActionResult> GetWeather([FromQuery] string city)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(city))
                {
                    return BadRequest(new { message = "City name cannot be empty" });
                }

                var weatherData = await _weatherService.GetWeatherAsync(city);
                
                if (weatherData == null || weatherData.CurrentCondition == null || weatherData.CurrentCondition.Count == 0)
                {
                    return NotFound(new { message = $"Weather data not found for city: {city}" });
                }

                return Ok(weatherData);
            }            
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }

        
    }
}
