using BookStore.Infrastructure.DataAcess.Data;
using BookStore.Infrastructure.DataAcess.Repositories;
using BookStore.Services;
using BookStore.Services.MappingProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddNecessaryInjections(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, EFGenreRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddDbContext<BookStoreDbContext>(builder => builder.UseSqlServer(connectionString));

            return services;
        }
    }
}
