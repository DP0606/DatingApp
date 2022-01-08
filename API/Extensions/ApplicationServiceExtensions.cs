using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using API.Interfaces;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Services;

namespace API.Extensions
{
    //Extension metode koriste se kako bi Startup.cs klasa bila čim čišća i preglednija.
    //Sve što mi koristimo u konfiguraciji treba izdvojitit iz startup.cs
    //Static znači da nam ne treba nova insanca klase da bi se koristila
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,  IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}