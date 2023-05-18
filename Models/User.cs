﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CometFoodDelivery.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("pass")]
        public string Pass { get; set; } = null!;

        [BsonElement("phone")]
        public long Phone { get; set; }
    }
    public class UserLogin
    {
        public string? Email { get; set; } = null!;
        public string? Pass { get; set; } = null!;
        public string? Token { get; set; } = null!;
    }
    
    public class getUserData
    {
        public string? Id { get; set; } = null!;
        public string? Email { get; set; } = null!;
    }
    public class loginData
    {
        public int Status { get; set; } = 200;
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
    public class registerData
    {
        public string? Email { get; set; }
        public string? Pass { get; set; }
        public string? Phone { get; set; }
        public string? Age { get; set; }
    }

    public class errorReturn
    {
        public int Status { get; } = 400;
        public registerData? Errors { get; set; }
    }
    public class errorEmailReturn
    {
        public int Status { get; } = 400;
        public string Error { get; } = "this email is already registered";
    }
    public class userReturn 
    {
        public int Status { get; } = 200;
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string Email { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public long Phone { get; set; }
    }
}