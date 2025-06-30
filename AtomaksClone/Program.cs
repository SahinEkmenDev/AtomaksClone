using AtomaksClone.Data;
using AtomaksClone.Services;
using AtomaksClone.Config;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;


using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// PostgreSQL connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// SeedService
builder.Services.AddScoped<SeedService>();

// Cloudinary settings
builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddSingleton(x =>
{
    var config = builder.Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
    var account = new Account(config.CloudName, config.ApiKey, config.ApiSecret);
    return new Cloudinary(account);
});

// PhotoService
builder.Services.AddScoped<PhotoService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3002",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000","http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seedService = services.GetRequiredService<SeedService>();
    await seedService.SeedDataAsync();
}

// Configure HTTP pipeline

// Enable CORS
app.UseCors("AllowLocalhost3002");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication(); // JWT kullanmıyorsan yorumlu bırak
app.UseAuthorization();

app.MapControllers();

app.Run();
