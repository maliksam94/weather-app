var builder = DistributedApplication.CreateBuilder(args);


// Add .NET WebApi service
builder.AddProject<Projects.sampleWebApi>("weather-api");

// Add NPM app for Angular frontend
builder.AddNpmApp(
    "weather-app",
    "../webApp",
    "start");

builder.Build().Run();