using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Messages;

namespace SmartLibrary.Common.ViewModels;

public partial class NewsViewModel : BaseViewModel, IRecipient<SharedBookMessage>, IRecipient<BookSavedMessage>
{
    private readonly INavigatorService navigator;
    private readonly IBookStorage storage;

    public NewsViewModel(INavigatorService navigator, IBookStorage storage, IPubSubService pubSub)
    {
        Title = "Shared Pages";
        this.navigator = navigator;
        this.storage = storage;
        pubSub.Subscribe<SharedBookMessage>(this);
        pubSub.Subscribe<BookSavedMessage>(this);
        LoadData();
    }

    [ObservableProperty]
    ICollection<SavedBook> savedBooks;

    [ObservableProperty]
    ICollection<SavedBook> sharedBooks =new ObservableCollection<SavedBook>();

    public async void LoadData()
    {
        IsBusy = true;
        SavedBooks = new ObservableCollection<SavedBook>(await storage.GetSavedBooks());
        IsBusy = false;
    }

    public void Receive(SharedBookMessage message)
    {
        SharedBooks.Add(message.Value);
    }

    public void Receive(BookSavedMessage message)
    {
        LoadData();
    }
}
