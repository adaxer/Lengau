namespace SmartLibrary.Common.Models;

public class SavedBookEntry
{
   // [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string BookId { get; set; }
    public string Title { get; set; }
    public string UserName { get; set; }
    public DateTimeOffset SaveDate { get; set; }
    public string Notes { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}
