using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsWeb.Models
{

    public class ProductsDbContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductsDbContext() : base()
        {
            Database.SetInitializer<ProductsDbContext>(new CreateDatabaseIfNotExists<ProductsDbContext>());
        }
        public static ProductsDbContext Create()
        {
            return new ProductsDbContext();
        }



        private class ProductsDBInitializer : DropCreateDatabaseAlways<ProductsDbContext>
        {
            protected override void Seed(ProductsDbContext context)
            {
                base.Seed(context);
            }
        }
    }
    


}