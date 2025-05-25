
using AutoMapper;
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repositories;
using Service;
using Service.MappingProfile;
using ServiceAbstraction;
using System.Threading.Tasks;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            #region  Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(options =>

            options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection"))
            
            );

            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(typeof(Service.AssemblyRefrence).Assembly);  // The Mapper in Class profile

            builder.Services.AddScoped<IServiceManager, ServiceManager>();

            #endregion

            var app = builder.Build();

            #region Data Seeding
            using var Scoop = app.Services.CreateScope();

            var ObjectDataSeeding = Scoop.ServiceProvider.GetRequiredService<IDataSeeding>();

           await ObjectDataSeeding.DataSeedAsync(); 
            #endregion

            #region Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
