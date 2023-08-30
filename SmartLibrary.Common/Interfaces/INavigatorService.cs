namespace SmartLibrary.Common.Interfaces;
public interface INavigatorService
{
    Dictionary<string, object> NavigationParameters(string targetViewModel);
    Task GoToAsync(string targetViewModel, Dictionary<string, object> parameters);
}
