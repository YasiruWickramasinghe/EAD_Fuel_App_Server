namespace ASP.NET_Server.Models.StationModel
{
    public class StationStoreDatabaseSettings : IStationStoreDatabaseSettings
    {
        public string StationCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
