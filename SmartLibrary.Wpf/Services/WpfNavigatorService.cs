using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace SmartLibrary.Wpf.Services;

public class WpfNavigatorService : INavigatorService
{
    Dictionary<string, Dictionary<string, object>> currentParameters = new();
    private readonly IServiceProvider serviceProvider;
    Dictionary<string, Type> navTargets = new Dictionary<string, Type>()
    {
        ["DetailsViewModel"] = typeof(DetailsViewModel)
    };

    public WpfNavigatorService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task GoToAsync(string targetViewModel, Dictionary<string, object> parameters)
    {
        var shell = Application.Current.MainWindow.DataContext as ShellViewModel;
        Type targetType = navTargets[targetViewModel];
        currentParameters[targetViewModel] = parameters;
        shell.CurrentViewModel = serviceProvider.GetService(targetType) as BaseViewModel;
        return Task.CompletedTask;
    }

    public Dictionary<string, object> NavigationParameters(string targetViewModel)
    {
        if (currentParameters.TryGetValue(targetViewModel, out var savedParameters))
        {
            currentParameters.Clear();
            return savedParameters;
        }
        return null;
    }

    private string GetViewName(string targetViewModel)
    {
        return targetViewModel.Replace("ViewModel", "View");
    }
}