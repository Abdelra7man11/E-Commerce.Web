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
        public void DataSeed()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Products.Any())
                {
                    var ProductsData = File.ReadAllText(@"..\InfraStracture\Persistence\DataSeed\products.json");
                    // Convert From JSON FIle TO List
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                    if (Products != null && Products.Any())
                        _dbContext.Products.AddRange(Products);

                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductBrandData = File.ReadAllText(@"..\InfraStracture\Persistence\DataSeed\brands.json");
                    // Convert From JSON FIle TO List
                    var ProductBrand = JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandData);
                    if (ProductBrand != null && ProductBrand.Any())
                        _dbContext.ProductBrands.AddRange(ProductBrand);

                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductTypesData = File.ReadAllText(@"..\InfraStracture\Persistence\DataSeed\types.json");
                    // Convert From JSON FIle TO List
                    var ProductTypes = JsonSerializer.Deserialize<List<ProductType>>(ProductTypesData);
                    if (ProductTypes != null && ProductTypes.Any())
                        _dbContext.ProductTypes.AddRange(ProductTypes);

                }
            
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO
            }
        }
    }
}