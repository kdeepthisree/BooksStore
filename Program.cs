using BooksStore.Data;
using BooksStore.Data.Service;
using BooksStore.Exceptions;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.AspNetCore;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
//configuring thebuilt Logger
//builder.Host.ConfigureLogging(loggingProvider =>
//{
//    loggingProvider.ClearProviders();
//    loggingProvider.AddConsole();
//    loggingProvider.AddDebug();
//});
////configurating the Serilog-3rdparty for more destinations
//builder.Host.UseSerilog((HostBuilderContext context, IServiceCollection services, LoggerConfiguration loggerConfiguration =>
//{
//    loggerConfiguration.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(services);
//});

builder.Host.UseSerilog((context, services, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(services);
});


// Add services to the container.
//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    // set default minimum level
//    .MinimumLevel.Debug()
//    .CreateLogger();

//Log.Debug("this is a debug msg");
//Log.Information("Before testing connect...");
//Log.Information("Connection successful!");
//Log.Error("Connection failed");
//...
builder.Services.AddControllers();
builder.Services.AddDbContext<BookDbContext>();
builder.Services.AddHttpLogging(options => {
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestProperties |
    Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<PublishersController>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<LogsService>();

/*builder.Services.AddApiVersioning(); */// versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    // options.ApiVersionReader = new HeaderApiVersionReader("custom-header-apiversion");
    options.ApiVersionReader = new MediaTypeApiVersionReader();
});


var app = builder.Build();
app.UseHttpLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//default built in logger inAsp.netcore
//app.Logger.LogDebug("debug-message");
//app.Logger.LogInformation("information-message");
//app.Logger.LogWarning("warning-message");
//app.Logger.LogCritical("criticalMessage");
//app.Logger.LogError("log messages");


app.UseHttpsRedirection();

app.UseAuthorization();
//app.ConfigureBuiltInGlobalExceptionHandlerExtension();

app.ConfigureCsutomeHandler();

app.MapControllers();
AppDbInitializer.Seed(app);

app.Run();
