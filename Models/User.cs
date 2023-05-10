using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
//using System.Text.Json.Serialization;

namespace CometFoodDelivery.Models
{
    public class User
    {
        // ? или = null! - значение null допустимо
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }
    }
}