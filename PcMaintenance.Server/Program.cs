using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using PcMaintenance.Server.Data;

// Migrări EF Core: se aplică la startup cu Migrate() (nu EnsureCreated()). Connection string din config (env/secrets).
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "dist"
});

// Rate limiting (per IP); config in appsettings.json -> IpRateLimiting
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase);

// Configure DB: InMemory for Testing environment, otherwise PostgreSQL
if (builder.Environment.IsEnvironment("Testing"))
    builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));
else
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
}

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("https://localhost:59404", "https://localhost:59405", "http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (!app.Environment.IsDevelopment())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseIpRateLimiting();
app.UseCors("AllowVueApp");
app.UseRouting();
app.MapControllers();

// SPA: serve static files from dist (set via WebRootPath)
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

// Apply EF Core migrations at startup (idempotent; no separate deploy step); skip in Testing to allow InMemory DB
if (!app.Environment.IsEnvironment("Testing"))
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
}

app.Run();
