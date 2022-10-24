using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.NET_Server.Models.QueueModel
{
    [BsonIgnoreExtraElements]
    public class Queue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("vehicleNo")]
        public string vehicleNo { get; set; } = String.Empty;

        [BsonElement("vehicleType")]
        public string vehicleType { get; set; } = String.Empty;

        [BsonElement("stationId")]
        public string stationId { get; set; } = String.Empty;

        [BsonElement("stationName")]
        public string stationName { get; set; } = String.Empty;

        [BsonElement("arrivalTime")]
        public string arrivalTime { get; set; } = String.Empty;

        [BsonElement("departTime")]
        public string departTime { get; set; } = String.Empty;

        [BsonElement("pumpStatus")]
        public string pumpStatus { get; set; } = String.Empty;
    }
}
