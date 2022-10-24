using ASP.NET_Server.Models.VehicleModel;
using MongoDB.Driver;


namespace ASP.NET_Server.Services.VehicleService
{
    public class VehicleService : IVehicleServices
    {
        private readonly IMongoCollection<Vehicle> _vehicle;

        public VehicleService(IVehicleStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _vehicle = database.GetCollection<Vehicle>(settings.VehicleCollectionName);
        }
        public Vehicle Create(Vehicle vehicle)
        {
            _vehicle.InsertOne(vehicle);
            return vehicle;
        }

        public List<Vehicle> Get()
        {
            return _vehicle.Find(vehicle => true).ToList();
        }

        public Vehicle Get(string id)
        {
            return _vehicle.Find(vehicle => vehicle.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _vehicle.DeleteOne(vehicle => vehicle.Id == id);
        }

        public void Update(string id, Vehicle vehicle)
        {
            _vehicle.ReplaceOne(vehicle => vehicle.Id == id, vehicle);
        }
    }
}
