using SmartLibrary.Common.Interfaces;
using System.Diagnostics;
using System.Windows.Input;

namespace SmartLibrary.Common.ViewModels;

public partial class DetailsViewModel : BaseViewModel
{
    private readonly IBookService _bookService;
    private readonly IBookShareClient _bookShareClient;
    private readonly ILocationService _locationService;
    private readonly IUserService _userService;

    public DetailsViewModel(INavigatorService navigationService, IBookService bookService, IBookShareClient bookShareClient)//, ILocationService locationService, IUserService userService) 
    {
        _bookService = bookService;
        _bookShareClient = bookShareClient;
        //_locationService = locationService;
        //_userService = userService;
        //eventAggregator.GetEvent<BookSharedEvent>().Subscribe(b => Title = b.Title); // Per Event
        if (navigationService.NavigationParameters(nameof(DetailsViewModel)) is { } parameters)
        {
            if (parameters.TryGetValue("BookId", out var id))
            {
                LoadBook(id?.ToString());
            }
        }
    }

    private async void LoadBook(string id)
    {
        Title = "Hole Info für Book " + id;
        IsBusy = true;
        Book = await _bookService.GetBookDetailsAsync(id);
        Title = Book?.Info?.Title;
        IsBusy = false;
    }

    [ObservableProperty]
    Book book;

    [RelayCommand]
    private void Save()
    {
        var location = new Location();
        //try
        //{
        //    location = await _locationService.GetLocationQuick();
        //}
        //catch (Exception)
        //{
        //    Debug.WriteLine("Location not possible");
        //}
        string notes = "Notizen";
        SavedBook savedBook = new SavedBook
        {
            BookId = Book?.Id,
            Title = Book?.Info?.Title,
            SaveDate = DateTimeOffset.Now,
            // UserName = _userService.IsLoggedIn ? _userService.UserName : "somebody",
            Notes = notes,
            Location = location
        };
        //await _bookShareClient.ShareBook(savedBook);
    }
}