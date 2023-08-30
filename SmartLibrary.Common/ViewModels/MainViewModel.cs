using System.Windows.Input;

namespace SmartLibrary.Common.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    string _title = "Willkommen zu SmartLibrary";

    [ObservableProperty]
    string _userName;

    [RelayCommand]
    private void UpdateTitle()
    {
        Title = $"Hallo {UserName}, willkommen zu SmartLibrary";
    }

}
