//Sri Lanka Institute of Information Technology
//   Year  :  4th Year 2nd Semester
//   Module Code  :  SE4040
//   Module  :  Enterprise Application Development
//   Group ID  :  25
//   Student Id Number  :  IT19051376
//   Name  :  Anjana W.W.M

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ASP.NET_Server.Models.StationStatus
{
    [BsonIgnoreExtraElements]
    public class Status
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

        [BsonElement("startTime")]
        public string startTime { get; set; } = String.Empty;

        [BsonElement("endTime")]
        public string endTime { get; set; } = String.Empty;

        [BsonElement("date")]
        public string date { get; set; } = String.Empty;

        [BsonElement("fuelType")]
        public string fuelType { get; set; } = String.Empty;

        [BsonElement("availability")]
        public string availability { get; set; } = String.Empty;
    }
}
