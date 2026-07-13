export interface WeatherResponse {
  current_condition: CurrentCondition[];
}

export interface CurrentCondition {
  observation_time?: string;
  temp_C?: string;
  temp_F?: string;
  feelsLikeC?: string;
  feelsLikeF?: string;
  weatherDesc?: { value?: string }[];
  humidity?: string;
  cloudCover?: string;
  uvIndex?: string;
  windspeedKmph?: string;
  winddir16Point?: string;
  pressure?: string;
}