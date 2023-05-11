using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CometFoodDelivery.Models
{
    public class Shop
    {
        // ? - значение null допустимо
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
}