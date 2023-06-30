using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var loggerConfiguration = new LoggerConfiguration()
	.Enrich.WithProperty("Version", "1.0.0")
	.WriteTo.Console();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	loggerConfiguration.MinimumLevel.Verbose();
}
else
{
	loggerConfiguration.MinimumLevel.Information();
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

Log.Logger = loggerConfiguration.CreateLogger(); 
Log.Information("building the application");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

Log.Information("running the application");
app.Run();