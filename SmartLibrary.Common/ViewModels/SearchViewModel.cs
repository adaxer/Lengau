using SmartLibrary.Common.Interfaces;

namespace SmartLibrary.Common.ViewModels;

public partial class SearchViewModel : BaseViewModel
{
    private readonly INavigatorService navigator;
    private readonly IBookService bookService;

    public IBookShareClient ShareClient { get; }

    public SearchViewModel(INavigatorService navigator, IBookService bookService, IBookShareClient bookShareClient)
    {
        Title = "Search";
        this.navigator = navigator;
        this.bookService = bookService;
        ShareClient = bookShareClient;
        //eventAggregator.GetEvent<BookSharedEvent>().Subscribe(b => Title = b.Title); // Per Event
    }

    [ObservableProperty]
    private string searchText;

    [ObservableProperty]
    ICollection<Book> books;


    [RelayCommand]
    async Task ShowBook(Book book)
    {
      await  navigator.GoToAsync(nameof(DetailsViewModel), new Dictionary<string, object> { ["BookId"] = book.Id });
    }

    [ObservableProperty]
    BookQuery lastQuery;

    [RelayCommand]
    private async void Search()
    {
        IsBusy = true;
        LastQuery = await bookService.BookQueryAsync(SearchText);
        Books = new ObservableCollection<Book>(LastQuery?.Books);
        IsBusy = false;
    }
}

