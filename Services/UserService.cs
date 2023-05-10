using CometFoodDelivery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CometFoodDelivery.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<User> _collection;

        public UsersService(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);

            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            _collection = database.GetCollection<User>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<User>> GetAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }
        public async Task<User> GetAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
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