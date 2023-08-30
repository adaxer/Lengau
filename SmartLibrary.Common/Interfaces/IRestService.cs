namespace SmartLibrary.Common.Interfaces;

public interface IRestService
{
    Task<T> GetDataAsync<T>(string url) where T : class;
    Task<T> PostDataAsync<T>(string url, T payload) where T : class;
}
