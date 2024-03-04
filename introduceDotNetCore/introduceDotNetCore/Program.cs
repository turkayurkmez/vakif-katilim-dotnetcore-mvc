var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var value = builder.Configuration.GetValue<string>("Value");
var app = builder.Build();

//app.UseWelcomePage();


app.Logger.LogInformation(value);

app.UseStaticFiles();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
