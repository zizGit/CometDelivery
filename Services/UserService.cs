using CometFoodDelivery.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

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

        public string TokenCreate(string email) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", email) }),
                Expires = DateTime.UtcNow.AddDays(1),
                //Expires = DateTime.UtcNow.AddSeconds(30), //for test
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(authToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private class AuthOptions
        {
            const string Key = "secretTokenKey_75f20ca5491d8b37274290901f2c39b740293f7fb337591abd3";
            public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }

        public bool registrationAndUpdateRules(User user, ref registerData data)
        {
            var regex1 = new Regex(@"([a-z])");
            var regex2 = new Regex(@"([A-Z])");
            var regex3 = new Regex(@"([0 - 9])");
            //var regex4 = new Regex(@"([!,@,#,$,%,^,&,*,?,_,~])");
            string[] allowableEmail = { ".com", ".net", ".ua" };
            bool resultReturn = true;

            if (user.Pass.Length < 8 || !regex1.IsMatch(user.Pass) || !regex2.IsMatch(user.Pass) || !regex3.IsMatch(user.Pass))
            {
                resultReturn = false;
                data.Pass = "Your password is too easy";
            }
            if (user.Phone.ToString().Length != 12)
            {
                resultReturn = false;
                data.Phone = "Incorrect phone number";
            }
            if (!user.Email.Contains("@") || !allowableEmail.Any(x => user.Email.EndsWith(x)))
            {
                resultReturn = false;
                data.Email = "Incorrect Email";
            }
            if (!resultReturn) { return false; }
            return true;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }
        public async Task<User> GetAsync(string? id, string? email)
        {
            if (id != null) 
            {
                return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            }
            else
            {
                return await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
            }
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