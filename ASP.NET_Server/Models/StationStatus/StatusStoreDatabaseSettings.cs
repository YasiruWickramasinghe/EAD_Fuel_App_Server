namespace ASP.NET_Server.Models.StationStatus
{
    public class StatusStoreDatabaseSettings : IStatusStoreDatabaseSettings
    {
        public string StatusCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
