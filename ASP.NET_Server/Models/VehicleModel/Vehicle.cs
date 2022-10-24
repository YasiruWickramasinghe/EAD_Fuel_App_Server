using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.NET_Server.Models.VehicleModel
{
    [BsonIgnoreExtraElements]
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("vehicleNo")]
        public string vehicleNo { get; set; } = String.Empty;

        [BsonElement("vehicleType")]
        public string vehicleType { get; set; } = String.Empty;

        [BsonElement("chassisNo")]
        public string chassisNo { get; set; } = String.Empty;

        [BsonElement("password")]
        public string password { get; set; } = String.Empty;

        [BsonElement("confirmPassword")]
        public string confirmPassword { get; set; } = String.Empty;

    }
}
