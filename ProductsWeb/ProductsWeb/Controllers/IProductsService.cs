using ProductsWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsWeb.Controllers
{
    public interface IProductsService
    {
        /// <summary>
        /// Returns all the products
        /// </summary>
        /// <returns></returns>
        ICollection<Product> GetAllProducts();

        /// <summary>
        /// Delete a product by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        void DeleteProductById(int productId);

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        void CreateProduct(Product product);

    }
}