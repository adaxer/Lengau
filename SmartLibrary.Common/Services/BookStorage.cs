//using SmartLibrary.Common.Interfaces;
//using SQLite;

//namespace SmartLibrary.Common.Services;

//public class BookStorage : IBookStorage
//{
//    string _DBPath;
//    private SQLiteAsyncConnection _connection;
////    private readonly IMapper _mapper;

//    public BookStorage(IEventAggregator eventAggregator, IMapper mapper)
//    {
//        _DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppSettingsManager.Settings["DbName"]);
//        eventAggregator.GetEvent<BookSharedEvent>().Subscribe(SaveBook);
//        this._mapper = mapper;
//    }

//    private async void SaveBook(SavedBook book)
//    {
//        await GetConnection();
//        var entry = _mapper.Map<SavedBookEntry>(book);
//        await _connection.InsertAsync(entry);
//    }

//    public async Task<IEnumerable<SavedBookEntry>> GetSharedBooks()
//    {
//        await GetConnection();
//        return (await _connection.Table<SavedBookEntry>().ToListAsync());
//    }

//    private async Task<SQLiteAsyncConnection> GetConnection()
//    {
//        if (_connection == null)
//        {
//            _connection = new SQLiteAsyncConnection(_DBPath);
//            //var mapping = await _connection.GetMappingAsync<SavedBook>();
//            //mapping.SetAutoIncPK()
//            await _connection.CreateTableAsync<SavedBookEntry>();
//        }
//        return _connection;
//    }

//}
