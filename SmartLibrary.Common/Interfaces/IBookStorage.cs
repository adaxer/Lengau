namespace SmartLibrary.Common.Interfaces;

public interface IBookStorage
{
    Task<IEnumerable<SavedBookEntry>> GetSharedBooks();
}
