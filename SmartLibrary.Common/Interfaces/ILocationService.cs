namespace SmartLibrary.Common.Interfaces;

public interface ILocationService
{
    Task<Location> GetLocationQuick();
}
