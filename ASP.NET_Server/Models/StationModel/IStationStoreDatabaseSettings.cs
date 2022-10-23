namespace ASP.NET_Server.Models.StationModel
{
    public interface IStationStoreDatabaseSettings
    {
        string StationCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
