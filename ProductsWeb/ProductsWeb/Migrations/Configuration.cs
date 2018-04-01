namespace ProductsWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Web;
    using System.Web.Hosting;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsWeb.Models.ProductsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductsDbContext context)
        {
            using (StreamReader r = new StreamReader("C:/Users/Javier/Source/Repos/ProductDatabaseAPI/ProductsWeb/ProductsWeb/App_Data/products.json"))
            {
                string json = r.ReadToEnd();
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                foreach (var product in products)
                {
                    context.Products.AddOrUpdate(p => p.Id,
                    new Product()
                    {
                        Id = products.Count,
                        Name = product.Name,
                        Description = product.Description,
                        Category = product.Description
                    }
                    );
                }
            }

        }

    }
}
