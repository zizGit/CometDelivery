using CometFoodDelivery.Models;
using CometFoodDelivery.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseConnectionStringSettings>(builder.Configuration.GetSection("DatabaseConnectionString"))
                .Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"))
                .Configure<ShopsDatabaseSettings>(builder.Configuration.GetSection("ShopsDatabase"))
                .Configure<ProductsDatabaseSettings>(builder.Configuration.GetSection("ProductsDatabase"));

builder.Services.AddSingleton<UsersService>()
                .AddSingleton<ShopService>();

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddAuthorization() //jwt token
                .AddAuthentication();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod()); 

app.UseAuthentication() //jwt token
   .UseAuthorization(); 

//all routers
app.MapGet("/", () => "Hello World!\nTo close this program, follow this link: .../exit\n\nAll routers:"
                     + "\n.../api/users                     - GET, POST, DELETE"
                     + "\n.../api/users/[id:length(24)]     - PUT"
                     + "\n.../api/users/login               - POST"
                     + "\n.../api/users/registration        - POST\n"
                     + "\n.../api/shops                     - GET, POST"
                     + "\n.../api/shops/[name]              - GET, PUT, DELETE\n"
                     + "\n.../api/"
                     + "\n.../api/"
                     + "\n.../api/"
                     + "\n.../api/");

app.MapGet("/exit/", () => Environment.Exit(0));

app.MapControllers();

app.Run();