using SmartLibrary.Common.Interfaces;

namespace SmartLibrary.Common.ViewModels;

public partial class ListDetailDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;

    public ListDetailDetailViewModel(INavigatorService navigatorService)
    {
        if(navigatorService.NavigationParameters(nameof(ListDetailDetailViewModel)) is { } parameters)
        {
            item= parameters["Item"] as SampleItem;
        }
    }
}
