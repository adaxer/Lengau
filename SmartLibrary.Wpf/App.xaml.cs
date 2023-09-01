using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Services;
using SmartLibrary.Common.ViewModels;
using SmartLibrary.Data;
using SmartLibrary.Wpf.Views;
using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartLibrary.Wpf.Services;

namespace SmartLibrary.Wpf;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;
    private IServiceProvider _container;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(services);
                _container = services.BuildServiceProvider();
            })
            .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Add services here
        services.AddSingleton<INavigatorService, WpfNavigatorService>();
        services.AddSingleton<IBookService, BookService>();
		services.AddSingleton<ILocationService, WpfLocationService>();
		services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IRestService, RestService>();
        services.AddSingleton<IBookShareClient, BookShareClient>();
		services.AddSingleton<IBookStorage, BookStorage>();
        services.AddSingleton<IPubSubService,WpfPubSubService>();


        services.AddSingleton<ShellViewModel>();
        services.AddSingleton<ShellWindow>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainView>();

        services.AddSingleton<SearchViewModel>();
        services.AddSingleton<SearchView>();

        services.AddTransient<DetailsViewModel>();
        services.AddTransient<DetailsView>();

        services.AddSingleton<NewsViewModel>();
        services.AddSingleton<NewsView>();

        services.AddTransient(sp => sp.GetRequiredService<IBookShareClient>() as IRequireInitializeAsync);
        services.AddDbContext<BooksContext>(options =>
                options.UseSqlite("Filename=Books.db"));
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();
        LateInitialize();

        var mainWindow = _host.Services.GetRequiredService<ShellWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    private void LateInitialize()
    {
        _container.GetService<IEnumerable<IRequireInitializeAsync>>().ToList().ForEach(a=>a.InitializeAsync());
        _container.GetService<IEnumerable<IRequireInitialize>>().ToList().ForEach(i=>i.Initialize());
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }

        base.OnExit(e);
    }
}
