using CometFoodDelivery.Models;
using CometFoodDelivery.Services;

//const string connectionUri = "mongodb+srv://user:user@cometdb.7ffayor.mongodb.net/?retryWrites=true&w=majority";

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseConnectionStringSettings>(builder.Configuration.GetSection("DatabaseConnectionString"));
builder.Services.Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"));
builder.Services.Configure<ShopsDatabaseSettings>(builder.Configuration.GetSection("ShopsDatabase"));
builder.Services.Configure<ProdustsDatabaseSettings>(builder.Configuration.GetSection("ProdustsDatabase"));

builder.Services.AddSingleton<UsersService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();

string command;
while (1) 
{
    global::System.Console.WriteLine("Write \"KillServer\" to close program.");
    global::System.Console.Write(">>> ");
    global::System.Console.ReadLine(command);

    if (command == "KillServer")
    {
        Application.Exit();
    }

    global::System.Console.WriteLine("");
}