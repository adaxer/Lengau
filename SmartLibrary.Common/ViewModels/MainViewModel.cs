using SmartLibrary.Common.Interfaces;
using System.Windows.Input;

namespace SmartLibrary.Common.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel(IUserService userService)
    {
        this.userService = userService;
    }

    [ObservableProperty]
    string _title = "Willkommen zu SmartLibrary";

    [ObservableProperty]
    string _userName;

    private readonly IUserService userService;

    [RelayCommand]
    private void UpdateUser()
    {
        userService.UserName = UserName;
        Title = $"Hallo {UserName}, willkommen zu SmartLibrary";
    }

}
