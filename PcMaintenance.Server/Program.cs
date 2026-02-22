using Microsoft.EntityFrameworkCore;
using PcMaintenance.Server.Data;

// #region agent log
var _logPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "debug-4c260c.log"));
try { File.AppendAllText(_logPath, "{\"sessionId\":\"4c260c\",\"location\":\"Program.cs:start\",\"message\":\"Before CreateBuilder\",\"hypothesisId\":\"A\",\"timestamp\":" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + "}\n"); } catch { }
// #endregion
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "dist"
});
// #region agent log
try { File.AppendAllText(_logPath, "{\"sessionId\":\"4c260c\",\"location\":\"Program.cs:after-builder\",\"message\":\"Builder created with WebRootPath=dist\",\"hypothesisId\":\"B\",\"timestamp\":" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + "}\n"); } catch { }
// #endregion

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

// SPA: serve static files from dist (set via UseWebRoot)
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

app.Run();
