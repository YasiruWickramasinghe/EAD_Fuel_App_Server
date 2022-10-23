using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ASP.NET_Server.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("Courses")]
        public string[]? Courses { get; set; }

    }
}
