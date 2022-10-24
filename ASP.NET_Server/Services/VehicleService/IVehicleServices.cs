using ASP.NET_Server.Models.VehicleModel;

namespace ASP.NET_Server.Services.VehicleService
{
    public interface IVehicleServices
    {
        List<Vehicle> Get();
        Vehicle Get(string id);
        Vehicle Create(Vehicle vehicle);
        void Update(string id, Vehicle vehicle);
        void Remove(string id);
    }
}
