using DotTestKit.API.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on HTTP and HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5186); // HTTP port
    options.ListenAnyIP(7294, listenOptions => listenOptions.UseHttps()); // HTTPS port
});

// Add services
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotTestKit API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotTestKit API v1");
    });
}

app.UseHttpsRedirection(); // now HTTPS port is known
app.UseAuthorization();
app.MapControllers();

app.Run();
