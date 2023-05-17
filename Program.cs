using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var logFileName = $"Logs/{DateTime.Now:yyyy-MM-dd-HH-mm-ss}-app.log";

builder.Services.AddSingleton<Serilog.ILogger>(sp => {
    var logger = new LoggerConfiguration().CreateLogger();
    return logger;
});

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
                                      .MinimumLevel.Information()
                                      .WriteTo.File(logFileName, rollingInterval: RollingInterval.Day, 
                                            rollOnFileSizeLimit: true, fileSizeLimitBytes: 1024 * 1024 * 10)
                                      .CreateLogger();

var host = Host.CreateDefaultBuilder(args).UseSerilog().Build();
host.RunAsync();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<DatabaseConnectionStringSettings>(builder.Configuration.GetSection("DatabaseConnectionString"))
                .Configure<UserDatabaseSettings>(builder.Configuration.GetSection("UserDatabase"))
                .Configure<ShopsDatabaseSettings>(builder.Configuration.GetSection("ShopsDatabase"))
                .Configure<ProductsDatabaseSettings>(builder.Configuration.GetSection("ProductsDatabase"));

builder.Services.AddSingleton<UsersService>()
                .AddSingleton<ShopService>()
                .AddSingleton<DiagnosticContext>(); //for logs

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddAuthorization() //jwt token
                .AddAuthentication();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());

app.UseSerilogRequestLogging(options => {
    options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Information;
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) => {
        diagnosticContext.Set("RequestMethod", httpContext.Request.Method);
        diagnosticContext.Set("RequestPath", httpContext.Request.Path);
    };
}); // logs write

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