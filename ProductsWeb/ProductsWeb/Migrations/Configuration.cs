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
            AutomaticMigrationsEnabled = true;
        }
        private class ProductJson
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
        }
        protected override void Seed(ProductsDbContext context)
        {
            //using (StreamReader r = new StreamReader("C:\\Users\\javiergarcia\\Source\\Repos\\ProductDatabaseAPI\\ProductsWeb\\ProductsWeb\\App_Data\\products.json"))
            //{
            //    string json = r.ReadToEnd();
            //    List<ProductJson> productsJson = JsonConvert.DeserializeObject<List<ProductJson>>(json);
            //    foreach (var productJson in productsJson)
            //    {
            //        var query = from c in context.Categories
            //            where c.Name == productJson.Category
            //                    select c;

            //        bool existsCategory = query.FirstOrDefault() != null;

            //        if (!existsCategory)
            //        {
            //            context.Categories.AddOrUpdate(c => c.Name,
            //                new Category()
            //                {
            //                    Name = productJson.Name,
            //                }
            //            );
            //        }
 
            //        context.Products.AddOrUpdate(p => p.Id,
            //        new Product()
            //        {
            //            Id = productsJson.Count,
            //            Name = productJson.Name,
            //            Description = productJson.Description,
            //            CategoryId = query.ToList().FirstOrDefault().Id //???????????????????????
            //        }
            //        );
            //    }
            //}

        }

    }
}
