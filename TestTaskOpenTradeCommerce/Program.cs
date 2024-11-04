using TestTaskOpenTradeCommerce.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddRouting();
builder.Services.AddServices();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration["RedisCacheUrl"];
});

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.Run();