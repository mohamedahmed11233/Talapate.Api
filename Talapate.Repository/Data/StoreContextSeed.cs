using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talapate.Core.Entities;
using Talapate.Repository.Data.Context;

namespace Talapate.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task seedAsync(StoreContext _dbContext)
        {
            if (!_dbContext.ProductBrands.Any()) //if brands not any in table do this code 
            {
                // to Read Json File 
                var BrandsData = File.ReadAllText("../Talapate.Repository/Data/dataSeed/brands.json");
                // to convert Json file to List 
                var Brands = JsonSerializer.Deserialize<List<productBrand>>(BrandsData);
                // to add List in dataBase 
                if (Brands is not null && Brands.Count > 0)
                {
                    foreach (var Brand in Brands)
                        await _dbContext.Set<productBrand>().AddAsync(Brand);

                    await _dbContext.SaveChangesAsync();
                }
            }

            if (!_dbContext.productCataegories.Any()) //if brands not any in table do this code 
            {
                // to Read Json File 
                var categorydata = File.ReadAllText("../Talapate.Repository/Data/dataSeed/categories.json");
                // to convert Json file to List 
                var categery = JsonSerializer.Deserialize<List<ProductCataegory>>(categorydata);
                // to add List in dataBase 
                if (categery is not null && categery.Count > 0)
                {
                    foreach (var catagery in categery)
                        await _dbContext.Set<ProductCataegory>().AddAsync(catagery);

                    await _dbContext.SaveChangesAsync();

                }
            }


            if (!_dbContext.products.Any()) //if brands not any in table do this code 
            {
                // to Read Json File 
                var products = File.ReadAllText("../Talapate.Repository/Data/dataSeed/products.json");
                // to convert Json file to List 
                var productSerializer = JsonSerializer.Deserialize<List<Product>>(products);
                // to add List in dataBase 
                if (productSerializer is not null && productSerializer.Count > 0)
                {
                    foreach (var product1 in productSerializer)
                        await _dbContext.Set<Product>().AddAsync(product1);

                    await _dbContext.SaveChangesAsync();

                }
            }



        }
    }

}
