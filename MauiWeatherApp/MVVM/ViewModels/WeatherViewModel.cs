﻿using MauiWeatherApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiWeatherApp.MVVM.ViewModels
{
	public class WeatherViewModel
	{
		public WeatherData WeatherData {  get; set; }
		private HttpClient client;

		public WeatherViewModel()
		{
			client = new HttpClient();
		}


		public ICommand SearchCommand => new Command(async (searchText) =>
		{
			var loaction = await GetCoordinatesAsync(searchText.ToString());
			await GetWeather(loaction);
		});

		private async Task GetWeather(Location location)
		{
			var url = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&daily=weather_code,temperature_2m_max,temperature_2m_min";
			var response =
				 await client.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				using (var responseStream = await response.Content.ReadAsStreamAsync())
				{
					var data = await JsonSerializer
						 .DeserializeAsync<WeatherData>(responseStream);
					WeatherData = data;
				}
			}
		}

		private async Task<Location> GetCoordinatesAsync(string address)
		{
			IEnumerable<Location> locations = await Geocoding
				 .Default.GetLocationsAsync(address);

			Location? location = locations?.FirstOrDefault();

			if (location != null)
				Console
					 .WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
			return location;
		}
	}
}
