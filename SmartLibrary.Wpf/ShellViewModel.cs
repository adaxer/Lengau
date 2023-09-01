using CommunityToolkit.Mvvm.ComponentModel;
using SmartLibrary.Common.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartLibrary.Wpf;
public partial class ShellViewModel : BaseViewModel
{
    public ShellViewModel(MainViewModel main, SearchViewModel search, NewsViewModel news)
    {
        MainViewModel = main;
        SearchViewModel = search;
        NewsViewModel = news;
        modules = new ObservableCollection<BaseViewModel> {  main,search,news };
    }

    [ObservableProperty]
    MainViewModel mainViewModel;

    [ObservableProperty]
    SearchViewModel searchViewModel;

    [ObservableProperty]
    NewsViewModel newsViewModel;

    [ObservableProperty]
    ICollection<BaseViewModel> modules;

    [ObservableProperty]
    BaseViewModel currentViewModel;
}
