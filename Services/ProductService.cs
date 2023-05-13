using CometFoodDelivery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CometFoodDelivery.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _collection;
        private readonly IMongoCollection<ProductsNameAndPrice> _nameAndPriceCollection;

        public ProductService(IOptions<ProductsDatabaseSettings> databaseSettings, IOptions<DatabaseConnectionStringSettings> connectionSettings)
        {
            var client = new MongoClient(connectionSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = database.GetCollection<Product>(databaseSettings.Value.CollectionName);
            _nameAndPriceCollection = database.GetCollection<ProductsNameAndPrice>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }
        public async Task<Product> GetAsync(string type)
        {
            return await _collection.Find(x => x.Type == type).FirstOrDefaultAsync();
        }
        public async Task<Product> GetByShopAsync(string shop)
        {
            return await _collection.Find(x => x.Shop == shop).FirstOrDefaultAsync();
        }


        public async Task<ProductsNameAndPrice> GetByNameAsync(string shop, string name)
        {
            var temp = GetByShopAsync(shop);
            

            return await _nameAndPriceCollection.Find(x => x.Name == name).FirstOrDefaultAsync();
        }








        public async Task<Product> CreateAsync(Product newProduct)
        {
            await _collection.InsertOneAsync(newProduct);
            return newProduct;
        }
        public async Task UpdateAsync(string name, Product updatedProduct, ProductsNameAndPrice name2)
        {
            await _collection.ReplaceOneAsync(x => x.Type == name, updatedProduct);
        }
        public async Task DeleteAsync(string name)
        {
            await _collection.DeleteOneAsync(x => x.Type == name);
        }
    }
}
