using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

//const string connectionUri = "mongodb+srv://user:user@cometdb.7ffayor.mongodb.net/?retryWrites=true&w=majority";

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseConnectionStringSettings>(builder.Configuration.GetSection("DatabaseConnectionString"));
builder.Services.Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"));
builder.Services.Configure<ShopsDatabaseSettings>(builder.Configuration.GetSection("ShopsDatabase"));
builder.Services.Configure<ProductsDatabaseSettings>(builder.Configuration.GetSection("ProductsDatabase"));

builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<ShopService>();

builder.Services.AddControllers();
builder.Services.AddCors(); // CORS

//jwt token
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod()); // CORS

//jwt token
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!\nTo close this program, follow this link: .../exit");
app.MapGet("/exit/", () => Environment.Exit(0));

app.MapControllers();

app.Run();

public class AuthOptions
{
    public const string ISSUER = "BackendServer";
    public const string AUDIENCE = "Client";
    const string KEY = "secretTokenKey!123";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}