import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {WeatherResponse} from '../models/weather-response'

@Injectable({ providedIn: 'root' })
export class WeatherService {
  baseUrl = 'http://localhost:5053/api/Weather';

  constructor(private readonly http: HttpClient) {}

  getWeather(city: string): Observable<WeatherResponse> {
    const params = new HttpParams().set('city', city);
    return this.http.get<WeatherResponse>(this.baseUrl, { params });
  }
}