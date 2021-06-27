using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Models;

namespace ProductAPI.DataLayer
{
    public interface IProductRepository
    {
        public Task<bool> AddProductAsync(Product product);
        public Task<bool> UpdateProductAsync(Product product);
        public Task<bool> DeleteProductAsync(int productId);
        public Task<IEnumerable<Product>> GetProductsAsync();
    }
}
