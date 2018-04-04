using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ProductsWeb.Models
{

    public class ProductsDbContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductsDbContext() : base()
        {
            Database.SetInitializer<ProductsDbContext>(new ProductsDBInitializer());
        }
        public static ProductsDbContext Create()
        {
            return new ProductsDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Category>().Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }


        private class ProductJson
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
        }
        private class ProductsDBInitializer : DropCreateDatabaseAlways<ProductsDbContext>
        {
            protected override void Seed(ProductsDbContext context)
            {
                using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/products.json")))
                {
                    string json = r.ReadToEnd();
                    List<ProductJson> productsJson = JsonConvert.DeserializeObject<List<ProductJson>>(json);
                    foreach (var productJson in productsJson)
                    {
                        var query = from c in context.Categories
                            where c.Name == productJson.Category
                            select c;

                        var category = query.FirstOrDefault();
                        if (category == null)
                        {
                            category = new Category()
                            {
                                Name = productJson.Category,
                            };
                            context.Categories.Add(category);
                        }

                        context.Products.AddOrUpdate(p => p.Id,
                            new Product()
                            {
                                Name = productJson.Name,
                                Description = productJson.Description,
                                Category = category
                            }
                        );

                        context.SaveChanges();
                    }
                }
            }
        }
    }
    


}