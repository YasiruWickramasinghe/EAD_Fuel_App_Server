using ASP.NET_Server.Models.StationModel;
using ASP.NET_Server.Models.StationStatus;
using MongoDB.Driver;

namespace ASP.NET_Server.Services.StationStatus
{
    public class StatusSevice : IStatusService
    {
        private readonly IMongoCollection<Status> _status;

        public StatusSevice(IStatusStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _status = database.GetCollection<Status>(settings.StatusCollectionName);
        }

        public Status Create(Status status)
        {

            _status.InsertOne(status);
            return status;
        }

        public List<Status> Get()
        {
            return _status.Find(status => true).ToList();
        }

        public List<Status> GetByStation(string name)
        {
            return _status.Find(status => status.stationName == name).ToList();
        }

        public Status Get(string id)
        {
            return _status.Find(status => status.Id == id).FirstOrDefault();
        }

        public Status GetByDate(string date)
        {
            return _status.Find(status => status.date == date).FirstOrDefault();
        }

        public Status GetByType(string type)
        {
            return _status.Find(status => status.fuelType == type).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _status.DeleteOne(status => status.Id == id);
        }

        public void Update(string id, Status status)
        {
            _status.ReplaceOne(status => status.Id == id, status);
        }
    }
}
