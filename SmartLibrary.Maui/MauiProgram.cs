using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Services;
using SmartLibrary.Common.ViewModels;

namespace SmartLibrary.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<INavigatorService, NavigatorService>();	

		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddSingleton<ListDetailViewModel>();
		builder.Services.AddSingleton<ListDetailPage>();

		builder.Services.AddTransient<ListDetailDetailViewModel>();
		builder.Services.AddTransient<ListDetailDetailPage>();

		return builder.Build();
	}
}
