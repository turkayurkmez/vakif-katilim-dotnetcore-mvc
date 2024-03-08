using BookStore.Extensions;
using BookStore.Infrastructure.DataAcess.Data;
using BookStore.Infrastructure.DataAcess.Repositories;
using BookStore.MVC.Localization;
using BookStore.Services;
using BookStore.Services.MappingProfile;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");



// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization().AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
        return factory.Create("SharedResource", assemblyName.Name);
    };
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("tr-TR"),
        new CultureInfo("en-US"),

    };
    options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});


//builder.Services.AddScoped<IBookService, BookService>();
//builder.Services.AddScoped<IBookRepository, EFBookRepository>();
//builder.Services.AddScoped<IGenreService, GenreService>();
//builder.Services.AddScoped<IGenreRepository, EFGenreRepository>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddAutoMapper(typeof(MapProfile));
//builder.Services.AddDbContext<BookStoreDbContext>(builder => builder.UseSqlServer(connectionString));
var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddNecessaryInjections(connectionString);



builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(3));




builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Users/Login";
                    option.ReturnUrlParameter = "gidilecekUrl";
                    option.AccessDeniedPath = "/Users/AccessDenied";
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();//.UseStaticFiles().UseRouting().UseAuthorization();
app.UseStaticFiles();
app.UseSession();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "pagination",
    pattern: "Sayfa{page}",
    defaults: new { controller = "Home", action = "Index", page = 1 }

    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
