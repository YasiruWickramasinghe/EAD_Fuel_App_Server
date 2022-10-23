using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.NET_Server.Models.StationModel
{
    [BsonIgnoreExtraElements]
    public class Station
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("stationName")]
        public string stationName { get; set; } = String.Empty;

        [BsonElement("stationNo")]
        public string stationNo { get; set; } = String.Empty;

        [BsonElement("stationOwnerName")]
        public string stationOwnerName { get; set; } = String.Empty;

        [BsonElement("stationOwnerEmail")]
        public string stationOwnerEmail { get; set; } = String.Empty;

        [BsonElement("password")]
        public string password { get; set; } = String.Empty;

        [BsonElement("confirmPassword")]
        public string confirmPassword { get; set; } = String.Empty;
    }
}
