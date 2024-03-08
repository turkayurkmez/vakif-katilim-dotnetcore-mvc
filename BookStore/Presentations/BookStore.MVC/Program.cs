using BookStore.Infrastructure.DataAcess.Data;
using BookStore.Infrastructure.DataAcess.Repositories;
using BookStore.Services;
using BookStore.Services.MappingProfile;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, EFBookRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IGenreRepository, EFGenreRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(3));

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<BookStoreDbContext>(builder => builder.UseSqlServer(connectionString));


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
