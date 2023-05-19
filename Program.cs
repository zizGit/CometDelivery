using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var logFileName = $"Logs/{DateTime.Now:yyyy-MM-dd-HH-mm-ss}-app.log";

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders(); // Removing default logging providers
    loggingBuilder.AddSerilog(dispose: true); // Add Serilog in ILoggerFactory
});

builder.Services.AddSingleton<Serilog.ILogger>(sp => {
    var logger = new LoggerConfiguration().CreateLogger();
    return logger;
});

//for logs
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<DiagnosticContext>(); 

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
                                      .MinimumLevel.Information()
                                      .WriteTo.File(logFileName, rollingInterval: RollingInterval.Day, 
                                            rollOnFileSizeLimit: true, fileSizeLimitBytes: 1024 * 1024 * 10)
                                      .CreateLogger();

var host = Host.CreateDefaultBuilder(args).UseSerilog().Build();
host.RunAsync();

builder.Services.Configure<DatabaseConnectionStringSettings>(builder.Configuration.GetSection("DatabaseConnectionString"))
                .Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"))
                .Configure<OrderDatabaseSettings>(builder.Configuration.GetSection("OrderDatabase"))
                .Configure<ShopsDatabaseSettings>(builder.Configuration.GetSection("ShopsDatabase"))
                .Configure<ProductsDatabaseSettings>(builder.Configuration.GetSection("ProductsDatabase"));

builder.Services.AddSingleton<UsersService>()
                .AddSingleton<OrderService>()
                .AddSingleton<ShopService>()
                .AddSingleton<ProductService>();

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddAuthorization() //jwt token
                .AddAuthentication();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());

// logs write
app.UseSerilogRequestLogging(options =>
{
    options.GetLevel = (httpContext, elapsed, ex) =>
    {
        return LogEventLevel.Information;
    };
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        diagnosticContext.Set("RequestMethod", httpContext.Request.Method);
        diagnosticContext.Set("RequestPath", httpContext.Request.Path);
        diagnosticContext.Set("RemoteIpAddress", httpContext.Connection.RemoteIpAddress.ToString());
        diagnosticContext.Set("UserAgent", httpContext.Request.Headers["User-Agent"].ToString());
        diagnosticContext.Set("RequestId", httpContext.TraceIdentifier);
    };
});

app.UseAuthentication() //jwt token
   .UseAuthorization(); 

//all routers
app.MapGet("/", () => "Hello World!\nTo close this program, follow this link: .../exit\n\nAll routers:"
                     + "\n.../api/users                     - GET (get all), POST (get by _id_ or _email_)"
                     + "\n.../api/users/[id:length(24)]     - PUT, DELETE"
                     + "\n.../api/users/login               - POST (_get_ token or _validate_ token)"
                     + "\n.../api/users/registration        - POST\n"
                     + "\n.../api/shops                     - GET (get all), POST (create new)"
                     + "\n.../api/shops/[name]              - GET, PUT, DELETE"
                     + "\n.../api/shops/search/[name]       - GET"
                     + "\n.../api/shops/type/[type]         - GET\n"
                     + "\n.../api/products                  - GET (get all), POST (get by _shop_ and _type_ or only _type_)"
                     + "\n.../api/products/[shop]           - GET"
                     + "\n.../api/products/[shop]/[section] - GET"
                     + "\n.../api/products/[id:length(24)]  - PUT, DELETE"
                     + "\n.../api/products/new              - POST\n"
                     + "\n.../api/orders                    - GET, POST, PUT, DELETE"
                     + "\n.../api/orders                    - GET, POST, PUT, DELETE"
                     + "\n.../api/orders                    - GET, POST, PUT, DELETE"
                     + "\n.../api/orders                    - GET, POST, PUT, DELETE");

app.MapGet("/exit/", () => Environment.Exit(0));

app.MapControllers();
app.Run();