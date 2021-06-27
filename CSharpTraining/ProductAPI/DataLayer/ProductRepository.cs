using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;

namespace ProductAPI.DataLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            await using SqlConnection con = new SqlConnection(_connectionString);
            var productCount = await con.ExecuteAsync("sp_AddOrUpdateProduct", new
            {
                product.Id,
                product.ProductName,
                product.Price,
                product.Description,
                product.ManufactureName,
                product.image
            },null,null,CommandType.StoredProcedure);
            return productCount > 0;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var productCount = await con.ExecuteAsync("sp_DeleteProduct", new
                {
                    Id = productId
                }, null, null, CommandType.StoredProcedure);
                return productCount > 0;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return await con.QueryAsync<Product>("sp_GetProducts", null, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var productCount = await con.ExecuteAsync("sp_AddOrUpdateProduct", new
                {
                    product.Id,
                    product.ProductName,
                    product.Price,
                    product.Description,
                    product.ManufactureName,
                    product.image
                }, null, null, CommandType.StoredProcedure);
                return productCount > 0;
            }
        }
    }
}
