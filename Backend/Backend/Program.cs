using Backend.Data;
using Backend.Services.Implementation;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.SqlServer;
using Backend.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DockerCon"))
        
        );


//MYSerivces
builder.Services.AddScoped<IUrlService, UrlService>();//UrlHashing
builder.Services.AddScoped<IClickTrackingService, ClickTrackingService>();//CLick Tracking


var ORIGIN_URL = "http://localhost:5173";

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(ORIGIN_URL) // or your React URL
           .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});




//HangFire
var hangfireEnabled = builder.Configuration.GetValue<bool>("Hangfire:Enabled");

if (hangfireEnabled)
{
    builder.Services.AddHangfire(config =>
        config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
              .UseSimpleAssemblyNameTypeSerializer()
              .UseRecommendedSerializerSettings()
              .UseSqlServerStorage(builder.Configuration.GetConnectionString("Backend"))
    );

    builder.Services.AddHangfireServer();
}




var app = builder.Build();


//FOR DOCKER
//Because docker keeps giving an error db not found so making a db beforehand
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated(); // This will create the database if it doesn't exist 
        Console.WriteLine("Database checked/created successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred creating the DB: {ex.Message}");
        // Optionally rethrow if you want to prevent the app from starting
        // throw;
    }
}

app.UseCors("AllowFrontend");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Hangfire
if (app.Environment.IsDevelopment() && hangfireEnabled)
{
    app.UseHangfireDashboard();

    RecurringJob.AddOrUpdate<UrlCleanUpJob>(
        "cleanup-job",
        job => job.CleanExpiredUrlAsync(),
        Cron.Monthly()
    );
}

app.Run();



