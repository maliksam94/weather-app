import { Routes } from '@angular/router';
import { WeatherUi } from './weather/weather-ui/weather-ui';

export const routes: Routes = [
  { path: '', redirectTo: 'weather', pathMatch: 'full' },
  { path: 'weather', component: WeatherUi },
  { path: '**', redirectTo: 'weather' }
];
