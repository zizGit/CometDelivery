using CometFoodDelivery.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;

namespace CometFoodDelivery.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderService(IOptions<OrderDatabaseSettings> databaseSettings, IOptions<DatabaseConnectionStringSettings> connectionSettings)
        {
            var client = new MongoClient(connectionSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = database.GetCollection<Order>(databaseSettings.Value.CollectionName);
        }

        public bool newOrderRules(Order order, ref orderData data)
        {
            string[] allowableEmail = { ".com", ".net", ".ua" };

            if (order.Phone.ToString().Length != 12) { data.Phone = "Incorrect phone number"; }
            if (!order.Email.Contains("@") || !allowableEmail.Any(x => order.Email.EndsWith(x))) { data.Email = "Incorrect Email"; }

            //if data not empty - errors found
            foreach (PropertyInfo property in data.GetType().GetProperties())
            {
                object value = property.GetValue(data, null);
                if (value != null || (value is string && string.IsNullOrEmpty(value as string)))
                {
                    return false;
                }
            }
            return true;
        }

        public orderReturn returnWith200(Order order)
        {
            var orderReturn = new orderReturn();
            orderReturn.Id = order.Id;
            orderReturn.Name = order.Name;
            orderReturn.Email = order.Email;
            orderReturn.Phone = order.Phone;
            orderReturn.Adress = order.Adress;
            orderReturn.Payment = order.Payment;
            orderReturn.Products = order.Products;
            return orderReturn;
        }

        public async Task<List<Order>> GetAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }
        public async Task<Order> GetAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Order> CreateAsync(Order newOrder)
        {
            await _collection.InsertOneAsync(newOrder);
            return newOrder;
        }
        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}