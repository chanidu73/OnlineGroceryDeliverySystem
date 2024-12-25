using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogService.Messaging;
using ProductCatalogService.Models;
using ProductCatalogService.Repositories;

namespace ProductCatalogService.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException(Messages.ProductNotFound);
            return product;
        }

        public async Task AddProductAsync(ProductModel product)
        {
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductModel product)
        {
            // var existingProduct = await _productRepository.GetProductByIdAsync(product.ProductId);
            // if (existingProduct == null)
            //     throw new KeyNotFoundException($"Product with ID {product.ProductId} not found.");

            // // Update only specific fields
            // existingProduct.Name = product.Name;
            // existingProduct.Description = product.Description;
            // existingProduct.Price = product.Price;


            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            await _productRepository.DeleteProductAsync(id);
        }


    }
}