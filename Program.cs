using Microsoft.EntityFrameworkCore;  // Namespace for EF Core
using Microsoft.OpenApi.Models;     // Namespace for Swagger configuration
using BowlingLeagueAPI.Models;      // Namespace for your Models (e.g., BowlingLeagueContext)

// Set up the WebApplication builder for your ASP.NET application
var builder = WebApplication.CreateBuilder(args);

// Add database context (connects to SQLite database using the connection string "BowlingLeague")
builder.Services.AddDbContext<BowlingLeagueContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingLeague"))); // Configures EF to use SQLite

// Add services required for controllers (API endpoints)
builder.Services.AddControllers(); // Enables MVC-style controller-based routing

// Add support for API documentation via Swagger
builder.Services.AddEndpointsApiExplorer(); // Used for discovering API endpoints
builder.Services.AddSwaggerGen(c =>
{
    // Configure Swagger with title and version information
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BowlingLeague API", Version = "v1" });
});

// Build the application with the configured services
var app = builder.Build();

// Middleware configuration

// Enable Swagger and Swagger UI only in the development environment (helpful for debugging)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enables the Swagger endpoint for API documentation
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BowlingLeague API v1")); // Swagger UI for easier testing of the API
}

// Enable HTTPS redirection for secure connections
app.UseHttpsRedirection();

// Enable Authorization middleware (used for securing endpoints, can be further configured)
app.UseAuthorization();

// Map controller routes for incoming API requests
app.MapControllers();

// Run the application
app.Run();