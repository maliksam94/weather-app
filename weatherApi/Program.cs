using Microsoft.AspNetCore.Mvc;
using sampleWebApi.Contracts;
using sampleWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Add HttpClient factory for managed HttpClient instances
builder.Services.AddHttpClient();

// Add custom services
builder.Services.AddScoped<IWeatherService, WeatherService>();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Weahther Forecast API",
        Version = "v1.0.0",
        Description = "This API provides weather forecast information."
    });    
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather Forecast API v1.0");
        c.RoutePrefix = string.Empty; // Make Swagger UI the default page
    });
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}


app.UseAuthorization();

app.UseCors("AngularPolicy");

app.MapControllers();

app.Run();

