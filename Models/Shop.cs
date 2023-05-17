using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CometFoodDelivery.Models
{
    public class Shop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("imageUrl")]
        public string imageUrl { get; set; }

        [BsonElement("types")]
        public List<string> types { get; set; }

        [BsonElement("deliveryCost")]
        public double deliveryCost { get; set; }

        [BsonElement("deliveryTime")]
        public List<int> deliveryTime { get; set; }
    }
    public class shopReturn
    {
        public int Status { get; } = 200;
        public string? Id { get; set; }
        public string Name { get; set; }
        public string imageUrl { get; set; }
        public List<string> types { get; set; }
        public double deliveryCost { get; set; }
        public List<int> deliveryTime { get; set; }
    }
}