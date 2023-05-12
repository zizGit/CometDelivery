namespace CometFoodDelivery.Models
{
    public class DatabaseConnectionStringSettings
    {
        public string ConnectionString { get; set; } = null!;
    }

    public class UserDatabaseSettings
    {
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }

    public class ShopsDatabaseSettings
    {
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }

    public class ProductsDatabaseSettings
    {
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
