using CometFoodDelivery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CometFoodDelivery.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductService(IOptions<ProductsDatabaseSettings> databaseSettings, IOptions<DatabaseConnectionStringSettings> connectionSettings)
        {
            var client = new MongoClient(connectionSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = database.GetCollection<Product>(databaseSettings.Value.CollectionName);
            //_nameAndPriceCollection = database.GetCollection<ProductsNameAndPrice>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }    
        public async Task<List<Product>> GetByShopAndTypeAsync(string shop, string type)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Type, type) & Builders<Product>.Filter.Eq(x => x.Shop, shop);
            return await _collection.Find(filter).ToListAsync();          
        }
        public async Task<List<Product>> GetByShopAndSectionAsync(string shop, string section)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Section, section) & Builders<Product>.Filter.Eq(x => x.Shop, shop);
            return await _collection.Find(filter).ToListAsync();
        }
        public async Task<Product> GetByShopTypeNameAsync(string shop, string type, string name)
        {
            var temp = await _collection.Find(x => x.Shop == shop).FirstOrDefaultAsync();
            if (temp == null) { return null; }
            var filter = Builders<Product>.Filter.Eq(x => x.Name, name)
                       & Builders<Product>.Filter.Eq(x => x.Shop, shop)
                       & Builders<Product>.Filter.Eq(x => x.Type, type);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<Product>> GetByShopAsync(string shop)
        {
            return await _collection.Find(x => x.Shop == shop).ToListAsync();
        }
        public async Task<List<Product>> GetByTypeAsync(string type)
        {
            return await _collection.Find(x => x.Type == type).ToListAsync();
        }
        
        //not used
        public async Task<Product> GetByNameAsync(string name)
        {
            return await _collection.Find(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Product> CreateAsync(Product newProduct)
        {
            await _collection.InsertOneAsync(newProduct);
            return newProduct;
        }
        public async Task UpdateAsync(string id, Product updatedProduct)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedProduct);
        }
        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
