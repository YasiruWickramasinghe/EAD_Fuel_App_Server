namespace ASP.NET_Server.Models.VehicleModel
{
    public interface IVehicleStoreDatabaseSettings
    {
        string VehicleCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
