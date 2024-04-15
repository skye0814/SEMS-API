using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using SEMS_API_V2.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection string to database
builder.Services.AddDbContext<RepositoryContext>(x =>
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultSqliteConnection")));

// To enable includes from EFCore
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Services injection and repository wrapper
builder.Services.ConfigureRepositoryWrapper();
builder.Services.ConfigureIdentityUser();
builder.Services.ConfigureServices();
builder.Services.ConfigureCORS();

// Inject logging services
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

IdentityModelEventSource.ShowPII = true;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();

//app.UseAuthentication(); Uncomment this if JWT is implemented
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
