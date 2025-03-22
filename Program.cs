using Microsoft.EntityFrameworkCore;
using BowlingLeague.Models;  // Referencing my models 
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Enable CORS to allow the React frontend to make requests to the backend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Allow any origin (frontend on a different port)
            .AllowAnyMethod()    // Allow any HTTP method (GET, POST, etc.)
            .AllowAnyHeader();   // Allow any headers
    });
});

// Set up SQLite database connection using DbContext
builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingLeague")));

// Add support for API controllers (to handle requests)
builder.Services.AddControllers();

// Add Swagger for API documentation (useful for testing API in development)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Set up middleware for the app.

// If in development, enable Swagger UI for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Generate API docs
    app.UseSwaggerUI(); // Display the docs in the browser
}

// Enable CORS so frontend can access the backend API
app.UseCors("AllowAll");

// Ensure HTTP requests are redirected to HTTPS
app.UseHttpsRedirection();

// Set up authorization middleware (ensures only authorized users access certain routes)
app.UseAuthorization();

// Map controller routes to the API
app.MapControllers();

// Run the app (start listening for incoming requests)
app.Run();
