using SmartLibrary.Common.Interfaces;

namespace SmartLibrary.Common.Services;

public class BookService : IBookService
{
    IRestService _rest;
    //IDataService _dataService;

    public BookService(IRestService rest)//, IDataService data)
    {
        _rest = rest;
        //_dataService = data;
    }

    public async Task<BookQuery> BookQueryAsync(string text)
    {
        var result = await _rest.GetDataAsync<BookQuery>
            (string.Format("https://www.googleapis.com/books/v1/volumes?q={0}&maxResults=40", text));

        return result;

    }

    public async Task<Book> GetBookDetailsAsync(string id)
    {
        //var entry = (await _dataService.GetEntries()).FirstOrDefault(e => e.BookId == id);
        //string notes = entry == null
        //    ? string.Empty
        //    : entry.Notes;

        Book book = await _rest.GetDataAsync<Book>(string.Format("https://www.googleapis.com/books/v1/volumes/{0}", id));

        return book;
    }

    public async Task SaveBookAsync(SavedBook book)
    {
        await _rest.PostDataAsync<SavedBook>("", book);
    }

    //public Task UploadBookAsync(Book book, string notes)
    //{
    //    throw new NotImplementedException();
    //}
}
