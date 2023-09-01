using Microsoft.EntityFrameworkCore;
using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Messages;
using SmartLibrary.Common.Models;
using SmartLibrary.Data;

namespace SmartLibrary.Common.Services;

public class BookStorage : IBookStorage
{
    private readonly BooksContext context;
    private readonly IPubSubService pubSubService;

    public BookStorage(BooksContext context, IPubSubService pubSub)
    {
        this.context = context;
        pubSubService = pubSub;

    }

    public async Task SaveBook(SavedBook book)
    {
        var existingBook = await context.SavedBooks.FindAsync(book.BookId);
        if (existingBook == null)
        {
            context.SavedBooks.Add(book);
        }
        else
        {
            context.Entry(existingBook).CurrentValues.SetValues(book);
        }
        pubSubService.Publish(new BookSavedMessage(book));
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SavedBook>> GetSavedBooks()
    {
        return await context.SavedBooks.ToListAsync();
    }
}
