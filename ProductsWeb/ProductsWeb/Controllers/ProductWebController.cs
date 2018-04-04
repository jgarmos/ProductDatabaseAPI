using ProductsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsWeb.Controllers
{
    public class ProductWebController : ApiController
    {
        private IProductsService _productsService;

        public ProductWebController()
        {
            _productsService = new ProductsService();
        }

        [Route("api/ProductWeb/GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            var products = _productsService.GetAllProducts();

            if ((products == null) || (products.Count == 0))
            {
                return NotFound();
            }

            List<ProductDto> productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDto.Add(new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category.Name
                });
            }

            return Ok(productsDto);
        }

        [Route("api/ProductWeb/GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            var categories = _productsService.GetAllCategories();

            if ((categories== null) || (categories.Count == 0))
            {
                return NotFound();
            }
            List<string> listCategories = new List<string>();
            foreach (var category in categories)
            {
                listCategories.Add(category.Name);
            }
            

            return Ok(listCategories);
        }

        [Route("api/ProductWeb/GetAllProductsByCategoryName")]
        public IHttpActionResult GetAllProductsByCategoryName(string categoryName)
        {
            var products = _productsService.GetAllProductsByCategoryName(categoryName);

            if ((products == null) || (products.Count == 0))
            {
                return NotFound();
            }
            List<ProductDto> productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDto.Add(new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category.Name
                });
            }

            return Ok(productsDto);
        }


    }
}
