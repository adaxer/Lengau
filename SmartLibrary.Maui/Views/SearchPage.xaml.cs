namespace SmartLibrary.Maui.Views;

public partial class SearchPage : ContentPage
{
	SearchViewModel ViewModel;

	public SearchPage(SearchViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}
}
