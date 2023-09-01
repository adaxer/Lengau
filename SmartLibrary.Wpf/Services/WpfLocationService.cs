using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Models;
using System;
using System.Threading.Tasks;

namespace SmartLibrary.Wpf;

public class WpfLocationService : ILocationService
{
    public Task<Location> GetLocationQuick()
    {
        throw new NotSupportedException("No location on wpf");
    }
}