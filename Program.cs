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

var app = builder.Build();

app.MapGet("/", () => "Hello World!\nTo close this program, follow this link: .../exit");
app.MapGet("/exit/", () => Environment.Exit(0));

app.MapControllers();

app.Run();

/*
shop1{  
                  name: "KFC"
                  imageUrl: "(ссылка на картинку в инете, или на базе данных как тебе удобней)",
                  types: ["American", "Burgers" и т.д], // тип рестика
                  deliveryCost: 35 // стоимость доставки
                  deliveryTime: [35, 40] // время доставки
                   }
shop2{  
                  name: " Sushi"
                  imageUrl: "(ссылка на картинку в инете, или на базе данных как тебе удобней)",
                  types: ["Sushi", "Japanese" и т.д], // тип рестика
                  deliveryCost: 35 // стоимость доставки
                  deliveryTime: [35, 40] // время доставки
                   }


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