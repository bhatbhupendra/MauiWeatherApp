using MauiWeatherApp.MVVM.ViewModels;

namespace MauiWeatherApp.MVVM.Views;

public partial class WeatherView : ContentPage
{
	public WeatherView()
	{
		InitializeComponent();
		BindingContext = new WeatherViewModel();
	}
}