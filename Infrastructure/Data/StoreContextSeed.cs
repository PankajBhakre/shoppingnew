using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory logger)
        {
            try
            {
                if(!storeContext.productBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var item in brands)
                    {
                        storeContext.productBrands.Add(item);

                    }
                    await storeContext.SaveChangesAsync();
                }
                 if(!storeContext.productTypes.Any())
                {
                    var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);

                    foreach(var item in types)
                    {
                        storeContext.productTypes.Add(item);

                    }
                    await storeContext.SaveChangesAsync();
                }
                 if(!storeContext.products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach(var item in products)
                    {
                        storeContext.products.Add(item);

                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
               var loger= logger.CreateLogger<StoreContextSeed>();
               
                    loger.LogError(ex.Message);
            }
        }
    }
}