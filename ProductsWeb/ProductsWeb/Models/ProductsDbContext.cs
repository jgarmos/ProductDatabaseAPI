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
    }

}