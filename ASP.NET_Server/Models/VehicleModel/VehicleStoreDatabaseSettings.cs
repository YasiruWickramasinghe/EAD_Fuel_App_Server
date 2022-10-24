namespace ASP.NET_Server.Models.VehicleModel
{
    public class VehicleStoreDatabaseSettings : IVehicleStoreDatabaseSettings
    {
        public string VehicleCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
