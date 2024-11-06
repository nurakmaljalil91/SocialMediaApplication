using System.Globalization;
using Application;
using Serilog;
using WebAPI;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var dateTimeUtcNow = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
Log.Information("Starting Social Media API");
Log.Information("UTC Time: {DateTimeUtcNow}", dateTimeUtcNow);

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Read Serilog configuration from appsettings.json
    builder.Host.UseSerilog((context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration);
    });

    // Add services to the container.
    builder.Services.AddApplicationServices();
    // builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddWebAPIServices(builder.Configuration);

    // Add services to the container.
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
    }

    // Add OpenAPI 3.0 document serving middleware
    app.UseOpenApi();

    // Add web UIs to interact with the document
    app.UseSwaggerUi();

    // Add ReDoc UI to interact with the document
    app.UseReDoc(options => { options.Path = "/redoc"; });

    app.UseHttpsRedirection();

    app.UseSerilogRequestLogging();

    app.UseCors("CorsPolicy");

    // app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    // app.MapHealthChecks("/health", new HealthCheckOptions()
    // {
    //     ResponseWriter = HealthCheckResponse.WriteResponse
    // });


    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Stopping Social Media API");
    var stopDateTimeUtcNow = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
    Log.Information("UTC Time: {DateTimeUtcNow}", stopDateTimeUtcNow);
    Log.CloseAndFlush();
}