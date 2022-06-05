using StockPriceMonitor.Data;
using StockPriceMonitor.Data.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IStockRepository, StockRepository>();

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<CacheManager>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "development-origins",
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                      });
});

var app = builder.Build();

app.UseCors("development-origins");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.Run();
