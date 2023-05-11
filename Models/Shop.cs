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
        public int Url { get; set; }

        [BsonElement("types")]
        public string type { get; set; }

        [BsonElement("deliveryCost")]
        public string Cost { get; set; }

        [BsonElement("deliveryTime")]
        public string Time { get; set; }
    }
}
