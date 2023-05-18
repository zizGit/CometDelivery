using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CometFoodDelivery.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("shopName")]
        public string Shop { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("imageUrl")]
        public string imageUrl { get; set; }
    }

    public class ProductShopAndType 
    {
        public string? Shop { get; set; }
        public string Type { get; set; }
    }

    public class errorProductReturn
    {
        public int Status { get; } = 400;
        public string Error { get; } = "this product is already registered in this shop";
    }
}
