namespace SmartLibrary.Common.Interfaces;

public interface IUserService
{
    string UserName { get; }
    bool IsLoggedIn { get; }
}
