using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Business;
using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBusiness _productBusiness;

        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [Authorize(Roles = "Consumer,Seller")]
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productBusiness.GetProductsAsync();
        }

        [Authorize(Roles = "Consumer,Seller")]
        [HttpGet]
        [Route("{productId}")]
        public async Task<Product> GetProductById(int productId)
        {
            return await _productBusiness.GetProductByIdAsync(productId);
        }

        [Authorize(Roles = "Seller")]
        [HttpPost]
        [Route("")]
        public async Task<bool> AddProduct(Product product)
        {
            return await _productBusiness.AddProductAsync(product);
        }

        [Authorize(Roles = "Seller")]
        [HttpPut]
        [Route("")]
        public async Task<bool> UpdateProduct(Product product)
        {
            return await _productBusiness.UpdateProductAsync(product);
        }

        [Authorize(Roles = "Seller")]
        [HttpDelete]
        [Route("{productId}")]
        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productBusiness.DeleteProductAsync(productId);
        }
    }
}
