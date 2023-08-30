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
		builder.Services.AddSingleton<IBookService, BookService>();
        builder.Services.AddSingleton<IRestService, RestService>();
		builder.Services.AddSingleton<IBookShareClient, BookShareClient>();

		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<SearchViewModel>();
		builder.Services.AddSingleton<SearchPage>();

		builder.Services.AddTransient<DetailsViewModel>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
