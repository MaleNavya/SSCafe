
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using MMLib.SwaggerForOcelot.DependencyInjection;
using MMLib.SwaggerForOcelot.Middleware;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Load Ocelot configuration
builder.Configuration.AddJsonFile(
    "ocelot.json",
    optional: false,
    reloadOnChange: true
);

// Register controllers
builder.Services.AddControllers();

// Swagger configuration for downstream APIs
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerForOcelot(
    builder.Configuration
);

// Configure HTTP Client
builder.Services.ConfigureHttpClientDefaults(http =>
{
    http.ConfigureHttpClient(client =>
    {
        client.DefaultRequestVersion = HttpVersion.Version11;

        client.DefaultVersionPolicy =
            HttpVersionPolicy.RequestVersionExact;
    });
});

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register Ocelot API Gateway
builder.Services.AddOcelot(builder.Configuration);

// Build application
var app = builder.Build();

// Enable CORS
app.UseCors("ReactClient");

// Root endpoint
app.MapGet("/", () =>
    Results.Redirect("/swagger")
);

// Swagger UI for User and Menu Management
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerForOcelotUI(options =>
    {
        options.PathToSwaggerGenerator = "/swagger/docs";
    });
}

// Ocelot middleware
await app.UseOcelot();

app.Run();
