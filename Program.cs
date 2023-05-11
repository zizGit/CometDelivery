using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using System.Runtime.InteropServices;

//const string connectionUri = "mongodb+srv://user:user@cometdb.7ffayor.mongodb.net/?retryWrites=true&w=majority";

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseConnectionStringSettings>(builder.Configuration.GetSection("DatabaseConnectionString"));
builder.Services.Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"));
builder.Services.Configure<ShopsDatabaseSettings>(builder.Configuration.GetSection("ShopsDatabase"));
builder.Services.Configure<ProdustsDatabaseSettings>(builder.Configuration.GetSection("ProdustsDatabase"));

builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<ShopService>();

builder.Services.AddControllers();

builder.Services.AddCors(); // добавляем сервисы CORS

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin()); // настраиваем CORS

app.MapGet("/", () => "Hello World!\nTo close this program, follow this link: .../exit");
app.MapGet("/exit/", () => Environment.Exit(0));

app.MapControllers();

app.Run();

/*
restorantProudct{
                                   burgers: [
                                                      {name: "Name",
                                                        price: "150"},
                                                       {name: "Name2"
                                                         price: "150"}....]
                                    pizzas: [ {name: "Pizza",
                                                     price: "1337"},
                                                      {name: "Pizza",
                                                     price: "1337"}, .]
}
*/