using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CometFoodDelivery.Models
{
    public class User
    {
        // ? - значение null допустимо
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("age")]
        public int? Age { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("pass")]
        public string Pass { get; set; }

        [BsonElement("phone")]
        public long Phone { get; set; }
    }

    public class UserLogin
    {
        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("pass")]
        public string Pass { get; set; }
    }

    public class loginData
    {
        public int Status { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }

    public class registerData
    {
        public int Status { get; set; } = 200;
        public string Email { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}