using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

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
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidAudience = AuthOptions.AUDIENCE,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey() // The same key as the one that generate the token
        };
    });

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod()); // CORS

//jwt token
app.UseAuthentication();
app.UseAuthorization();

//all routers
app.MapGet("/", () => "Hello World!\nTo close this program, follow this link: .../exit\n\nAll routers:"
                     + "\n.../api/users                     - GET"
                     + "\n.../api/users/[id:length(24)]     - GET, PUT, DELETE"
                     + "\n.../api/users/login               - POST"
                     + "\n.../api/users/registration        - POST"
                     + "\n.../api/users/email/[email]       - GET\n"
                     + "\n.../api/shops                     - GET, POST"
                     + "\n.../api/shops/[name]              - GET, PUT, DELETE\n"
                     + "\n.../api/"
                     + "\n.../api/"
                     + "\n.../api/"
                     + "\n.../api/");

app.MapGet("/exit/", () => Environment.Exit(0));

app.MapControllers();

app.Run();

public class AuthOptions
{
    public const string ISSUER = "BackendServer";
    public const string AUDIENCE = "Client";
    const string KEY = "secretTokenKey_75f20ca5491d8b37274290901f2c39b740293f7fb337591abd3";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}

class Programt
{
    static string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

    static void Main(string[] args)
    {
        var stringToken = GenerateToken();
        ValidateToken(stringToken);
    }

    private static string GenerateToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var secToken = new JwtSecurityToken(
            signingCredentials: credentials,
            issuer: "Sample",
            audience: "Sample",
            claims: new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "meziantou")
            },
            expires: DateTime.UtcNow.AddDays(1));

        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(secToken);
    }

    private static bool ValidateToken(string authToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = GetValidationParameters();

        SecurityToken validatedToken;
        IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
        return true;
    }

    private static TokenValidationParameters GetValidationParameters()
    {
        return new TokenValidationParameters()
        {
            ValidateLifetime = false, // Because there is no expiration in the generated token
            ValidateAudience = false, // Because there is no audiance in the generated token
            ValidateIssuer = false,   // Because there is no issuer in the generated token
            ValidIssuer = "Sample",
            ValidAudience = "Sample",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // The same key as the one that generate the token
        };
    }
} 