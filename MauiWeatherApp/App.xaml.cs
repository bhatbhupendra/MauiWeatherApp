using MauiWeatherApp.MVVM.Views;

namespace MauiWeatherApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new WeatherView();
		}
	}
}
