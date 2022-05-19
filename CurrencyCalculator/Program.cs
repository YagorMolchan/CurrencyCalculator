using NLog.Web;
//using NLog.Extensions.Logging;
//using NLog;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

//var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("FxRates", c  =>
{
    c.BaseAddress = new Uri("https://www.lb.lt/webservices/FxRates/");
    c.DefaultRequestHeaders.Add("Accept", "application/xml");
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Index}/{id?}");

app.Run();
