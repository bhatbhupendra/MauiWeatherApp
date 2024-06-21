using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWeatherApp.MVVM.Models
{

	public class WeatherData
	{
		public float latitude { get; set; }
		public float longitude { get; set; }
		public float generationtime_ms { get; set; }
		public int utc_offset_seconds { get; set; }
		public string timezone { get; set; }
		public string timezone_abbreviation { get; set; }
		public int elevation { get; set; }
		public Daily_Units daily_units { get; set; }
		public Daily daily { get; set; }
	}

	public class Daily_Units
	{
		public string time { get; set; }
		public string weather_code { get; set; }
		public string temperature_2m_max { get; set; }
		public string temperature_2m_min { get; set; }
	}

	public class Daily
	{
		public string[] time { get; set; }
		public int[] weather_code { get; set; }
		public float[] temperature_2m_max { get; set; }
		public float[] temperature_2m_min { get; set; }
	}

}
