using CommunityToolkit.Mvvm.Messaging;
using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Messages;
using SmartLibrary.Common.Models;

namespace SmartLibrary.Common.ViewModels;

public partial class SearchViewModel : BaseViewModel, IRecipient<SharedBookMessage>
{
    private readonly INavigatorService navigator;
    private readonly IBookService bookService;

    public IBookShareClient ShareClient { get; }

    public SearchViewModel(INavigatorService navigator, IBookService bookService, IBookShareClient bookShareClient, IPubSubService pubSub)
    {
        Title = "Search";
        this.navigator = navigator;
        this.bookService = bookService;
        ShareClient = bookShareClient;
        pubSub.Subscribe<SharedBookMessage>(this);
    }

    [ObservableProperty]
    private string searchText;

    [ObservableProperty]
    string sharedBookInfo = "string.Empty";

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
    private async Task Search()
    {
        IsBusy = true;
        LastQuery = await bookService.BookQueryAsync(SearchText);
        Books = new ObservableCollection<Book>(LastQuery?.Books);
        IsBusy = false;
    }

    public void Receive(SharedBookMessage message)
    {
        var book = message.Value;
        SharedBookInfo = $"{book.UserName} shared {book.Title} on {book.SaveDate}. Pos {book.Location.Latitude:f2} {book.Location.Longitude:f2}, {book.Notes}"; ;
    }
}

