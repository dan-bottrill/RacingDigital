using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RacingDigital.Areas.Identity.Models;
using RacingDigital.Data;
using RacingDigital.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDB connection
var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine("Error using MongoDB connection string");
    Environment.Exit(0);
}
var client = new MongoClient(connectionString);
var database = client.GetDatabase("RacingDigital");

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddRazorPages(); 
builder.Services.AddControllersWithViews();

// Identity with MongoDB
var mongoDbContext = new MongoDbContext(connectionString, "RacingDigital");

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddMongoDbStores<AppUser, AppRole, string>(mongoDbContext)
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<RaceResultService>();
builder.Services.AddSingleton<MyStableService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Identity}/{action=Login}/{id?}");

app.MapRazorPages();

app.Run();
