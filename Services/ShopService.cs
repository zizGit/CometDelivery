using CometFoodDelivery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CometFoodDelivery.Services
{
    public class ShopService
    {
        private readonly IMongoCollection<Shop> _collection;

        public ShopService(IOptions<ShopsDatabaseSettings> databaseSettings, IOptions<DatabaseConnectionStringSettings> connectionSettings)
        {
            var client = new MongoClient(connectionSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = database.GetCollection<Shop>(databaseSettings.Value.CollectionName);
        }

        public shopReturn returnWith200(Shop shop)
        {
            var shopReturn = new shopReturn();
            shopReturn.Id = shop.Id;
            shopReturn.Name = shop.Name;
            shopReturn.imageUrl = shop.imageUrl;
            shopReturn.Types = shop.Types;
            shopReturn.Sections = shop.Sections;
            shopReturn.deliveryCost = shop.deliveryCost;
            shopReturn.deliveryTime = shop.deliveryTime;
            return shopReturn;
        }

        public async Task<List<Shop>> GetAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }
        public async Task<Shop> GetAsync(string name)
        {
            return await _collection.Find(x => x.Name == name).FirstOrDefaultAsync();
        }
        public async Task<List<shopReturn>> GetSearchAsync(string name)
        {
            var temp = await _collection.Find(x => true).ToListAsync();
            var resultReturn = new List<shopReturn>();

            foreach(var shop in temp) 
            {
                if(shop.Name.ToLower().StartsWith(name.ToLower())) 
                {
                    resultReturn.Add(returnWith200(shop));
                }
            }
            return resultReturn;
        }
        public async Task<List<Shop>> GetByTypeAsync(string type)
        {
            return await _collection.Find(x => x.Types.Contains(type)).ToListAsync();
        }
        public async Task<Shop> CreateAsync(Shop newShop)
        {
            await _collection.InsertOneAsync(newShop);
            return newShop;
        }
        public async Task UpdateAsync(string name, Shop updatedShop)
        {
            await _collection.ReplaceOneAsync(x => x.Name == name, updatedShop);
        }
        public async Task DeleteAsync(string name)
        {
            await _collection.DeleteOneAsync(x => x.Name == name);
        }
    }
}
