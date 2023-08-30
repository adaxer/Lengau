using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using SmartLibrary.Common.Interfaces;
using System.Diagnostics;

namespace SmartLibrary.Common.Services;

public class BookShareClient : IBookShareClient
{
    private HubConnection _connection;
    //private IEventAggregator _events;

    public string LastBookInfo { get; private set; }

    public BookShareClient()//IEventAggregator events)
    {
      //  _events = events;
    }

    public async Task Initialize()
    {
        try
        {
            _connection = new HubConnectionBuilder()
                .WithUrl($"bookshub")
                .Build();

            _connection.On<string>("BookShared", OnBookShared);
            await _connection.StartAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }

    private void OnBookShared(string json)
    {
        var book = JsonConvert.DeserializeObject<SavedBook>(json);
        LastBookInfo = $"{book.UserName} shared {book.Title} on {book.SaveDate}. Pos {book.Location.Latitude:f2} {book.Location.Longitude:f2}, {book.Notes}";
       // _events.GetEvent<BookSharedEvent>().Publish(book);
    }

    public async Task<bool> ShareBook(SavedBook book)
    {
        try
        {
            if(_connection.State == HubConnectionState.Disconnected)
            {
                await Initialize();
            }
            await _connection.InvokeAsync("ShareBook", JsonConvert.SerializeObject(book));
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
