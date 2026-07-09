import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { finalize } from 'rxjs/operators';
import { WeatherService } from '../../service/weather-service';
import { CurrentCondition } from '../../models/weather-response';

@Component({
  selector: 'app-weather-ui',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './weather-ui.html',
  styleUrls: ['./weather-ui.css'],
})
export class WeatherUi {
  city = 'London';

  loading = signal(false);
  error = signal('');
  weather = signal<CurrentCondition | null>(null);

  constructor(
    private readonly weatherService: WeatherService
  ) {}

  getWeather(): void {
    this.loading.set(true);
    this.error.set('');
    this.weather.set(null);

    this.weatherService.getWeather(this.city).pipe(
        finalize(() => this.loading.set(false))
      )
      .subscribe({
        next: (response) => {
          this.weather.set(response.current_condition?.[0] ?? null);
        },
        error: () => {
          this.error.set('Failed to load weather data.');
        }
      });      
  }
}
