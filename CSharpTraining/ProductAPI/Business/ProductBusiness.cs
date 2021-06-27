using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.DataLayer;
using ProductAPI.Models;

namespace ProductAPI.Business
{
    public class ProductBusiness:IProductBusiness
    {
        private readonly IProductRepository _productRepository;
        
        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<bool> AddProductAsync(Product product)
        {
            return _productRepository.AddProductAsync(product);
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            return _productRepository.UpdateProductAsync(product);
        }

        public Task<bool> DeleteProductAsync(int productId)
        {
            return _productRepository.DeleteProductAsync(productId);
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return _productRepository.GetProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var products = await _productRepository.GetProductsAsync();
            return products.Where(p=>p.Id==productId).FirstOrDefault();
        }
    }
}
