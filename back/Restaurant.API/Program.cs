using Restaurant.Dal.Contexts;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Restaurant.Bll.Services.Interfaces;
using Restaurant.Bll.Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddXmlSerializerFormatters()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("RestaurantOpenAPISpecification", new()
    {
        Title = "Restaurant API",
        Version = "v1",
        Description = "Through this API you can access to Restaurant database and make CRUD operation with entities",
    });

    setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.Load("Restaurant.API").GetName().Name}.xml"));
    setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.Load("Restaurant.Bll").GetName().Name}.xml"));
    setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.Load("Restaurant.Dal").GetName().Name}.xml"));
});

builder.Services.AddDbContext<RestaurantContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDrinkService, DrinkService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RestaurantContext>();
    await dbContext.Database.MigrateAsync();
}  
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        setupAction.SwaggerEndpoint("/swagger/RestaurantOpenAPISpecification/swagger.json", "Restaurant API");
    }
    );
}

//app.UseMiddleware<CorsMiddleware>();
app.UseCors(
     x => x.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
 );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Run();
await app.RunAsync();
