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

        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {

            if (!context.ProductBrands.Any())
            {
                var brands = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                var collection = JsonSerializer.Deserialize<List<ProductBrand>>(brands);

                foreach (var item in collection)
                {
                    context.ProductBrands.Add(item);
                }

                await context.SaveChangesAsync();

            }

            if (!context.ProductTypes.Any())
            {
                var types = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                var collection = JsonSerializer.Deserialize<List<ProductType>>(types);

                foreach (var item in collection)
                {
                    context.ProductTypes.Add(item);
                }

                await context.SaveChangesAsync();

            }

             if (!context.Products.Any())
            {
                var products = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                var collection = JsonSerializer.Deserialize<List<Product>>(products);

                foreach (var item in collection)
                {
                    context.Products.Add(item);
                }

                await context.SaveChangesAsync();

            }
        }

    }
}