namespace ASP.NET_Server.Models.StationStatus
{
    public interface IStatusStoreDatabaseSettings
    {
        string StatusCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
