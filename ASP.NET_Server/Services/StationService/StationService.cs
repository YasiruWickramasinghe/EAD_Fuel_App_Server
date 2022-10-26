//Sri Lanka Institute of Information Technology
//   Year  :  4th Year 2nd Semester
//   Module Code  :  SE4040
//   Module  :  Enterprise Application Development
//   Group ID  :  25
//   Student Id Number  :  IT19051376
//   Name  :  Anjana W.W.M

using ASP.NET_Server.Models.StationModel;
using MongoDB.Driver;


namespace ASP.NET_Server.Services.StationService
{
    public class StationService : IStationServices
    {
        private readonly IMongoCollection<Station> _station;

        public StationService(IStationStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _station = database.GetCollection<Station>(settings.StationCollectionName);
        }
        public Station Create(Station station)
        {
            _station.InsertOne(station);
            return station;
        }

        public List<Station> Get()
        {
            return _station.Find(station => true).ToList();
        }

        public Station Get(string id)
        {
            return _station.Find(station => station.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _station.DeleteOne(station => station.Id == id);
        }

        public void Update(string id, Station station)
        {
            _station.ReplaceOne(station => station.Id == id, station);
        }
    }
}
