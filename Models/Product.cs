using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CometFoodDelivery.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("NameAndPrice")]
        public List<ProductsNameAndPrice> ProductNameAndPrice { get; set; }
    }

    public class ProductsNameAndPrice
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }
    }
}
