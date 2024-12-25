using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogService.Models;

namespace ProductCatalogService.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductModel product);
        Task UpdateProductAsync(ProductModel product);
        Task DeleteProductAsync(int id);
    }
}