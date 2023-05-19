using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CometFoodDelivery.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("phone")]
        public long Phone { get; set; }

        [BsonElement("adress")]
        public string Adress { get; set; } = null!;

        [BsonElement("payment")]
        public string Payment { get; set; } = null!;

        [BsonElement("products")]
        public List<string> Products { get; set; } = null!;
    }
    public class orderReturn
    {
        public int Status { get; } = 200;
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public long Phone { get; set; }
        public string Adress { get; set; } = null!;
        public string Payment { get; set; } = null!;
        public List<string> Products { get; set; } = null!;
    }

    public class orderData
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
    public class orderErrorReturn
    {
        public int Status { get; } = 400;
        public orderData? Errors { get; set; }
    }
}