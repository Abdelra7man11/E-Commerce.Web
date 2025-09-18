

using DomainLayer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Persistence.Identity;
using StackExchange.Redis;

namespace Persistence
{
    public static class InfraStractureServicesRegistration
    {
        public static IServiceCollection AddInfraStractureServices(this IServiceCollection Services, IConfiguration Configuration)
        {


            // DataBase 
            Services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefultConnection"))
            );

            // Services REgistration
            Services.AddScoped<IDataSeeding, DataSeeding>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IBasketRepository, BasketRepository>();
            Services.AddScoped<ICacheRepository, CacheRepository>();

            //Redis Memory
            Services.AddSingleton<IConnectionMultiplexer>((_) =>
            {
                return ConnectionMultiplexer.Connect(Configuration.GetConnectionString("RedisConnectionString")!);
            });

            // DataBase Of Identity Users
            Services.AddDbContext<StoreIdentityDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"))
             );

            Services.AddIdentityCore<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<StoreIdentityDbContext>();


            return Services;
        }
    }
}
