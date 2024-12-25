using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Messaging;
using ProductCatalogService.Models;
using ProductCatalogService.Services;

namespace ProductCatalogService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllProducts()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if(product == null)return NotFound(Messages.ProductNotFound);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateProduct(int id  ,[FromBody] ProductModel model)
        {
            if(!ModelState.IsValid)return BadRequest(Messages.ValidationError);
            if(id != model.ProductId)return NotFound(Messages.ProductNotFound);

            await _service.UpdateProductAsync(model);
            return Ok(Messages.ProductUpdated);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel model)
        {
            if(!ModelState.IsValid){
                return BadRequest(Messages.ValidationError);
            }
            await _service.AddProductAsync(model);
            // return CreatedAtAction(nameof(GetProductById) , new{id =model.ProductId , Messages.ProductCreated});
            return Ok(model);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            await _service.DeleteProductAsync(id);
            return NoContent();
        }
    }
}