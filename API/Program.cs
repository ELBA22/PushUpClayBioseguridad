using System.Reflection;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* builder.Services.AddDbContext<bioseguContext>(options =>
{
    string ConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");
    options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
}); */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
/* app.UseIpRateLimiting(); */

app.UseAuthorization();

app.MapControllers();

app.Run();
