using Microsoft.EntityFrameworkCore;
using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Services;
using SmartLibrary.Data;

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

		builder.Services.AddLogging();

		builder.Services.AddSingleton<INavigatorService, NavigatorService>();
		builder.Services.AddSingleton<ILocationService, LocationService>();
		builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<IBookService, BookService>();
        builder.Services.AddSingleton<IRestService, RestService>();
		builder.Services.AddSingleton<IBookShareClient, BookShareClient>();
		builder.Services.AddSingleton<IBookStorage, BookStorage>();
        builder.Services.AddSingleton<IPubSubService,PubSubService>();

		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<SearchViewModel>();
		builder.Services.AddSingleton<SearchPage>();

        builder.Services.AddTransient<DetailsViewModel>();
        builder.Services.AddTransient<DetailsPage>();

        builder.Services.AddSingleton<NewsViewModel>();
        builder.Services.AddSingleton<NewsPage>();

        builder.Services.AddTransient(sp => sp.GetRequiredService<IBookShareClient>() as IRequireInitializeAsync);
        builder.Services.AddDbContext<BooksContext>(options =>
                options.UseSqlite("Filename=Books.db"));

        return builder.Build();
	}
}
