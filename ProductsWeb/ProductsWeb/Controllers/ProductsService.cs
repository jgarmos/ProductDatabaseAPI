using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsWeb.Models;

namespace ProductsWeb.Controllers
{
    
    public class ProductsService : IProductsService
    {
        private readonly ProductsDbContext _context;

        public ProductsService()
        {
            _context = new ProductsDbContext();
        }


        public ICollection<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public void DeleteProductById(int productId)
        {
            Product product = _context.Products.Find(productId);

            _context.Products.Remove(product);
            _context.SaveChanges(); 
        }

        
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public ICollection<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public ICollection<Product> GetAllProductsByCategoryName(string categoryName)
        {
            var query = from p in _context.Products
                      join c in _context.Categories on p.CategoryId equals c.Id
                      where c.Name == categoryName
                      select p;


            return query.ToList();
        }

    }
}
