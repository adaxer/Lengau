using SmartLibrary.Common.Interfaces;
using Loc = SmartLibrary.Common.Models.Location;

namespace SmartLibrary.Maui.Services;

public class LocationService : ILocationService
{
    public async Task<Loc> GetLocationQuick()
    {
        var result = await Geolocation.GetLocationAsync();
        return new Loc { Longitude = result.Longitude, Latitude = result.Latitude };
    }
}
