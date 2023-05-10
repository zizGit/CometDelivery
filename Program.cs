using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseConnectionStringSettings>(builder.Configuration.GetSection("DatabaseConnectionString"));
builder.Services.Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"));
builder.Services.Configure<ShopsDatabaseSettings>(builder.Configuration.GetSection("ShopsDatabase"));
builder.Services.Configure<ProdustsDatabaseSettings>(builder.Configuration.GetSection("ProdustsDatabase"));

builder.Services.AddSingleton<UsersService>();

builder.Services.AddControllers();

var app = builder.Build();

/*
const string connectionUri = "mongodb+srv://user:user@cometdb.7ffayor.mongodb.net/?retryWrites=true&w=majority";

var settings = MongoClientSettings.FromConnectionString(connectionUri);

// Set the ServerApi field of the settings object to Stable API version 1
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

// Create a new client and connect to the server
var client = new MongoClient(settings);
*/


app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();