using Amazon.Runtime.Credentials.Internal;
using CometFoodDelivery.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace CometFoodDelivery.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<User> _collection;

        public UsersService(IOptions<UserDatabaseSettings> databaseSettings, IOptions<DatabaseConnectionStringSettings> connectionSettings)
        {
            var client = new MongoClient(connectionSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = database.GetCollection<User>(databaseSettings.Value.CollectionName);
        }

        public string TokenCreate(User user) 
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };

            // create JWT-token
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationOptions = new TokenValidationParameters();

            if (authToken != null & tokenHandler.CanReadToken(authToken) & authToken?.Length == 348)
            {
                var jwtSecurityToken = tokenHandler.ReadJwtToken(authToken);
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationOptions, out validatedToken);

                if (principal?.Identity?.Name != null)
                {
                    return true; // Token is valid
                }

                else
                {
                    return false; // Token is expired
                }
            }
            return false; // Token is damaged



            //var tokenHandler = new JwtSecurityTokenHandler();
            //var validationParameters = GetValidationParameters();

            //var options = new TokenValidationParameters();

            //SecurityToken validatedToken;
            //IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            //return true;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }
        public async Task<User> GetAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> GetEmailAsync(string email)
        {
            return await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
        }
        public async Task<User> CreateAsync(User newUser)
        {
            await _collection.InsertOneAsync(newUser);
            return newUser;
        }
        public async Task UpdateAsync(string id, User updatedUser)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedUser);
        }
        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}