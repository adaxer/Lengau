using Newtonsoft.Json;
using SmartLibrary.Common.Interfaces;
using System.Text;

namespace SmartLibrary.Common.Services;

public class RestService : IRestService
{
    public async Task<T> GetDataAsync<T>(string url) where T : class
    {
        using (var client = new HttpClient())
        {
            try
            {
                string json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }
    }

    public async Task<T> PostDataAsync<T>(string url, T payload) where T : class
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
