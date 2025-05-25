using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            { 
                var PendingMigrate = await _dbContext.Database.GetPendingMigrationsAsync();
            
                if (PendingMigrate.Any())
                {
                   await _dbContext.Database.MigrateAsync();
                }

                if (!_dbContext.Products.Any())
                {
                    //var ProductsData = File.ReadAllText(@"..\InfraStracture\Persistence\DataSeed\products.json");
                    var ProductsData =  File.OpenRead(@"..\InfraStracture\Persistence\DataSeed\products.json");
                    // Convert From JSON FIle TO List
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductsData);
                    if (Products != null && Products.Any())
                        await _dbContext.Products.AddRangeAsync(Products);

                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductBrandData = File.OpenRead(@"..\InfraStracture\Persistence\DataSeed\brands.json");
                    // Convert From JSON FIle TO List
                    var ProductBrand = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (ProductBrand != null && ProductBrand.Any())
                        await _dbContext.ProductBrands.AddRangeAsync(ProductBrand);

                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductTypesData = File.OpenRead(@"..\InfraStracture\Persistence\DataSeed\types.json");
                    // Convert From JSON FIle TO List
                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypesData);
                    if (ProductTypes != null && ProductTypes.Any())
                        await _dbContext.ProductTypes.AddRangeAsync(ProductTypes);

                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //TODO
            }
        }
    }
}