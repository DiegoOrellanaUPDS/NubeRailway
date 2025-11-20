using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using prueba.Data;

var url = Environment.GetEnvironmentVariable("DATABASE_URL");
Console.WriteLine($"Coneccion actual: {url}");
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<pruebaContext>(options =>
    options.UseNpgsql(url));

// Add services to the container.
builder.WebHost.UseUrls("http://0.0.0.0:8080");



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<pruebaContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
