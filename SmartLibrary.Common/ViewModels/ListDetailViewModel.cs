using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Models;
using SmartLibrary.Common.Services;

namespace SmartLibrary.Common.ViewModels;

public partial class ListDetailViewModel : BaseViewModel
{
	readonly SampleDataService dataService;
    private readonly INavigatorService navigator;

    [ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	ICollection<SampleItem> items;

	public ListDetailViewModel(SampleDataService service, INavigatorService navigator)
	{
		dataService = service;
        this.navigator = navigator;
    }

	[RelayCommand]
	private async void OnRefreshing()
	{
		IsRefreshing = true;

		try
		{
			await LoadDataAsync();
		}
		finally
		{
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	public async Task LoadMore()
	{
		var items = await dataService.GetItems();

		foreach (var item in items)
		{
			Items.Add(item);
		}
	}

	public async Task LoadDataAsync()
	{
		Items = new ObservableCollection<SampleItem>(await dataService.GetItems());
	}

	[RelayCommand]
	private async void GoToDetails(SampleItem item)
	{
		await navigator.GoToAsync(nameof(ListDetailDetailViewModel), new Dictionary<string, object>
		{
			{ "Item", item }
		});
	}
}
